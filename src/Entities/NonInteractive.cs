using System;

using ShadowsOfShadows.Renderables;

namespace ShadowsOfShadows.Entities
{
    public abstract class NonInteractive : Thing
    {
		public NonInteractive() : base() { }
        public NonInteractive(IRenderable renderable) : base(renderable) { }
    }
}
