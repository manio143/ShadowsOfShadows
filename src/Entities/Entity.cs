using System;

using ShadowsOfShadows.Renderables;
using ShadowsOfShadows.Physics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ShadowsOfShadows.Entities
{
    [System.Xml.Serialization.XmlInclude(typeof(Thing))]
    public abstract class Entity
	{
		public Transform Transform { get; set;}

		public IRenderable Renderable { get; set; }

        /* For serialization */
        public Entity ()
        {

        }

		public Entity ( IRenderable renderable)
		{
			Transform = new Transform ();
            Renderable = renderable;
		}

        public abstract char GetEntityChar();
	}
}
