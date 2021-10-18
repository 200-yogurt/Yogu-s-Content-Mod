using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YoguContentMod.Projectiles.Minions;

namespace YoguContentMod.Buffs
{
    public class TinySoupMK2Buff : SummonBuff<TinySoupMK2Proj>
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            DisplayName.SetDefault("Tiny Soup MK2");
            Description.SetDefault("");
        }
    }
}
