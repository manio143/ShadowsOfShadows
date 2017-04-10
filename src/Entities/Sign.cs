using System;

using ShadowsOfShadows.Renderables;

namespace ShadowsOfShadows.Entities
{
    public class Sign : Interactive
    {
        String Text { get; set; }

        public Sign(String text) : base( new ConsoleRenderable('T'))
        {
            Text = text;
        }

        public override void Interact()
        {
            // TODO: message console print sign text
        }
    }
}
