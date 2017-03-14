using System;

using SadConsole.Game;
using SadConsole.Consoles;


namespace ShadowsOfShadows.Helpers
{
	public static class ConsoleObjects
	{

		public static GameObject CreateFromChar(char c) {
			var obj = new GameObject();
			var text = new AnimatedTextSurface ("deafult", 1, 1);
			new SurfaceEditor (text.CreateFrame ()).Print (0, 0, c.ToString());
			obj.Animation = text;
			return obj;
		}

	}
}

