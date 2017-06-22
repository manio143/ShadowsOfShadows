using System;
using System.Linq;
using System.Reflection;
using MathNet.Numerics.Distributions;
using ShadowsOfShadows.Items;

namespace ShadowsOfShadows.Generators
{
    public class ItemGenerator
    {
        private Stable genItemDistribution = new Stable(1.5, 0.0, 1.0, 0.0);
        private DiscreteUniform armorDistribution;
        private DiscreteUniform weaponDistribution;
        private DiscreteUniform foodDistribution;
        private DiscreteUniform potionDistribution;

        private Type[] armorTypes;
        private Type[] weaponTypes;
        private Type[] foodTypes;
        private Type[] potionTypes;

        public ItemGenerator()
        {
            var assembly = GetType().Assembly;
            var items = assembly.GetTypes().Where(t => t.GetCustomAttribute<ItemTypeAttribute>() != null && !t.IsAbstract).ToList();

            armorTypes = items.Where(t => t.GetCustomAttribute<ItemTypeAttribute>().Type == ItemType.Armor).ToArray();
            weaponTypes = items.Where(t => t.GetCustomAttribute<ItemTypeAttribute>().Type == ItemType.Weapon).ToArray();
            foodTypes = items.Where(t => t.GetCustomAttribute<ItemTypeAttribute>().Type == ItemType.Food).ToArray();
            potionTypes = items.Where(t => t.GetCustomAttribute<ItemTypeAttribute>().Type == ItemType.Potion).ToArray();

            armorDistribution = new DiscreteUniform(0, armorTypes.Length - 1);
            weaponDistribution = new DiscreteUniform(0, weaponTypes.Length - 1);
            foodDistribution = new DiscreteUniform(0, foodTypes.Length - 1);
            potionDistribution = new DiscreteUniform(0, potionTypes.Length - 1);
        }


        public Item GenerateItem()
        {
            var rnd = genItemDistribution.Sample();
            if (rnd >= 0 && rnd < 1)
                return GenerateFood();
            else if (rnd >= -1 && rnd < 0)
                return GeneratePotion();
            else if (rnd < -1)
                return GenerateWeapon();
            else return GenerateArmor();
        }

        private Wearable GenerateArmor()
        {
            var index = armorDistribution.Sample();
            return (Wearable)Activator.CreateInstance(armorTypes[index]);
        }

        private Weapon GenerateWeapon()
        {
            var index = weaponDistribution.Sample();
            return (Weapon)Activator.CreateInstance(weaponTypes[index]);
        }

        private Consumable GeneratePotion()
        {
            var index = potionDistribution.Sample();
            return (Consumable)Activator.CreateInstance(potionTypes[index]);
        }

        private Consumable GenerateFood()
        {
            var index = foodDistribution.Sample();
            return (Consumable)Activator.CreateInstance(foodTypes[index]);
        }
    }
}