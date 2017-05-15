using System;

using ShadowsOfShadows.Consoles;

namespace ShadowsOfShadows.Items
{
    public abstract class BodyArmor : Wearable
    {
        public int DP { get; private set; }

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
    }
}
