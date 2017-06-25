using System;

using ShadowsOfShadows.Renderables;
using ShadowsOfShadows.Consoles;

namespace ShadowsOfShadows.Entities
{
    public class Sign : Thing, IInteractable
    {
        private String Text { get; set; }

        public Sign() : base('T') { }

        public Sign(String text) : base(new ConsoleRenderable('T'))
        {
            Text = text;
        }

        public void Interact()
        {
            Screen.MessageConsole.PrintMessageAndWait(Text);
        }
    }
}
