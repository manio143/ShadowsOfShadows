﻿using System.Collections.Generic;
using ShadowsOfShadows.Consoles;
using ShadowsOfShadows.Renderables;
using ShadowsOfShadows.Items;

namespace ShadowsOfShadows.Entities
{
    public class TrapChest : Chest
    {
        private int Damage { get; set; }
        private bool Active { get; set; }

        public TrapChest() : base() { }

        public TrapChest(IRenderable rendarable, int lockDificulty, List<Item> items, int damage) : base(rendarable,
            lockDificulty, items)
        {
            Damage = damage;
            Active = true;
        }

        public override void Interact()
        {
            if (Active)
            {
                Active = false;
                Screen.MainConsole.Player.TakeDamage(Damage);
                Screen.MessageConsole.PrintMessageWithTimeout("It's a trap!", TimeoutMessage.SHORT_TIMEOUT);
            }

            base.Interact();
        }
    }
}