using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YoguContentMod.Projectiles.Friendly
{
    public class YogurtBallFriendly : YProjectile
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.melee = true;
            projectile.width = 20;
            projectile.height = 20;
        }

        public override void Kill(int timeLeft)
        {
            int clouds = Main.rand.Next(1, 3);
            for(int i = 0; i < clouds; i++)
            {
                Vector2 dir = (Main.rand.NextFloat(MathHelper.TwoPi * Main.rand.NextFloat(3, 8))).ToRotationVector2() * 4;
                SpawnProjectile(projectile.Center, dir, ModContent.ProjectileType<YogurtBallCloud>());
            }
        }

        public override void AI()
        {
            base.AI();
            projectile.rotation = projectile.velocity.ToRotation();
            projectile.velocity.Y += 0.1f;

            if (projectile.frameCounter++ > 3)
            {
                projectile.frameCounter = 0;
                if (projectile.frame++ >= 4)
                {
                    projectile.frame = 0;
                }
            }
        }
    }
}
