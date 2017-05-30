using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public class QuestItem : Item
    {
		public QuestItem() : base() { }

		public QuestItem(string name) : base(name) { }

        public QuestItem(string name, string stats) : base(name, stats) { }

        public override AllowedItem Allowed { get; } = AllowedItem.Multiple;
    }
}
