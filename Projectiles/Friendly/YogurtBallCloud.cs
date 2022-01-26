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
    public class YogurtBallCloud : YProjectile
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.width = 52;
            projectile.height = 38;
            projectile.alpha = 120;
            projectile.timeLeft = 60;
        }

        public override void AI()
        {
            base.AI();
            projectile.alpha = (int)Helpers.Map(projectile.timeLeft, 0, 60, 255, 120, true);

            ref float preStartTimer = ref projectile.ai[1];

            if (preStartTimer < 10)
            {
                preStartTimer++;
                return;
            }
            if (!GetOrFindTarget(out NPC target))
                return;

            projectile.velocity = Vector2.Lerp(projectile.velocity, projectile.DirectionTo(target.Center) * 8, 0.1f);
        }

        bool GetOrFindTarget(out NPC target)
        {
            ref float targetIndex = ref projectile.ai[0];
            if (targetIndex < 1)
                targetIndex = AIHelpers.GetClosestEnemy(projectile.Center, ValidTarget);
            if (targetIndex == -1)
            {
                target = null;
                return false;
            }
            target = Main.npc[(int)targetIndex];
            if (!ValidTarget(target))
            {
                targetIndex = AIHelpers.GetClosestEnemy(projectile.Center, ValidTarget);
                if (targetIndex == -1)
                    return false;
                target = Main.npc[(int)targetIndex];
            }

            if (!ValidTarget(target))
                return false;

            return true;
        }
        bool ValidTarget(NPC npc)
        {
            return npc.active && npc.CanBeChasedBy() && !npc.friendly && npc.WithinRange(projectile.Center, 10 * 16);
        }
    }
}
