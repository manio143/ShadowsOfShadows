using System;

namespace ShadowsOfShadows.Items
{
    public enum ItemType
    {
        Other,
        Food,
        Potion,
        Armor,
        Weapon,
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ItemTypeAttribute : Attribute
    {
        public ItemType Type { get; }

        public ItemTypeAttribute(ItemType type)
        {
            Type = type;
        }
    }
}