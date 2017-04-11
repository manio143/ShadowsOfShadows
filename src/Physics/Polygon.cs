using System;

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ShadowsOfShadows.Physics
{
	public struct Polygon
	{
		public List<Rectangle> Rectangles{ get; }

		public Polygon (List<Rectangle> rectangles)
		{
			this.Rectangles = rectangles;
		}
	}
}

