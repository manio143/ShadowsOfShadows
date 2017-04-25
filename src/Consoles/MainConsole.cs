using SadConsole;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using ShadowsOfShadows.Entities;
using ShadowsOfShadows.Renderables;

using Keyboard = SadConsole.Input.Keyboard;

namespace ShadowsOfShadows.Consoles
{
	public class TestEntity : Entity {
        public TestEntity(): base(new ConsoleRenderable('A')) { }
    }

	public class MainConsole : Console
	{
		private Room testRoom = new Room (new[]{ new TestEntity () });
		public MainConsole (int width, int height) : base(width, height)
		{
			testRoom.Entities.First ().Renderable = new ConsoleRenderable ('A');
			testRoom.Entities.First ().Transform.Position = new Point (1,1);
		}

		public override void Draw (System.TimeSpan delta)
		{
			base.Draw (delta);

			foreach (var entity in testRoom.Entities) {
				var consoleObject = entity.Renderable.ConsoleObject;
				consoleObject.Position = entity.Transform.Position;
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
