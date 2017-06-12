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
            PrintMessageWithTimeout("", 1); //delay question.Create()
            var question = AskQuestion(title, typeof(StartScreenQuestion));
            question.PostProcessing = (m) =>
            {
                var answer = (StartScreenQuestion)((QuestionMessage)m).Result;
                switch (answer)
                {
                    case StartScreenQuestion.NewGame: break;
                    case StartScreenQuestion.LoadGame:
                        LoadGame();
                        break;
                    case StartScreenQuestion.Quit:
                        SadConsole.Game.Instance.Exit();
                        break;
                }
            };

            
            question.TextPositionOffset = new Point(width/2 - 32, 4);
            question.ChoicePositionOffset = new Point(width/2 - 10, 25);
        }
        public new void LoadGame()
		{
            var message = AskQuestion("", typeof(SaveSlot));
            message.ChoicePositionOffset = new Point(Width/2 - 8, 23);
            message.PostProcessing = msg => {
                var slot = ((QuestionMessage)msg).Result;
                var gS = Serialization.Serializer.Load((SaveSlot)slot);

				Screen.MainConsole.State = gS;

                Screen.MainConsole.Update(new TimeSpan());

				Screen.MessageConsole.PrintMessageWithTimeout("Game loaded.", TimeoutMessage.GENERAL_TIMEOUT);
            };
		}
    }
}