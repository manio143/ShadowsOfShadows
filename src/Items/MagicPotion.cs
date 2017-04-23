using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public class MagicPotion : TimedConsumable
    {
        public int MP { get; private set; }
        public MagicPotion(TimeSpan duration, int mp) : base(duration)
        {
            MP = mp;
        }

        public override void Use()
        {
            base.Use();
            // Screen.player.MagicPower += MP; TODO:
        }

        public override void EndEffect()
        {
            // Screen.player.MagicPower -= MP; TODO:
        }
    }
}
