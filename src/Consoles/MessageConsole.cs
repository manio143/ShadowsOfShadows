using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using SadConsole.GameHelpers;

using ShadowsOfShadows.Helpers;

namespace ShadowsOfShadows.Consoles
{
	public class MessageConsole : SadConsole.Console
	{
		List<GameObject> consoleObjects = new List<GameObject> ();

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

		public override void Draw(TimeSpan delta)
		{
			base.Draw (delta);
			foreach (var co in consoleObjects)
				co.Draw (delta);
		}
	}
}

