using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        public bool ClearInactive { get; set; } = true;
        public bool Blocking { get; private set; } = true;

        protected Message CurrentMessage;

        protected List<GameObject> ConsoleObjects = new List<GameObject>();
        protected Queue<Message> MessageQueue = new Queue<Message>();
        private bool wait;

        public MessageConsole(int posX, int poxY, int width, int height)
            : base(width, height)
        {
            this.Position = new Point(posX, poxY);
        }

        protected void PrintMessage(string message)
        {
            PrintMessage(new SimpleMessage(message));
        }

        protected virtual void PrintMessage(Message message)
        {
            ConsoleObjects.Clear();
            message.Create(this);
            if (message.Text != null) ConsoleObjects.Add(message.Text);
            if (message.WaitPointer != null) ConsoleObjects.Add(message.WaitPointer);
            if (message.Other != null) ConsoleObjects.AddRange(message.Other);
            CurrentMessage = message;
            if (message.NonBlocking) Blocking = false;
        }

        public void PrintMessageWithTimeout(string message, int milliseconds)
        {
            PrintMessageAndWait(new TimeoutMessage(message, milliseconds));
        }
        
        public void PrintMessageAndWait(string message)
        {
            PrintMessageAndWait(new WaitMessage(message));
        }

        protected void PrintMessageAndWait(Message message)
        {
            if (wait)
                MessageQueue.Enqueue(message);
            else
            {
                PrintMessage(message);
                wait = true;
                this.IsActive = true;
            }
        }

        public void PrintMessagesAndWait(string[] messages)
        {
            PrintMessagesAndWait(messages.Select(m => new WaitMessage(m)).ToArray());
        }

        protected void PrintMessagesAndWait(WaitMessage[] messages)
        {
            PrintMessageAndWait(messages[0]);
            for (var i = 1; i < messages.Length; i++)
                MessageQueue.Enqueue(messages[i]);
        }

        public QuestionMessage AskQuestion(string message, Type answersType)
        {
            var questionMessage = new QuestionMessage(answersType, message);
            PrintMessageAndWait(questionMessage);
            return questionMessage;
        }

        public override void Draw(TimeSpan delta)
        {
            base.Draw(delta);
            foreach (var co in ConsoleObjects)
                co.Draw(delta);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (wait)
            {
                CurrentMessage.ProcessKeyboard(info);
                if (CurrentMessage.Finished)
                {
                    if (CurrentMessage.NonBlocking) Blocking = true;
                    CurrentMessage.OnPostProcessing();
                    wait = false;
                    if (MessageQueue.Count > 0)
                        PrintMessageAndWait(MessageQueue.Dequeue());
                    else
                    {
                        if (ClearInactive)
                            PrintMessage("");
                        else
                            ConsoleObjects.Remove(CurrentMessage.WaitPointer);
                        this.IsActive = false;
                    }
                }
            }
            return Blocking;
        }

        public override void Update(TimeSpan delta)
        {
            base.Update(delta);
            foreach (var co in ConsoleObjects)
                co.Update(delta);
        }
    }
}