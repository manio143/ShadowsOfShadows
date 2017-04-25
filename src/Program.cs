using SConsole = SadConsole.Console;
using SadConsole;

using ShadowsOfShadows.Consoles;

namespace ShadowsOfShadows
{
	class MainClass
	{
		const int WIDTH = 80;
		const int HEIGHT = 40;

		public static void Main (string[] args)
		{
			SadConsole.Game.Create("C64.font", WIDTH, HEIGHT);
			SadConsole.Game.OnInitialize = Initialize;
			SadConsole.Game.Instance.Run();
		}

		public static void Initialize()
		{
		    var screen = new Screen(WIDTH, HEIGHT);
		    Global.CurrentScreen = screen;
            Global.FocusedConsoles.Set(screen);
		}
	}
}
