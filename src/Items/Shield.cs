using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public class Shield : Wearable
    {
        public int DP { get; private set; }

        public Shield(int dp)
        {
            DP = dp;
        }

        public override void Equip()
        {
            // TODO: enequip previous shield
            // Screen.player.DefensePower += DP; TODO:
        }

        public override void UnEquip()
        {
            // Screen.player.DefensePower -= DP; TODO:
        }
    }
}

