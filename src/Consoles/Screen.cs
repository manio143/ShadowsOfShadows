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

    public class TestItem : Item
    {
        public override AllowedItem Allowed { get; }

        public override bool IsLike(Item item)
        {
            return item is TestItem;
        }

        private string str;

        public TestItem(AllowedItem allowed) : base("Test", "Stat1")
        {
            Allowed = allowed;
            if (allowed == AllowedItem.Multiple)
                str = "MultipleItem";
            else
                str = "SingleItem";
        }

        public override string ToString()
        {
            return str;
        }
    }

    public class Screen : SadConsole.ConsoleContainer
    {
        const int MENU_WIDTH = 15;
        const int MESSAGES_HEIGHT = 7;

        public static MainConsole MainConsole;
        public static MessageConsole MessageConsole;
        public static MenuConsole MenuConsole;

        public Screen(int width, int height)
        {
            MainConsole = new MainConsole(width - MENU_WIDTH + 1, height - MESSAGES_HEIGHT + 2);
            MessageConsole = new MessageConsole(1, height - MESSAGES_HEIGHT + 1, width, MESSAGES_HEIGHT);
            MenuConsole = new MenuConsole(width - MENU_WIDTH, 1, MENU_WIDTH + 1, height - MESSAGES_HEIGHT + 1);

            Children.Add(MainConsole);
            Children.Add(MessageConsole);
            Children.Add(MenuConsole);

            MessageConsole.PrintMessageAndWait("This is a message\nAnd with line breaks");
            MessageConsole.AskQuestion("Co mi powiesz?", typeof(TestEnum)).PostProcessing =
                (m) =>
                {
                    var chest = new Chest(new ConsoleRenderable('c'), 0,
                        new[]
                        {
                            new TestItem(AllowedItem.Multiple), new TestItem(AllowedItem.Multiple),
                            new TestItem(AllowedItem.Single), new TestItem(AllowedItem.Single)
                        });
                    MenuConsole.OpenChest(chest);
                };
        }

        public override bool ProcessKeyboard(Keyboard state)
        {
            if (MessageConsole.IsActive)
                if (MessageConsole.ProcessKeyboard(state))
                    return true;
            if (MenuConsole.IsActive)
                if (MenuConsole.ProcessKeyboard(state))
                    return true;
            return MainConsole.ProcessKeyboard(state);
        }
    }
}
