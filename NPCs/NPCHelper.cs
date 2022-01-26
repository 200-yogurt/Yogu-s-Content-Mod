using Terraria;

namespace YoguContentMod.NPCs
{
    internal static class NPCHelper
    {
        internal static bool NPC_Collision_DecideFallThroughPlatforms(On.Terraria.NPC.orig_Collision_DecideFallThroughPlatforms orig, NPC self)
        {
            return orig(self) || DecideThroughPlatformsCheck(self);
        }

        private static bool DecideThroughPlatformsCheck(NPC npc)
        {
            var fallthroughplatforms = npc.modNPC as IFallThroughPlatforms;
            return fallthroughplatforms != null && fallthroughplatforms.CanFall;
        }
    }
}
