using System;
using System.Xml.Serialization;

using SadConsole.GameHelpers;

namespace ShadowsOfShadows.Renderables
{
    public class IRenderable
    {
        [XmlIgnore]
        public GameObject ConsoleObject { get; set; }
    }
}

