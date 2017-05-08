using System;

using SadConsole.GameHelpers;
using ShadowsOfShadows.Helpers;

namespace ShadowsOfShadows.Renderables
{
	public class ConsoleRenderable : IRenderable
	{
		public ConsoleRenderable (char symbol)
		{
			ConsoleObject = ConsoleObjects.CreateFromChar(symbol);
		}

	    public ConsoleRenderable(int glyph)
	    {
	        ConsoleObject = ConsoleObjects.CreateFromGlyph(glyph);
	    }

		public GameObject ConsoleObject { get;} 
	}
}

