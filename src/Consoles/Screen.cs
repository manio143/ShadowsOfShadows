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

        public TestItem(AllowedItem allowed) : base(allowed == AllowedItem.Multiple ? "MultipleItem" : "SingleItem", "")
        {
            Allowed = allowed;
        }
    }

    public class Screen : SadConsole.ConsoleContainer
    {
        public const int MENU_WIDTH = 15;
        public const int MESSAGES_HEIGHT = 7;

        public static MainConsole MainConsole;
        public static MessageConsole MessageConsole;
        public static MenuConsole MenuConsole;

        public Screen(int width, int height)
        {
            MainConsole = new MainConsole(width - MENU_WIDTH + 1, height - MESSAGES_HEIGHT + 2);
            MessageConsole = new MessageConsole(1, height - MESSAGES_HEIGHT + 1, width, MESSAGES_HEIGHT);
            MenuConsole = new MenuConsole(width - MENU_WIDTH, 1, MENU_WIDTH + 1, height - MESSAGES_HEIGHT + 1);

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

        public override void Update(TimeSpan delta)
        {
            base.Update(delta);
            if (MessageConsole.IsActive)
                MessageConsole.Update(delta);
            else if (MenuConsole.IsActive)
                MenuConsole.Update(delta);
            else 
                MainConsole.Update(delta);
        }

        public override void Draw(TimeSpan delta)
        {
            base.Draw(delta);
            MessageConsole.Draw(delta);
            MenuConsole.Draw(delta);
            MainConsole.Draw(delta);
        }
    }
}
