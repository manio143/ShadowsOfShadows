using System;
using Microsoft.Xna.Framework;
using SadConsole.GameHelpers;
using ShadowsOfShadows.Helpers;

namespace ShadowsOfShadows.Renderables
{
    [Serializable]
    public class ConsoleRenderable : IRenderable
	{
        /* For serialization */
        public ConsoleRenderable()
        {

        }

		public ConsoleRenderable (char symbol, Color color = new Color())
		{
			ConsoleObject = ConsoleObjects.CreateFromChar(symbol, color);
		}

	    public ConsoleRenderable(int glyph, Color color = new Color())
	    {
	        ConsoleObject = ConsoleObjects.CreateFromGlyph(glyph, color);
	    }

		//public GameObject ConsoleObject { get;} 
	}
}

