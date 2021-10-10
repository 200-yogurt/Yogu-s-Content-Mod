using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YoguContentMod.Items.Weapons.Ranged
{
    public class DrippyGun : YItem
    {
        bool doubleShoot;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Drippy Gun");
            Tooltip.SetDefault("Has 15% chance to shoot the double of bullets \nThis little gun is familiar..."); // se refiere al clockwork xd
        }

        public override void SetDefaults()
        {
            item.damage = 11;
            item.useAnimation = 12;
            item.useTime = 4;
            item.reuseDelay = 14;
            item.width = 32;
            item.height = 32;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.autoReuse = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item31;
            item.rare = ItemRarityID.Green;
            item.shoot = 10;
            item.shootSpeed = 7;
            item.crit = 2; 
            item.useAmmo = AmmoID.Bullet;
        }

        public override ModItem NewInstance(Item itemClone)
        {
            return base.NewInstance(itemClone);
        }

        public override bool CanUseItem(Player player)
        {
            doubleShoot = Main.rand.NextFloat(100) <= 15;
            if (doubleShoot)
            {
                item.useTime = 2;
            }
            else
            {
                item.useTime = 4;
            }
            return base.CanUseItem(player);
        }

        public override float UseTimeMultiplier(Player player)
        {
            float value = base.UseTimeMultiplier(player);
            Main.NewText(doubleShoot);
            return value;
        }

        public override bool UseItem(Player player)
        {
            return true;
        }
    }
}
