using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YoguContentMod.Projectiles.Friendly;

namespace YoguContentMod.Items.Weapons.Melee
{
    public class StickySword : YItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Sticky Sword");
            Tooltip.SetDefault("Made with the technology of his people, really weird stuff \nShoots yogurt balls into enemies \nHas 20% chance to shoot 3 yogurt balls on a single click");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.damage = 28;
            item.melee = true;
            item.width = 56;
            item.height = 58;
            item.useTime = 15;
            item.useAnimation = 28;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 5;
            item.crit = 3;
            item.value = Item.sellPrice(silver: 20);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;

            item.shoot = ModContent.ProjectileType<YogurtBallFriendly>();
            item.shootSpeed = 10;
        } 

        public override bool OnlyShootOnSwing => true;

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.Next(5) > 0)
                return false;

            float r = MathHelper.PiOver4 / 16;
            damage = (int)(damage * 24f / item.damage);
            for(int i = -1; i <= 1; i++)
            {
                Vector2 dir = new Vector2(speedX, speedY).RotatedBy(i * r);

                Projectile.NewProjectile(position, dir, type, damage, knockBack, player.whoAmI);
            }

            return false;
        }
    }
}
