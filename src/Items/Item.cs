using System;

namespace ShadowsOfShadows.Items
{
    [System.Xml.Serialization.XmlInclude(typeof(Consumable))]
    public abstract class Item
    {
        protected string Name { get; set; }
        protected string StatsString { get; set; }

        public Item()
        {

        }

        public Item(string name, string stats)
        {
            Name = name;
            StatsString = stats;
        }

        public override string ToString() => Name;

        public string Details()
        {
            string result = Name + "\n" + "Statistics:\n" + StatsString;
            return result;
        }

        public abstract AllowedItem Allowed { get; }

        public virtual bool IsLike(Item item)
        {
            return false;
        }
    }
}