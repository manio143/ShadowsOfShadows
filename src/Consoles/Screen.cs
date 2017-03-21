using System;

using ShadowsOfShadows.Consoles;

namespace ShadowsOfShadows
{
	public class Screen : SadConsole.ConsoleContainer
	{
		const int MENU_WIDTH = 15;
		const int MESSAGES_HEIGHT = 6;

		MainConsole mainConsole;
		MessageConsole msgConsole;
		MenuConsole menuConsole;

		public Screen (int width, int height)
		{
			mainConsole = new MainConsole (width - MENU_WIDTH, height - MESSAGES_HEIGHT);
			msgConsole = new MessageConsole (0, height - MESSAGES_HEIGHT - 1, width, MESSAGES_HEIGHT);
			menuConsole = new MenuConsole (width - MENU_WIDTH - 1, 0, MENU_WIDTH, height);

			Children.Add (mainConsole);
			Children.Add (msgConsole);
			Children.Add (menuConsole);

			msgConsole.PrintMessage ("This is a message");
		}
	}
}

