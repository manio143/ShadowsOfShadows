using System;

using Microsoft.Xna.Framework;

namespace ShadowsOfShadows.Physics
{
	public class CollisionBox
	{
		public Polygon Polygon {get;}

		public CollisionBox (Polygon polygon)
		{
			this.Polygon = polygon;
		}

		public static bool CheckCollision(CollisionBox box1, CollisionBox box2)
		{
			foreach (Rectangle rect1 in box1.Polygon.Rectangles) 
			{
				foreach (Rectangle rect2 in box2.Polygon.Rectangles) 
				{
					if (rect1.Intersects (rect2))
						return true;
				}
			}

			return false;
		}
	}
}

