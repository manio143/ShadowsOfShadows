using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SadConsole.GameHelpers;
using ShadowsOfShadows.Helpers;
using Keyboard = SadConsole.Input.Keyboard;

namespace ShadowsOfShadows.Consoles
{
    public abstract class Message
    {
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

    [AttributeUsage(AttributeTargets.All)]
    public class DisplayAttribute : Attribute
    {
        public string Title { get; }

        public DisplayAttribute(string title)
        {
            Title = title;
        }
    }

    public class QuestionMessage : Message
    {
        private List<Tuple<Enum, string>> answers;

        public int Rows { get; set; } = 3;

        public int AnswerCount { get; }

        public QuestionMessage(Type answersType, string question = null)
        {
            answers = answersType.GetEnumValues()
                .Cast<Enum>()
                .Select(@enum => new Tuple<Enum, string>(@enum, @enum.GetAttributeOfType<DisplayAttribute>()?.Title))
                .Where(tp => tp.Item2 != null)
                .ToList();
            AnswerCount = answers.Count;

            if (question != null)
            {
                Text = ConsoleObjects.CreateFromString(question);
                Rows = 2;
            }
        }

        public override GameObject Text { get; } = null;

        private GameObject waitPointer;
        public override GameObject WaitPointer => waitPointer;

        private int pointerIndex;

        private int PointerIndex
        {
            get { return pointerIndex; }
            set
            {
                pointerIndex = value % positions.Count;
                if (pointerIndex < 0) pointerIndex += positions.Count;
                waitPointer.Position = positions[pointerIndex] + new Point(-1, 0);
            }
        }

        private List<GameObject> consoleObjects = new List<GameObject>();
        private List<Point> positions = new List<Point>();
        public override List<GameObject> Other => consoleObjects;

        private Enum result;
        public Enum Result => result;

        public Enum DefaultAnswer { get; set; }

        public override void Create(MessageConsole console)
        {
            waitPointer = ConsoleObjects.CreateFromGlyph(26);
            consoleObjects = answers.Select(t => ConsoleObjects.CreateFromString(t.Item2)).ToList();

            ComputePositions(console);

            for (var i = 0; i < consoleObjects.Count; i++)
                consoleObjects[i].Position = positions[i];

            PointerIndex = 0;

            Text.Position = console.Position + new Point(1, 1);
        }

        private void ComputePositions(MessageConsole console)
        {
            var columns = (int) Math.Ceiling(answers.Count * 1.0 / Rows);
            var last = 1;
            for (var i = 0; i < columns; i++)
            {
                for (var j = 0; j < Rows && i * Rows + j < answers.Count; j++)
                    positions.Add(console.Position + new Point(last, j + 1 + (Text == null ? 0 : 2)));

                var maxLegth = 0;
                for (var j = 0; j < Rows && i * Rows + j < answers.Count; j++)
                    maxLegth = Math.Max(maxLegth, answers[i * Rows + j].Item2.Length);
                last += maxLegth + 2;
            }
        }

        public override void ProcessKeyboard(Keyboard info)
        {
            base.ProcessKeyboard(info);
            if (info.IsKeyPressed(Keys.Left))
                PointerIndex -= Rows;
            else if (info.IsKeyPressed(Keys.Right))
                PointerIndex += Rows;
            else if (info.IsKeyPressed(Keys.Down))
                PointerIndex += 1;
            else if (info.IsKeyPressed(Keys.Up))
                PointerIndex -= 1;

            if (info.IsKeyPressed(Keys.Enter) || info.IsKeyPressed(Keys.Space))
            {
                result = answers[PointerIndex].Item1;
                Finished = true;
            }

            if (info.IsKeyPressed(Keys.Escape) && DefaultAnswer != null)
            {
                result = DefaultAnswer;
                Finished = true;
            }
        }
    }
}