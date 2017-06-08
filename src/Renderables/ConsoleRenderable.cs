using System;
using Microsoft.Xna.Framework;
using SadConsole.GameHelpers;
using ShadowsOfShadows.Helpers;

namespace ShadowsOfShadows.Renderables
{
    public class ConsoleRenderable : IRenderable
	{
		internal int symbol;
		internal Color color;
		public ConsoleRenderable (char symbol, Color color = new Color())
		{
			this.symbol = symbol;
			this.color = color;
			ConsoleObject = ConsoleObjects.CreateFromChar(symbol, color);
		}

	    public ConsoleRenderable(int glyph, Color color = new Color())
	    {
			this.symbol = glyph;
			this.color = color;
	        ConsoleObject = ConsoleObjects.CreateFromGlyph(glyph, color);
	    }

		//public GameObject ConsoleObject { get;} 
	}
}

