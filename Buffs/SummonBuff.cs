using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace YoguContentMod.Buffs
{
    public abstract class SummonBuff : ModBuff
    {
        public abstract int ProjectileType { get; }

        public override void SetDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            base.Update(player, ref buffIndex);
            if (player.ownedProjectileCounts[ProjectileType] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }

    public abstract class SummonBuff<TProjectile> : SummonBuff where TProjectile : ModProjectile
    {
        public override int ProjectileType => ModContent.ProjectileType<TProjectile>();
    }
}
