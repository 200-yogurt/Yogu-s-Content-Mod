using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace YoguContentMod.Common
{
    public class DownedNPCsModWorld : ModWorld
    {
        public static bool downedYoguBoss;

        public override void Load(TagCompound tag)
        {
            if (!tag.TryGet("downed", out List<string> downed))
                downed = new List<string>();

            downedYoguBoss = downed.Contains("downedYoguBoss");
        }

        public override TagCompound Save()
        {
            TagCompound tag = new TagCompound();

            List<string> downed = new List<string>();

            if (downedYoguBoss)
                downed.Add("downedYoguBoss");

            tag["downed"] = downed;

            return tag;
        }
    }
}
