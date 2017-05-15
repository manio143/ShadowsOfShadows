using System;

namespace ShadowsOfShadows.Items
{
	public class Item
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
    }
}
