using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    [ItemType(ItemType.Armor)]
    public abstract class LegsArmor : Wearable
    {
        public int DP { get; set; }

        protected LegsArmor() : base("Legs Armor") { }

        protected LegsArmor(String name, int dp) : base(name, "Defence Power " + dp.ToString() + "\n")
        {
            DP = dp;
        }

        public override void Equip()
        {
            Screen.MainConsole.Player.DefencePower += DP;
        }

        public override void UnEquip()
        {
            Screen.MainConsole.Player.DefencePower -= DP;
        }

        public override bool IsLike(Item item)
        {
            return (item is LegsArmor);
        }
    }
}
