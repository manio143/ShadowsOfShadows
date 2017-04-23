using System;


namespace ShadowsOfShadows.Items
{
    public class RegenerationConsumable : Consumable
    {
        public int RegenerationValue { get; private set;}

        public RegenerationConsumable(int regen)
        {
            RegenerationValue = regen;
        }

        public override void Use()
        {
            //Screen.player.Health = Math.Min(Screen.player.Health + RegenerationValue, Screen.player.MaxHealth); TODO:
        }
    }
}
