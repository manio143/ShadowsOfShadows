using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShadowsOfShadows.Renderables;

namespace ShadowsOfShadows.Entities
{
    [Serializable]
    public class Wall : Thing
    {
        /* For serialization */
        public Wall () : base()
        {

        }

        public Wall(IRenderable renderable) : base(renderable)
        {
        }

        public override char GetEntityChar()
        {
            return (char)219;
        }
    }
}
