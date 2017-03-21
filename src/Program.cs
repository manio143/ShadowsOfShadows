using SConsole = SadConsole.Console;
using SadConsole;

using ShadowsOfShadows.Consoles;

namespace ShadowsOfShadows
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			SadConsole.Game.Create("C64.font", 80, 25);
			SadConsole.Game.OnInitialize = Initialize;
			SadConsole.Game.Instance.Run();
		}

		public static void Initialize()
		{
			Global.CurrentScreen = new Screen (80, 25);
		}
	}
}
