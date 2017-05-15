using System;

namespace ShadowsOfShadows.Items
{
	public abstract class Item
	{
        protected String Name { get; set; }
        protected String StatsString { get; set; }

		public Item(String name, String stats)
		{
            Name = name;
            StatsString = stats;
		}
        public override String ToString()
        {
            String result = Name + "\n" + "Statistics:\n" + StatsString;
            return result;
        }

        public abstract AllowedItem Allowed { get; }

        public virtual bool IsLike(Item item)
        {
            return false;
        }
    }
}