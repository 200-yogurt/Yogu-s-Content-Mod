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

namespace YoguContentMod.Items.Weapons.Ranged
{
    public class StagnantBow : Bow
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Stagnant bow");
            Tooltip.SetDefault("Some kind of weird technology has something to do such transformation of proyectiles \nConverts any arrows into yogurt balls ");
        }

        public override void SetDefaults() 
        {
            base.SetDefaults();
            item.damage = 25;
            item.width = 28;
            item.height = 44;
            item.useTime = 20;
            item.useAnimation = 20;
            item.crit = 4;
            item.shootSpeed = 10;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if(type == ProjectileID.WoodenArrowFriendly)
            {
                type = ModContent.ProjectileType<YogurtBallFriendly>();
            }
            return true;
        }

        public override bool UseItem(Player player)
        {
            return true;
        }
    }
}
