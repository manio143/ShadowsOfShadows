using System.Collections.Generic;

namespace ShadowsOfShadows
{
	public class Room
	{
		public List<Entity> Entities { get; }

		public Room (IEnumerable<Entity> entities)
		{
			Entities = new List<Entity> (entities);
		}
	}
}

