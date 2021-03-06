﻿using System;
using System.Xml.Serialization;

using ShadowsOfShadows.Consoles;

namespace ShadowsOfShadows.Items
{
    [ItemType(ItemType.Potion)]
    public class DefensePotion : TimedConsumable
    {
        [XmlIgnore]
        public int DP { get; private set; }
        public DefensePotion() : base("Defense Potion", "Defense power 3\n", TimeSpan.FromSeconds(10))
        {
            DP = 3;
        }

        public override void EndEffect()
        {
            Screen.MainConsole.Player.DefencePower -= DP;
        }

        public override void Use()
        {
            base.Use();
            Screen.MainConsole.Player.DefencePower += DP;
        }
    }
}
