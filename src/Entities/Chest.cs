using System;
using System.Collections.Generic;

using ShadowsOfShadows.Renderables;
using ShadowsOfShadows.Items;
using ShadowsOfShadows.Consoles;

namespace ShadowsOfShadows.Entities
{
    public class Chest : Openable
    {
        List<Item> Items { get; set; }

        public Chest(IRenderable rendarable, int lockDificulty, List<Item> items) : base(rendarable, lockDificulty)
        {
            Items = items;
        }

        public override void Interact()
        {
            if(CheckOpened())
            {
                //TODO: change current console to menu console
                Screen.menuConsole.OpenChest(this);
            }
        }
    }
}
