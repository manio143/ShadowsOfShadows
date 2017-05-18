using System;

using ShadowsOfShadows.Renderables;
using ShadowsOfShadows.Consoles;

namespace ShadowsOfShadows.Entities
{
    public class Sign : Thing, IInteractable
    {
        String Text { get; set; }

        public Sign(String text) : base( new ConsoleRenderable('T'))
        {
            Text = text;
        }

        public void Interact()
        {
			Screen.MessageConsole.PrintMessageAndWait(Text);
        }

        public override char GetEntityChar()
        {
            return 'T';
        }
    }
}
