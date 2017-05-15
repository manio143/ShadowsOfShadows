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
            Transform.Collision = new CollisionBox(
                new Polygon(new List<Rectangle> { new Rectangle(0, 0, 1, 1) })
                );
            Renderable = renderable;
		}
	}
}
