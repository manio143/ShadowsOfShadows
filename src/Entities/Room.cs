using System.Collections.Generic;

namespace ShadowsOfShadows.Entities
{
    public class Room
    {
        public List<Entity> Entities { get; set; }

        /* For serialization */
        public Room() { }

		public Room (IEnumerable<Entity> entities)
		{
			Entities = new List<Entity> (entities);
		}
	}
}
