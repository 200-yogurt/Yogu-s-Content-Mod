using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YoguContentMod.NPCs
{
    internal static class NPCHelper
    {
        internal static bool NPC_Collision_DecideFallThroughPlatforms(On.Terraria.NPC.orig_Collision_DecideFallThroughPlatforms orig, Terraria.NPC self)
        {
            return orig(self) || DecideThroughPlatformsCheck(self);
        }

        private static bool DecideThroughPlatformsCheck(NPC npc)
        {
            var fallthroughplatforms = npc.modNPC as IFallThroughPlatforms;
            return fallthroughplatforms == null || fallthroughplatforms.CanFall;
        }
    }
}
