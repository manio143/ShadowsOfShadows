using System;
using System.Collections.Generic;

using ShadowsOfShadows.Renderables;
using ShadowsOfShadows.Items;
using ShadowsOfShadows.Consoles;

namespace ShadowsOfShadows.Entities
{
    public class Chest : Openable
    {
        public List<Item> Items { get; }

        public Chest() : base()
        {

        }

        public Chest(IRenderable rendarable, int lockDificulty, IEnumerable<Item> items) : base(rendarable, lockDificulty)
        {
            Items = new List<Item>(items);
        }

        public override void Interact()
        {
            if (CheckOpened())
                Screen.MenuConsole.OpenChest(this);
        }
        public override char GetEntityChar()
        {
            return 'c';
        }

    }
}
