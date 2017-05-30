using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShadowsOfShadows.Renderables;
using Microsoft.Xna.Framework;

namespace ShadowsOfShadows.Entities
{
    public class Wall : Thing
    {
        public Wall(IRenderable renderable) : base(renderable)
        {
        }

		public Wall(Point position) : this (new ConsoleRenderable(219))
		{
			Transform.Position = position;
		}
    }
}
