using SConsole = SadConsole.Consoles.Console;
using SadConsole;

namespace ShadowsOfShadows
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Engine.Initialize ("C64.font", 80, 25);
			Engine.EngineStart += (sender, e) => {
				var console = (SConsole)Engine.ActiveConsole;
				console.Print (1, 1, "Hello World!");
			};
			Engine.Run ();
		}
	}
}
