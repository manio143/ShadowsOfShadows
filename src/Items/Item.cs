using System;
using System.Linq;

namespace ShadowsOfShadows.Items
{
	public abstract class Item : IEquatable<Item>
    {
        protected string Name { get; set; } = String.Empty;
        public string StatsString { get; set; } = String.Empty;

        protected Item() { }

        protected Item(string name)
        {
            Name = name;
        }

        protected Item(string name, string stats)
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

		public bool Equals(Item other)
		{
			if (other.GetType () == GetType ())
			{
				foreach (var property in GetType().GetProperties())
					if (!property.GetValue (other).Equals (property.GetValue (this)))
						return false;
				return true;
			}
			return false;
		}

		public override bool Equals (object obj)
		{
			if (obj is Item)
				return Equals ((Item)obj);
			return base.Equals (obj);
		}

		public override int GetHashCode ()
		{
			var elements = GetType ().GetProperties ().Select (p => p.GetValue (this)?.GetHashCode () ?? 0);
			int sum = 0;
			foreach (var e in elements)
				sum = (sum + e) % 288919320;
			return sum;
		}
    }
}