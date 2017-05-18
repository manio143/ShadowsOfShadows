using System;
using System.Xml.Serialization;

using SadConsole.GameHelpers;

namespace ShadowsOfShadows.Renderables
{
    [System.Xml.Serialization.XmlInclude(typeof(ConsoleRenderable))]
    public class IRenderable
    {
        [XmlIgnore]
        public GameObject ConsoleObject { get; set; }
    }
}

