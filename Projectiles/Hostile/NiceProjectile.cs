using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YoguContentMod.Projectiles.Hostile
{
    public class NiceProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nice Projectile");            
        }

        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 28;
            projectile.alpha = 128;
            projectile.penetrate = 1;
            projectile.timeLeft = 360;
            projectile.hostile = true;
            projectile.tileCollide = true;
            projectile.magic = true;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            Player player = Main.LocalPlayer;
            projectile.rotation = projectile.velocity.ToRotation();
            projectile.velocity = Vector2.Lerp(projectile.velocity, Vector2.Normalize(player.Center - projectile.Center) * 14f, 0.1f);
            projectile.velocity = Vector2.Normalize(player.Center - projectile.Center) * 8f;
            projectile.rotation += 0.4f * (float)projectile.direction;
        }
    }
}
