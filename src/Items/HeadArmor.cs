﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public abstract class HeadArmor : Wearable
    {
        public int DP { get; private set; }

        public HeadArmor(String name, int dp) : base(name, "Defence Power " + dp.ToString() + "\n")
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
