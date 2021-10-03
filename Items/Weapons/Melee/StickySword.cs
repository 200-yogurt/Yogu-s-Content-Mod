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
using YoguContentMod.Projectiles.Hostile;

namespace YoguContentMod.Items.Weapons.Melee
{
    class StickySword : YItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Sticky Sword");
            Tooltip.SetDefault("Made with the technology of his people, rlly weird stuff \nShoots yogurt balls into enemies \nHas 20% chance to shoot 3 yogurt balls on a single click");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.damage = 5;
            item.melee = true;
            item.width = 42;
            item.height = 42;
            item.useTime = 15;
            item.useAnimation = 28;
            item.useStyle = 1;
            item.knockBack = 5;
            item.value = Item.sellPrice(copper: 69);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;

            item.shoot = ModContent.ProjectileType<YogurtBall>();
            item.shootSpeed = 10;
        } 

        public override bool OnlyShootOnSwing => true;


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.Next(5) > 0)
                return false;

            float r = MathHelper.PiOver4 / 2;
            for(int i = 0; i < 3; i++)
            {
                Vector2 dir = new Vector2(speedX, speedY).RotatedBy((r - 1) * MathHelper.PiOver4 / 2);

                Projectile.NewProjectile(position, dir, ModContent.ProjectileType<YogurtBall>(), damage, knockBack, player.whoAmI);
            }

            return false;
        }
    }
}
