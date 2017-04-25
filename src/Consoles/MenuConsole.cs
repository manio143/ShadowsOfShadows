using System;

using Microsoft.Xna.Framework;
using SadConsole;
using ShadowsOfShadows.Helpers;

namespace ShadowsOfShadows.Consoles
{
    public enum MainMenuOptions
    {
        [Display("Equipment")]
        Equipment,

        [Display("Save Game")]
        SaveGame,

        [Display("Load Game")]
        LoadGame,

        [Display("Settings")]
        Settings,

        CloseMenu,

        [Display("Quit")]
        Quit
    }

    public class MenuConsole : MessageConsole
    {
        public MenuConsole(int posX, int posY, int width, int height)
            : base(posX, posY, width, height)
        {
            ClearInactive = false;
        }

        protected override void PrintMessage(Message message)
        {
            if (message is QuestionMessage)
            {
                var qm = (QuestionMessage) message;
                qm.Rows = qm.AnswerCount;
            }
            base.PrintMessage(message);
        }

        public void OpenMainMenu()
        {
            var menu = AskQuestion("MENU", typeof(MainMenuOptions));
            menu.PostProcessing = MainMenuChoice;
            menu.DefaultAnswer = MainMenuOptions.CloseMenu;
        }

        private void MainMenuChoice(Message msg)
        {
            var qm = msg as QuestionMessage;
            switch ((MainMenuOptions) qm.Result)
            {
                case MainMenuOptions.Equipment:
                    PrintMessage("EQUIPMENT");
                    //TODO: When equipment is done display it
                    break;
                case MainMenuOptions.SaveGame:
                    //TODO: Show slot options
                    break;
                case MainMenuOptions.LoadGame:
                    //TODO: Show slot options
                    break;
                case MainMenuOptions.Settings:
                    //TODO: Show settings (should we have any)
                    break;
                case MainMenuOptions.CloseMenu:
                    PrintMessage("");
                    break;
                case MainMenuOptions.Quit:
                    SadConsole.Game.Instance.Exit();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

