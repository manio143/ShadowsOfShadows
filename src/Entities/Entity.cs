using System;

using ShadowsOfShadows.Renderables;
using ShadowsOfShadows.Physics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ShadowsOfShadows.Entities
{
	public abstract class Entity
	{
		public Transform Transform { get; set;}

		public IRenderable Renderable { get; set; }


		public Entity ( IRenderable renderable)
		{
			Transform = new Transform ();
            Renderable = renderable;
		}
	}
}
