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
				Engine.ConsoleRenderStack.Clear();
				Engine.ConsoleRenderStack.Add(new MainConsole(80, 25));
			};
			Engine.Run ();
		}
	}
}
