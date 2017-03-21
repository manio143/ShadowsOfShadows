using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using ShadowsOfShadows.Helpers;

namespace ShadowsOfShadows.Consoles
{
	public class MessageConsole : SadConsole.Consoles.Console
	{
		List<SadConsole.Game.GameObject> consoleObjects = new List<SadConsole.Game.GameObject> ();

		public MessageConsole(int posX, int poxY, int width, int height)
			:base(width, height)
		{
			this.Position = new Point (posX, poxY);
		}

		public void PrintMessage(string message)
		{
			consoleObjects.Clear ();
			var msgObject = ConsoleObjects.CreateFromString (message);
			msgObject.Position = this.Position + new Point (1, 1);
			consoleObjects.Add (msgObject);
		}

		public override void Render ()
		{
			base.Render ();
			foreach (var co in consoleObjects)
				co.Render ();
		}
	}
}

