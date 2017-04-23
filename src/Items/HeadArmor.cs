using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public abstract class HeadArmor : Wearable
    {
        public int DP { get; private set; }

        public HeadArmor(int dp)
        {
            DP = dp;
        }

        public override void Equip()
        {
            // TODO: unequip previous head armor
            // Screen.player.DefensePower += DP;
        }

        public override void UnEquip()
        {
            // Screen.player.DefensePower -= DP; TODO:
        }
    }
}
