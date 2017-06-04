using System;


namespace ShadowsOfShadows.Items
{
    [ItemType(ItemType.Food)]
    public class Apple : RegenerationConsumable
    {
        public Apple() : base("Apple", 3) { }
    }

    [ItemType(ItemType.Food)]
    public class Beef : RegenerationConsumable
    {
        public Beef() : base("Beef", 5)
        {
        }
    }
}
