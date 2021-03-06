using Terraria.ID;
using Terraria.ModLoader;

namespace YoguContentMod.Items.Weapons.Ranged
{
    public abstract class Bow : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shoot = 10;
            item.useAmmo = AmmoID.Arrow;
            item.rare = ItemRarityID.Green;
            item.UseSound = CommonSounds.BowShot;
            item.autoReuse = true;
            item.noMelee = true;
        }
    }
}
