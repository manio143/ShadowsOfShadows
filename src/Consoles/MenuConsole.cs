using System;

using Microsoft.Xna.Framework;

using SadConsole;
using ShadowsOfShadows.Helpers;

using ShadowsOfShadows.Entities;

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
                qm.Rows = qm.AnswersCount;
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
                    PrintPlayerStats();
                    break;
                case MainMenuOptions.Quit:
                    SadConsole.Game.Instance.Exit();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void PrintPlayerStats()
        {
            PrintMessage(
                "STATS\n\n" +
                "HP       " + Screen.MainConsole.Player.Health + "\n" +
                "Mana     " + Screen.MainConsole.Player.Mana + "\n" +
                "AP       " + Screen.MainConsole.Player.AttackPower + "\n" +
                "MP       " + Screen.MainConsole.Player.MagicPower + "\n" +
                "DP       " + Screen.MainConsole.Player.DefencePower + "\n" +
                "Level    " + Screen.MainConsole.Player.Level + "\n" +
                "\n"
            );
        }

        public void OpenChest(Chest chest)
        {
            throw new NotImplementedException();
        }
    }
}