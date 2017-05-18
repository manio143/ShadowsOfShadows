using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShadowsOfShadows.Renderables;

namespace ShadowsOfShadows.Entities
{
    [System.Xml.Serialization.XmlInclude(typeof(Wall))]
    [System.Xml.Serialization.XmlInclude(typeof(Chest))]
    public abstract class Thing : Entity
    {
        public Thing()
        {

        }

        public Thing(IRenderable renderable) : base(renderable)
        {
        }
    }
}
