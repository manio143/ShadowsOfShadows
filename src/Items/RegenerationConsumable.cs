using System;


namespace ShadowsOfShadows.Items
{
    [System.Xml.Serialization.XmlInclude(typeof(Apple))]
    public class RegenerationConsumable : Consumable
    {
        public int RegenerationValue { get; /*private*/ set;}

        public RegenerationConsumable () : base()
        {

        }

        public RegenerationConsumable(String name, int regen) :base(name, "Health regeneration: " + regen + "\n") 
        {
            RegenerationValue = regen;
        }

        public override void Use()
        {
            Screen.MainConsole.Player.Health = Math.Min(Screen.MainConsole.Player.Health + RegenerationValue, Screen.MainConsole.Player.MaxHealth);
        }
    }
}
