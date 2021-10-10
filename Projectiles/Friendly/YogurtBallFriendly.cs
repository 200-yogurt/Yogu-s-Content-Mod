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
            projectile.width = 52;
            projectile.height = 38;
        }

        public override void AI()
        {
            base.AI();
            projectile.rotation = projectile.velocity.ToRotation();

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
