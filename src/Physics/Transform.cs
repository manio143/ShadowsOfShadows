using System;

using Microsoft.Xna.Framework;

namespace ShadowsOfShadows.Physics
{
	public class Transform
	{
		public Point Position{ get; set;}
		public Direction Direction{ get; set;}
        public CollisionBox Collision { get; set; }

	}

	public enum Direction {
		Up,
		Down,
		Left,
		Right
	}
}

