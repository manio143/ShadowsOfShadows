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

        private Message currentMessage;

        List<GameObject> consoleObjects = new List<GameObject>();
        Queue<Message> messageQueue = new Queue<Message>();
        private bool wait;

        public MessageConsole(int posX, int poxY, int width, int height)
            : base(width, height)
        {
            this.Position = new Point(posX, poxY);
        }

        public void PrintMessage(string message)
        {
            PrintMessage(new SimpleMessage(message));
        }

        private void PrintMessage(Message message)
        {
            consoleObjects.Clear();
            message.Create(this);
            if (message.Text != null) consoleObjects.Add(message.Text);
            if (message.WaitPointer != null) consoleObjects.Add(message.WaitPointer);
            if (message.Other != null) consoleObjects.AddRange(message.Other);
            currentMessage = message;
        }

        public void PrintMessageAndWait(string message)
        {
            PrintMessageAndWait(new WaitMessage(message));
        }

        private void PrintMessageAndWait(Message message)
        {
            if (wait)
                messageQueue.Enqueue(message);
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

        private void PrintMessagesAndWait(WaitMessage[] messages)
        {
            PrintMessageAndWait(messages[0]);
            for (var i = 1; i < messages.Length; i++)
                messageQueue.Enqueue(messages[i]);
        }

        public QuestionMessage AskQuestion(string message, Type answersType)
        {
            PrintMessageAndWait(message);
            var questionMessage = new QuestionMessage(answersType);
            PrintMessageAndWait(questionMessage);
            return questionMessage;
        }

        public override void Draw(TimeSpan delta)
        {
            base.Draw(delta);
            foreach (var co in consoleObjects)
                co.Draw(delta);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (wait)
            {
                currentMessage.ProcessKeyboard(info);
                if (currentMessage.Finished)
                {
                    wait = false;
                    if (messageQueue.Count > 0)
                        PrintMessageAndWait(messageQueue.Dequeue());
                    else
                    {
                        if (ClearInactive)
                            PrintMessage("");
                        else
                            consoleObjects.Remove(currentMessage.WaitPointer);
                        this.IsActive = false;
                    }
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