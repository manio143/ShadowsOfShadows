using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public class DefensePotion : TimedConsumable
    {
        public int DP { get; private set; }
        public DefensePotion(TimeSpan duration, int dp) : base(duration)
        {
            DP = dp;
        }

        public override void EndEffect()
        {
            //Screen.player.DefensePower -= DP; TODO:
        }

        public override void Use()
        {
            base.Use();
            // Screen.player.DefensePower += DP; TODO:
        }
    }
}
