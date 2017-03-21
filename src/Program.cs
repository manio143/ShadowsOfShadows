using SConsole = SadConsole.Consoles.Console;
using SadConsole;

using ShadowsOfShadows.Consoles;

namespace ShadowsOfShadows
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Engine.Initialize ("C64.font", 80, 25);
			Engine.EngineStart += (sender, e) => {
				Engine.ConsoleRenderStack.Clear();
				Engine.ConsoleRenderStack.Add(new Screen(80, 25));
			};
			Engine.Run ();
		}
	}
}
