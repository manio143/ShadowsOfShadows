﻿using System;
using System.ComponentModel;
using SadConsole.Input;
using ShadowsOfShadows.Consoles;

namespace ShadowsOfShadows
{
    public enum TestEnum
    {
        [Display("Hello World!")]
        Hello,
        [Display("Mornin'")]
        Hello2,
        [Display("Elo Elo 3, 2, 0")]
        Elo,
        [Display("A Wojtek to gdzie?")]
        Wojtek,
        [Display("Do zobaczenia...")]
        DoZo

    }

	public class Screen : SadConsole.ConsoleContainer
	{
		const int MENU_WIDTH = 15;
		const int MESSAGES_HEIGHT = 7;

		MainConsole mainConsole;
		MessageConsole msgConsole;
		MenuConsole menuConsole;

		public Screen (int width, int height)
		{
			mainConsole = new MainConsole (width - MENU_WIDTH + 1, height - MESSAGES_HEIGHT + 2);
			msgConsole = new MessageConsole (1, height - MESSAGES_HEIGHT + 1, width, MESSAGES_HEIGHT);
			menuConsole = new MenuConsole (width - MENU_WIDTH, 1, MENU_WIDTH + 1, height - MESSAGES_HEIGHT + 1);

			Children.Add (mainConsole);
			Children.Add (msgConsole);
			Children.Add (menuConsole);

			msgConsole.PrintMessageAndWait("This is a message\nAnd with line breaks");
		    msgConsole.AskQuestion("Co mi powiesz?", typeof(TestEnum));
		}

	    public override bool ProcessKeyboard(Keyboard state)
	    {
	        if(msgConsole.IsActive)
	            if (msgConsole.ProcessKeyboard(state))
	                return true;
	        if(menuConsole.IsActive)
	            if (menuConsole.ProcessKeyboard(state))
	                return true;
	        return mainConsole.ProcessKeyboard(state);
	    }
	}
}

