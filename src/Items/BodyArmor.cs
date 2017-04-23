using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public class BodyArmor : Wearable
    {
        public int DP { get; private set; }

        public BodyArmor(int dp)
        {
            DP = dp;
        }

        public override void Equip()
        {
            // TODO: enequip previous armor
            // Screen.player.DefensePower += DP; TODO:
        }

        public override void UnEquip()
        {
            // Screen.player.DefensePower -= DP; TODO:
        }
    }
}
