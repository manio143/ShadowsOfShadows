using System;

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ShadowsOfShadows.Physics
{
	public class Transform
	{
		public Point Position{ get; set;}
		public Direction Direction{ get; set;}
        public CollisionBox Collision { get; set; }

        public Transform()
        {
            Collision = new CollisionBox(
                new Polygon(new List<Rectangle> { new Rectangle(0, 0, 1, 1) })
                );
        }
	}
}

