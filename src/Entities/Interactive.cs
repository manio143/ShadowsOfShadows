using System;

using ShadowsOfShadows.Renderables;


namespace ShadowsOfShadows.Entities
{
    public abstract class Interactive : Thing
    {
        public abstract void Interact();

        public Interactive(IRenderable rendarable) : base(rendarable)
        {
        }

    }
}
