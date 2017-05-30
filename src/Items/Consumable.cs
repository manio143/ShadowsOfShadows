using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public abstract class Consumable : Item
    {
        public Consumable() : base() { }

		public Consumable(string name) : base(name) { }

        public Consumable(string name, string stats) : base(name, stats) { }

        public abstract void Use();

        public override AllowedItem Allowed { get; } = AllowedItem.Multiple;
    }
}
