using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public class StrengthPotion : TimedConsumable
    {
        public int AP { get; private set; }
        public StrengthPotion(TimeSpan duration, int ap) : base(duration)
        {
            AP = ap;
        }
        public override void Use()
        {
            base.Use();
            // Screen.player.AttackPower += AP; TODO:
        }

        public override void EndEffect()
        {
            // Screen.player.AttackPower -= AP; TODO:
        }

    }
}
