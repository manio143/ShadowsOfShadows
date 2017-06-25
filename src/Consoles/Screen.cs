using System;
using System.ComponentModel;
using SadConsole.Input;
using ShadowsOfShadows.Consoles;
using ShadowsOfShadows.Entities;
using ShadowsOfShadows.Items;
using ShadowsOfShadows.Renderables;

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
        public const int MENU_WIDTH = 20;
        public const int MESSAGES_HEIGHT = 7;

        public static MainConsole MainConsole;
        public static MessageConsole MessageConsole;
        public static MenuConsole MenuConsole;

        private StartScreen StartScreen;
        public Screen(int width, int height)
        {
            MainConsole = new MainConsole(width - MENU_WIDTH - 1, height - MESSAGES_HEIGHT);
            MessageConsole = new MessageConsole(1, height - MESSAGES_HEIGHT + 1, width, MESSAGES_HEIGHT);
            MenuConsole = new MenuConsole(width - MENU_WIDTH, 1, MENU_WIDTH + 1, height - MESSAGES_HEIGHT + 1);

            StartScreen = new StartScreen(width + 2, height + 2);
        }

        public override bool ProcessKeyboard(Keyboard state)
        {
            if (StartScreen.IsActive)
                if (StartScreen.ProcessKeyboard(state))
                    return true;
            if (MessageConsole.IsActive)
                if (MessageConsole.ProcessKeyboard(state))
                    return true;
            if (MenuConsole.IsActive)
                if (MenuConsole.ProcessKeyboard(state))
                    return true;
            return MainConsole.ProcessKeyboard(state);
        }

        public override void Update(TimeSpan delta)
        {
            base.Update(delta);
            if (StartScreen.IsActive)
            {
                StartScreen.Update(delta);
                if (StartScreen.Blocking)
                    return;
            }
            if (MessageConsole.IsActive)
            {
                MessageConsole.Update(delta);
                if (MessageConsole.Blocking)
                    return;
            }
            if (MenuConsole.IsActive)
            {
                MenuConsole.Update(delta);
                if (MenuConsole.Blocking)
                    return;
            }
            MainConsole.Update(delta);
        }

        public override void Draw(TimeSpan delta)
        {
            base.Draw(delta);
            if (StartScreen.IsActive)
                StartScreen.Draw(delta);
            else
            {
                MessageConsole.Draw(delta);
                MenuConsole.Draw(delta);
                MainConsole.Draw(delta);
            }
        }
    }
}
