using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShadowsOfShadows.Renderables;

namespace ShadowsOfShadows.Entities
{
    public abstract class Thing : Entity
    {
        public Thing() { }

        public Thing(char c) : base(c) { }

        public Thing(IRenderable renderable) : base(renderable) { }
    }
}
