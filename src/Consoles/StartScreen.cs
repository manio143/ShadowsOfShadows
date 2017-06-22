using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ShadowsOfShadows.Entities;
using ShadowsOfShadows.Helpers;
using ShadowsOfShadows.Physics;
using ShadowsOfShadows.Renderables;
using ShadowsOfShadows.TestData;
using ShadowsOfShadows.Serialization;
using Console = SadConsole.Console;
using IUpdateable = ShadowsOfShadows.Entities.IUpdateable;
using Keyboard = SadConsole.Input.Keyboard;
using System.Collections.Generic;
using SadConsole.GameHelpers;
using ShadowsOfShadows.Generators;

namespace ShadowsOfShadows.Consoles
{
    public enum StartScreenQuestion
    {
        [Display(" NEW GAME ")]
        NewGame,
        [Display(" LOAD GAME")]
        LoadGame,
        [Display("   QUIT   ")]
        Quit
    }
    public class StartScreen : MenuConsole
    {
        const string title =
            "  sssss hh   hh     A     DDD   ooooo W            W  sssss\n" +
            " ss     hh   hh    A A    D  D  o   o  W          W  ss    \n" +
            " sssss  hhhhhhh   A   A   D   D o   o  W    W     W  sssss \n" +
            "     ss hh   hh  AAAAAAA  D  D  o   o   W  W W  W        ss\n" +
            " sssss  hh   hh AA     AA DDD   ooooo    WW   WW     sssss \n" +
            "                                                           \n" +
            "                      ooooo   FFFFFFF                      \n" +
            "                      o   o   FF                           \n" +
            "                      o   o   FFFF                         \n" +
            "                      ooooo   FF                           \n" +
            "                                                           \n" +
            "  sssss hh   hh     A     DDD   ooooo W            W  sssss\n" +
            " ss     hh   hh    A A    D  D  o   o  W          W  ss    \n" +
            " sssss  hhhhhhh   A   A   D   D o   o  W    W     W  sssss \n" +
            "     ss hh   hh  AAAAAAA  D  D  o   o   W  W W  W        ss\n" +
            " sssss  hh   hh AA     AA DDD   ooooo    WW   WW     sssss \n";

        public StartScreen(int width, int height) : base(0, 0, width, height)
        {
            PrintStartScreen();
        }

        private void PrintStartScreen()
        {
            PrintMessageWithTimeout("", 1); //delay question.Create()
            var question = AskQuestion(title, typeof(StartScreenQuestion));
            question.PostProcessing = (m) =>
            {
                var answer = (StartScreenQuestion)((QuestionMessage)m).Result;
                switch (answer)
                {
                    case StartScreenQuestion.NewGame:
                        PrintTutorial();
                        break;
                    case StartScreenQuestion.LoadGame:
                        LoadGame();
                        break;
                    case StartScreenQuestion.Quit:
                        SadConsole.Game.Instance.Exit();
                        break;
                }
            };
            question.TextPositionOffset = new Point(Width/2 - 32, 4);
            question.ChoicePositionOffset = new Point(Width/2 - 10, 25);
        }

        private void PrintTutorial()
        {
            Screen.MessageConsole.PrintMessageAndWait("Welcome to the dungeon!\nYou're here to save the princess who has been kidnapped.");
            Screen.MessageConsole.PrintMessageAndWait("To move around use the arrow keys on you keyboard.\nTo interract with chests (c) and doors (|) press [E].\nShould they be locked, try [T] to lockpick.");
            Screen.MessageConsole.PrintMessageAndWait("Use [Space] to engage with a monster (M).");
            Screen.MessageConsole.PrintMessageAndWait("Good luck finding the princess " + ((char)1));
        }

        public new void LoadGame()
		{
            var message = AskSaveSlot();
            message.ChoicePositionOffset = new Point(Width/2 - 8, 23);
            message.PostProcessing += (msg) => {
                var slot = (SaveSlot)(msg as QuestionMessage).Result;
                if(slot == SaveSlot.None || !Serialization.Serializer.SaveExists(slot))
                    PrintStartScreen();
                Screen.MenuConsole.PrintPlayerStats();
            };
		}
    }
}