using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShadowsOfShadows.Items;
using ShadowsOfShadows.Renderables;

namespace ShadowsOfShadows.Entities
{
    public class Corpse : Chest
    {
        public Corpse() : base() { }

        public Corpse(IRenderable rendarable, List<Item> items) : base(rendarable, 0, items)
        {
        }
    }
}
