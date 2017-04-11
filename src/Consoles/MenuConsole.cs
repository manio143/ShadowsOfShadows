using System;

using Microsoft.Xna.Framework;

using ShadowsOfShadows.Helpers;

namespace ShadowsOfShadows.Consoles
{
	public class MenuConsole : BorderedConsole
	{
		public MenuConsole (int posX, int poxY, int width, int height)
			:base(width, height)
		{
			this.Position = new Point (posX, poxY);
		}
	}
}

