using System;

using Microsoft.Xna.Framework;

namespace ShadowsOfShadows.Physics
{
	public class CollisionBox
	{
		public Polygon Polygon { get; set; }
        public bool Active { get; set; }

        /* For serialization */
        public CollisionBox()
        {

        }

        public CollisionBox (Polygon polygon)
		{
			this.Polygon = polygon;
            Active = true;
		}

		public static bool CheckCollision(Transform box1, Transform box2)
		{
            if(box1.Collision.Active && box2.Collision.Active)
			    foreach (Rectangle rect1 in box1.Collision.Polygon.WithOffset(box1.Position)) 
			    {
				    foreach (Rectangle rect2 in box2.Collision.Polygon.WithOffset(box2.Position)) 
				    {
					    if (rect1.Intersects (rect2))
						    return true;
				    }
			    }
			return false;
		}

        public void TurnOff()
        {
            Active = false;
        }
    }
}

