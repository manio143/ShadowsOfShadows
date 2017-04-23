using System;

using ShadowsOfShadows.Consoles;

namespace ShadowsOfShadows
{
	public class Screen : SadConsole.ConsoleContainer
	{
		const int MENU_WIDTH = 15;
		const int MESSAGES_HEIGHT = 7;

		public static MainConsole mainConsole;
        public static MessageConsole msgConsole;
        public static MenuConsole menuConsole;

		public Screen (int width, int height)
		{
			mainConsole = new MainConsole (width - MENU_WIDTH + 1, height - MESSAGES_HEIGHT + 2);
			msgConsole = new MessageConsole (1, height - MESSAGES_HEIGHT + 1, width, MESSAGES_HEIGHT);
			menuConsole = new MenuConsole (width - MENU_WIDTH, 1, MENU_WIDTH + 1, height - MESSAGES_HEIGHT + 1);

			Children.Add (mainConsole);
			Children.Add (msgConsole);
			Children.Add (menuConsole);

			msgConsole.PrintMessage ("This is a message\nAnd with line breaks");
		}
	}
}

