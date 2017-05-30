using System;


namespace ShadowsOfShadows.Items
{
    public class Bow : Weapon
    {
		public Bow() : base("Bow") { }

        public Bow(int ap, int mp) : base("Bow", ap, mp) { }

        public override void Equip()
        {
            base.Equip();
            // Add archery skill TODO:
        }

        public override void UnEquip()
        {
            base.UnEquip();
            // Delete skill TODO:
        }
    }
}
