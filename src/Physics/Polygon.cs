using System;

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ShadowsOfShadows.Physics
{
	public struct Polygon
	{
		public List<Rectangle> Rectangles{ get; set; }

		public Polygon (List<Rectangle> rectangles)
		{
			this.Rectangles = rectangles;
		}

        public List<Rectangle> WithOffset(Point p)
        {
            List<Rectangle> result = new List<Rectangle>();
            foreach (var rectangle in Rectangles)
            {
                result.Add(new Rectangle(rectangle.Location + p, rectangle.Size));
            }

            return result;
        }
	}
}

