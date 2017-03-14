using System;

using ShadowsOfShadows.Renderables;

namespace ShadowsOfShadows
{
	public abstract class Entity
	{
		public Transform Transform { get; set;}

		public IRenderable Renderable { get; set; }


		public Entity ()
		{
			Transform = new Transform ();
		}
	}
}

