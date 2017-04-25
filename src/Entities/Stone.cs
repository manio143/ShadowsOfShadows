using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShadowsOfShadows.Renderables;

namespace ShadowsOfShadows.Entities
{
    public class Stone : Thing
    {
        public Stone(IRenderable renderable) : base(renderable)
        {
        }
    }
}
