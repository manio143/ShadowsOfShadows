using System;

using SadConsole.GameHelpers;
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

