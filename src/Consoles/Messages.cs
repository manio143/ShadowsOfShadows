using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SadConsole.GameHelpers;
using ShadowsOfShadows.Entities;
using ShadowsOfShadows.Helpers;
using ShadowsOfShadows.Items;
using Keyboard = SadConsole.Input.Keyboard;

namespace ShadowsOfShadows.Consoles
{
    public abstract class Message
    {
        public const int PointerGlyph = 26;

        public abstract GameObject Text { get; }
        public abstract GameObject WaitPointer { get; }
        public abstract List<GameObject> Other { get; }
        public bool Finished { get; protected set; }

        public Action<Message> PostProcessing { get; set; }

        public abstract void Create(MessageConsole console);

        public virtual void ProcessKeyboard(Keyboard info)
        {
        }

        public void OnPostProcessing() => PostProcessing?.Invoke(this);
    }

    public class SimpleMessage : Message
    {
        private readonly string message;

        public SimpleMessage(string msg)
        {
            message = msg;
        }

        private GameObject text;

        public override GameObject Text => text;
        public override GameObject WaitPointer { get; } = null;
        public override List<GameObject> Other { get; } = null;

        public override void Create(MessageConsole console)
        {
            text = ConsoleObjects.CreateFromString(message);
            text.Position = console.Position + new Point(1, 1);
        }
    }

    public class WaitMessage : SimpleMessage
    {
        public WaitMessage(string msg) : base(msg)
        {
        }

        private GameObject waitPointer;

        public override GameObject WaitPointer => waitPointer;

        public override void Create(MessageConsole console)
        {
            base.Create(console);
            waitPointer = ConsoleObjects.CreateBlinkingFromGlyph(26, 1);
            waitPointer.Position = console.Position + new Point(console.Width - 2, console.Height - 2);
        }

        public override void ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Keys.Space))
                Finished = true;
        }
    }

    public class ChoiceMessage<T> : Message
    {
        protected List<Tuple<T, string>> Answers;
        public int AnswersCount => Answers.Count;

        public int Rows { get; set; } = 1;

        public override GameObject Text { get; }
        public override GameObject WaitPointer { get; }
        public override List<GameObject> Other { get; }

        private int pointerIndex;

        protected int PointerIndex
        {
            get { return pointerIndex; }
            set
            {
                if (Positions.Count == 0)
                {
                    pointerIndex = 0;
                    WaitPointer.IsVisible = false;
                }
                else
                {
                    pointerIndex = value % Positions.Count;
                    if (pointerIndex < 0) pointerIndex += Positions.Count;
                    WaitPointer.Position = Positions[pointerIndex] + new Point(-1, 0);
                }
            }
        }

        public int StartIndex { get; set; }

        protected List<Point> Positions = new List<Point>();

        public ChoiceMessage(IEnumerable<Tuple<T, string>> answers, string question = null)
        {
            Answers = new List<Tuple<T, string>>(answers);
            WaitPointer = ConsoleObjects.CreateFromGlyph(PointerGlyph);
            Other = new List<GameObject>();
            if (question != null)
                Text = ConsoleObjects.CreateFromString(question);
        }

        public override void Create(MessageConsole console)
        {
            Other.Clear();
            Other.AddRange(Answers.Select(t => ConsoleObjects.CreateFromString(t.Item2)));

            ComputePositions(console);

            for (var i = 0; i < Other.Count; i++)
                Other[i].Position = Positions[i];

            PointerIndex = StartIndex;

            Text.Position = console.Position + new Point(1, 1);
        }

        private void ComputePositions(MessageConsole console)
        {
            var columns = (int) Math.Ceiling(Answers.Count * 1.0 / Rows);
            var last = 1;
            for (var i = 0; i < columns; i++)
            {
                for (var j = 0; j < Rows && i * Rows + j < Answers.Count; j++)
                    Positions.Add(console.Position + new Point(last, j + 1 + (Text == null ? 0 : 2)));

                var maxLegth = 0;
                for (var j = 0; j < Rows && i * Rows + j < Answers.Count; j++)
                    maxLegth = Math.Max(maxLegth, Answers[i * Rows + j].Item2.Length);
                last += maxLegth + 2;
            }
        }

        public override void ProcessKeyboard(Keyboard info)
        {
            base.ProcessKeyboard(info);
            MovePointer(info);
        }

        protected void MovePointer(Keyboard info)
        {
            if (info.IsKeyPressed(Keys.Left))
                PointerIndex -= Rows;
            else if (info.IsKeyPressed(Keys.Right))
                PointerIndex += Rows;
            else if (info.IsKeyPressed(Keys.Down))
                PointerIndex += 1;
            else if (info.IsKeyPressed(Keys.Up))
                PointerIndex -= 1;
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class DisplayAttribute : Attribute
    {
        public string Title { get; }

        public DisplayAttribute(string title)
        {
            Title = title;
        }
    }

    public class QuestionMessage : ChoiceMessage<Enum>
    {
        public QuestionMessage(Type answersType, string question = null)
            : base(answersType.GetEnumValues()
                    .Cast<Enum>()
                    .Select(
                        @enum => new Tuple<Enum, string>(@enum, @enum.GetAttributeOfType<DisplayAttribute>()?.Title))
                    .Where(tp => tp.Item2 != null)
                , question)
        {
            if (question != null)
                Rows = 2;
            else
                Rows = 3;
        }

        public Enum Result { get; private set; }

        public Enum DefaultAnswer { get; set; }

        public override void ProcessKeyboard(Keyboard info)
        {
            base.ProcessKeyboard(info);

            if (info.IsKeyPressed(Keys.Enter) || info.IsKeyPressed(Keys.Space))
            {
                Result = Answers[PointerIndex].Item1;
                Finished = true;
            }

            if (info.IsKeyPressed(Keys.Escape) && DefaultAnswer != null)
            {
                Result = DefaultAnswer;
                Finished = true;
            }
        }
    }

    public class ChestMessage : ChoiceMessage<Item>
    {
        public Chest Chest { get; }

        public ChestMessage(Chest chest)
            : base(chest.Items
                    .Select(item => new Tuple<Item, string>(item, item.ToString()))
                , "Chest")
        {
            Chest = chest;
        }

        public override void ProcessKeyboard(Keyboard info)
        {
            base.ProcessKeyboard(info);
            if (info.IsKeyPressed(Keys.Enter) || info.IsKeyPressed(Keys.Space))
            {
                if (Answers.Count == 0)
                    Finished = true;
                else
                    ProcessItemWithEquipment(Answers[PointerIndex].Item1);
            }
            if (info.IsKeyPressed(Keys.Escape))
            {
                Finished = true;
            }
        }

        private void ProcessItemWithEquipment(Item item)
        {
            var similar = Screen.MainConsole.Player.Equipment
                .FirstOrDefault(i => item.IsLike(i) && item.Allowed == AllowedItem.Single);
            if (similar == null)
            {
                Screen.MainConsole.Player.Equipment.Add(item);
                Chest.Items.Remove(item);
                ResetView();
            }
            else
            {
                var question = Screen.MessageConsole.AskQuestion(
                    "You already have a similar item and cannot have both. Do you want to swap?",
                    typeof(YesNoQuestion));
                question.DefaultAnswer = YesNoQuestion.No;
                question.PostProcessing = message =>
                {
                    if ((YesNoQuestion) (message as QuestionMessage).Result == YesNoQuestion.Yes)
                    {
                        Screen.MainConsole.Player.Equipment.Remove(similar);
                        Screen.MainConsole.Player.Equipment.Add(item);
                        Chest.Items.Remove(item);
                        Chest.Items.Add(similar);
                        ResetView();
                    }
                };
            }
        }

        private void ResetView()
        {
            var newMessage = Screen.MenuConsole.OpenChest(Chest);
            PostProcessing = null;
            newMessage.StartIndex = PointerIndex;
            Finished = true;
        }
    }

    public class EquipmentMessage : ChoiceMessage<Item>
    {
        public EquipmentMessage()
            : base(ComputeNameList(Screen.MainConsole.Player.Equipment), "EQUIPMENT")
        {
        }

		private static IEnumerable<Tuple<Item, string>> ComputeNameList(IEnumerable<Item> items)
		{
			var dict = new Dictionary<Item, int>();
			foreach(var item in items)
				if(dict.ContainsKey(item))
					dict[item]+=1;
				else
					dict[item]=1;
			return dict.Select(kvp => {
				string title = kvp.Key.ToString();
				//Not great but currently I don't see another way
				int remaining = Screen.MENU_WIDTH - 1 - title.Length;
				if(kvp.Value > 1) {
					string countStr = kvp.Value.ToString();
					title += countStr.PadLeft(remaining - countStr.Length);
				}
				return new Tuple<Item, string>(kvp.Key, title);
			});
		}

        public override void ProcessKeyboard(Keyboard info)
        {
            base.ProcessKeyboard(info);
            if (info.IsKeyPressed(Keys.Enter) || info.IsKeyPressed(Keys.Space))
            {
                if (Answers.Count == 0)
                    Finished = true;
                else
                    ProcessItem(Answers[PointerIndex].Item1);
            }
            if (info.IsKeyPressed(Keys.Escape))
            {
                Finished = true;
            }
        }

        private void ProcessItem(Item item)
        {
            var consumable = item as Consumable;
            if (consumable != null)
            {
                consumable.Use();
                Screen.MainConsole.Player.Equipment.Remove(consumable);
                Screen.MessageConsole.PrintMessageWithTimeout($"{consumable} consumed.", TimeoutMessage.GENERAL_TIMEOUT);
                ResetView();
            }
        }

        private void ResetView()
        {
            var newMessage = Screen.MenuConsole.OpenEquipment();
            PostProcessing = null;
            newMessage.StartIndex = PointerIndex;
            Finished = true;
        }
    }

    public class TimeoutMessage : Message
    {
        public const int GENERAL_TIMEOUT = 3000; //3 seconds
        public const int SHORT_TIMEOUT = 2000;   //2 seconds

        public override GameObject Text { get; }
        public override GameObject WaitPointer { get; }
        public override List<GameObject> Other { get; }

        private Timer timer;

        public TimeoutMessage(string message, int milliseconds)
        {
            Text = ConsoleObjects.CreateFromString(message);
            WaitPointer = null;
            Other = null;

            timer = new Timer(milliseconds);
            timer.AutoReset = false;
            timer.Elapsed += (sender, args) => Finished = true;
        }

        public override void Create(MessageConsole console)
        {
            Text.Position = console.Position + new Point(1, 1);
            timer.Start();
        }
    }
}