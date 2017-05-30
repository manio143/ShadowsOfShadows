using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public abstract class Wearable :  Item
    {
		public Wearable() : base() { }

		public Wearable(String name) : base(name) { }

        public Wearable(String name, String stats) : base(name, stats) { }

        public override AllowedItem Allowed { get; } = AllowedItem.Single;
        public abstract void Equip();
        public abstract void UnEquip();
    }
}
