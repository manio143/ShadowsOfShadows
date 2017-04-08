using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SadConsole.GameHelpers;
using ShadowsOfShadows.Helpers;
using Keyboard = SadConsole.Input.Keyboard;

namespace ShadowsOfShadows.Consoles
{
    public class MessageConsole : BorderedConsole
    {
        public bool IsActive { get; set; }

        List<GameObject> consoleObjects = new List<GameObject>();
        Queue<string> messageQueue = new Queue<string>();
        private bool wait;
        private GameObject waitPointer;

        public MessageConsole(int posX, int poxY, int width, int height)
            : base(width, height)
        {
            this.Position = new Point(posX, poxY);

            waitPointer = ConsoleObjects.CreateBlinkingFromGlyph(26, 1);
            waitPointer.Position = this.Position + new Point(Width - 2, Height - 2);
        }

        public void PrintMessage(string message)
        {
            consoleObjects.Clear();
            var msgObject = ConsoleObjects.CreateFromString(message);
            msgObject.Position = this.Position + new Point(1, 1);
            consoleObjects.Add(msgObject);
        }

        public void PrintMessageAndWait(string message)
        {
            PrintMessage(message);
            consoleObjects.Add(waitPointer);
            wait = true;
            this.IsActive = true;
        }

        public void PrintMessageAndWait(string[] messages)
        {
            PrintMessageAndWait(messages[0]);
            for (var i = 1; i < messages.Length; i++)
                messageQueue.Enqueue(messages[i]);
        }

        public override void Draw(TimeSpan delta)
        {
            base.Draw(delta);
            foreach (var co in consoleObjects)
                co.Draw(delta);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (wait && info.IsKeyDown(Keys.Space))
            {
                wait = false;
                if (messageQueue.Count > 0)
                    PrintMessageAndWait(messageQueue.Dequeue());
                else
                {
                    PrintMessage("");
                    this.IsActive = false;
                }
            }
            return true;
        }

        public override void Update(TimeSpan delta)
        {
            base.Update(delta);
            foreach (var co in consoleObjects)
                co.Update(delta);
        }
    }
}