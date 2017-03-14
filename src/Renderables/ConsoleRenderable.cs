using System;

using SadConsole.Game;
using ShadowsOfShadows.Helpers;

namespace ShadowsOfShadows.Renderables
{
	public class ConsoleRenderable : IRenderable
	{
		public ConsoleRenderable ( char symbol)
		{
			ConsoleObject = ConsoleObjects.CreateFromChar(symbol);
		}


		public GameObject ConsoleObject { get;} 
	}
}

