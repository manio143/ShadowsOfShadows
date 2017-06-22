using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using SadConsole;
using ShadowsOfShadows.Helpers;

using ShadowsOfShadows.Entities;
using ShadowsOfShadows.Serialization;

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
            PrintPlayerStats();
        }

        protected override void PrintMessage(Message message)
        {
            if (message.IsInstanceOfGenericType(typeof(ChoiceMessage<>)))
            {
                dynamic qm = message;
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
                    OpenEquipment();
                    break;
				case MainMenuOptions.SaveGame:
					SaveGame();
                    break;
				case MainMenuOptions.LoadGame:
					LoadGame();
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

        private string AddPadding(string s, int value)
        {
            return s.PadLeft(value);
        }

        public void PrintPlayerStats()
        {
            const int labelLength = 9;
            int remaining = Screen.MENU_WIDTH - labelLength - 3; // dlugosc etykiety = 9
            PrintMessage(
                "STATS\n\n" +
                "HP       " + AddPadding(Screen.MainConsole.Player.Health.ToString(), remaining) + "\n" +
                "Mana     " + AddPadding(Screen.MainConsole.Player.Mana.ToString(), remaining) + "\n" +
                "AP       " + AddPadding(Screen.MainConsole.Player.AttackPower.ToString(), remaining) + "\n" +
                "MP       " + AddPadding(Screen.MainConsole.Player.MagicPower.ToString(), remaining) + "\n" +
                "DP       " + AddPadding(Screen.MainConsole.Player.DefencePower.ToString(), remaining) + "\n" +
                "Level    " + AddPadding(Screen.MainConsole.Player.Level.ToString(), remaining) + "\n" +
                "\n"
                +
                Screen.MainConsole.Player.GetPlayerBuffs()
            );
        }

		public void SaveGame()
		{
			var message = AskQuestion ("", typeof(SaveSlot));
			message.PostProcessing = msg => { 
				var slot = ((QuestionMessage)msg).Result;
				Serialization.Serializer.Save ((SaveSlot)slot, Screen.MainConsole.State);
				Screen.MessageConsole.PrintMessageWithTimeout("Game saved.", TimeoutMessage.GENERAL_TIMEOUT);
				OpenMainMenu();
			};
		}

		public void LoadGame()
		{
            var message = AskQuestion("", typeof(SaveSlot));
            message.PostProcessing = msg => {
                var slot = ((QuestionMessage)msg).Result;
                var gS = Serialization.Serializer.Load((SaveSlot)slot);

				Screen.MainConsole.State = gS;

                Screen.MainConsole.Update(new TimeSpan());

				Screen.MessageConsole.PrintMessageWithTimeout("Game loaded.", TimeoutMessage.GENERAL_TIMEOUT);
                OpenMainMenu();
            };
		}

        public ChestMessage OpenChest(Chest chest)
        {
            var message = new ChestMessage(chest);
            PrintMessageAndWait(message);
			message.PostProcessing = msg => {
				Screen.MessageConsole.PrintMessage("");
				PrintPlayerStats ();
			};
            return message;
        }

        public EquipmentMessage OpenEquipment()
        {
            var message = new EquipmentMessage();
            PrintMessageAndWait(message);
			message.PostProcessing = msg => {
				Screen.MessageConsole.PrintMessage("");
				OpenMainMenu ();
			};
           	return message;
        }
    }
}