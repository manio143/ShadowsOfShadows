using System;

using ShadowsOfShadows.Renderables;
using ShadowsOfShadows.Physics;
using System.Xml.Serialization;

namespace ShadowsOfShadows.Entities
{
    public abstract class Entity
	{
		public Transform Transform { get; set;}

        [YamlDotNet.Serialization.YamlIgnore]
		public IRenderable Renderable { get; set; }

        /* For serialization */
        public Entity() { }

        public Entity(char c)
        {
            Renderable = new ConsoleRenderable(c);
        }

		public Entity ( IRenderable renderable)
		{
			Transform = new Transform ();
            Renderable = renderable;
		}
	}
}
