﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShadowsOfShadows.Consoles;
using ShadowsOfShadows.Renderables;

namespace ShadowsOfShadows.Entities
{
    public class Switch : Thing, IInteractable
    {
        public Switch() : base() { throw new NotImplementedException(); }

        public Switch(IRenderable renderable) : base(renderable)
        {
            Value = false;
        }

        public bool Value { get; set; }

        public void Interact()
        {
            Value = !Value;
            Screen.MessageConsole.PrintMessageWithTimeout("Switch has been set to " + Value, TimeoutMessage.GENERAL_TIMEOUT);
        }
    }
}
