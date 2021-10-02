using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoguContentMod.NPCs;

namespace YoguContentMod
{
    internal static class ILAndDetours
    {
        internal static void Load()
        {
            On.Terraria.NPC.Collision_DecideFallThroughPlatforms += NPCHelper.NPC_Collision_DecideFallThroughPlatforms;
        }
    }
}
