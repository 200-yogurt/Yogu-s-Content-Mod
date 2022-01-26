using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YoguContentMod
{
    public abstract class YProjectile : ModProjectile
    {
        public void SpawnProjectile(Vector2 position, Vector2 velocity, int type, int? damage = null, float? knockback = null, float ai0 = 0, float ai1 = 0, int? owner = null)
        {
            SpawnProjectile(position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, ai0, ai1, owner);
        }
        public void SpawnProjectile(float positionX, float positionY, float speedX, float speedY, int type, int? damage = null, float? knockback = null, float ai0 = 0, float ai1 = 0, int? owner = null)
        {
            Projectile.NewProjectile(positionX, positionY, speedX, speedY, type, damage ?? projectile.damage, knockback ?? projectile.knockBack, owner ?? projectile.owner, ai0, ai1);
        }
    }
}
