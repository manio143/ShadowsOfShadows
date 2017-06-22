using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShadowsOfShadows.Renderables;
using Microsoft.Xna.Framework;

namespace ShadowsOfShadows.Entities
{
    [Serializable]
    public class Wall : Thing
    {
        /* For serialization */
        public Wall() : base((char)219) { }

        public Wall(IRenderable renderable) : base(renderable) { }

        public Wall(Point position) : this(new ConsoleRenderable(219))
        {
            Transform.Position = position;
        }
    }
}
