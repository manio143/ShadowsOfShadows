using System;

using Microsoft.Xna.Framework;

namespace ShadowsOfShadows
{
	public class Transform
	{
		public Point Position{ get; set;}
		public Direction Direction{ get; set;}

	}

	public enum Direction {
		Up,
		Down,
		Left,
		Right
	}
}

