using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ShadowsOfShadows.Entities
{
	public class Room
	{
		public List<Entity> Entities { get; }

		public Point EnterPoint { get; set; }
		public Point ExitPoint { get; set; }

		public Room (IEnumerable<Entity> entities)
		{
			Entities = new List<Entity> (entities);
		}
	}
}
