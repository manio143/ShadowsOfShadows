using SadConsole;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using ShadowsOfShadows.Entities;
using ShadowsOfShadows.Renderables;
using ShadowsOfShadows.TestData;
using Keyboard = SadConsole.Input.Keyboard;

namespace ShadowsOfShadows.Consoles
{
	public class MainConsole : Console
	{
	    public Player Player { get; private set; }

		private Point Middle { get; }

		private Room testRoom = TestRooms.Room1;
		public MainConsole (int width, int height) : base(width, height)
		{
		    Player = new Player("Player");
			Player.Transform.Position = new Point(1,1);

			Middle = new Point(Width/2, Height/2);
		}

		public override void Draw (System.TimeSpan delta)
		{
			base.Draw (delta);

			var playerObject = Player.Renderable.ConsoleObject;
			playerObject.Position = Middle;
			playerObject.Draw(delta);

			foreach (var entity in testRoom.Entities) {
				var consoleObject = entity.Renderable.ConsoleObject;
				consoleObject.Position = entity.Transform.Position - Player.Transform.Position + Middle;
				if(consoleObject.Position.X < Width && consoleObject.Position.Y < Height)
					consoleObject.Draw (delta);
			}
		}

	    public override bool ProcessKeyboard(Keyboard info)
	    {
	        if(info.IsKeyPressed(Keys.Escape))
	            Screen.MenuConsole.OpenMainMenu();

	        return true;
	    }
	}
}
