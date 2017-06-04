using System;

using ShadowsOfShadows.Consoles;

namespace ShadowsOfShadows.Items
{
    [ItemType(ItemType.Armor)]
    public abstract class BodyArmor : Wearable
    {
        public int DP { get; set; }

		public BodyArmor() : base("Body Armor") { }

        public BodyArmor(String name, int dp) : base(name, "Defence Power " + dp.ToString() + "\n")
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
            return (item is BodyArmor);
        }
    }
}
