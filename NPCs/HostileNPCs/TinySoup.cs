using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YoguContentMod.NPCs.HostileNPCs
{
    public class TinySoup : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 4;
        }
           public override void SetDefaults() 
           {
               npc.width = 24;
               npc.height = 34;
               npc.aiStyle = -1;
               npc.damage = 7;
               npc.defense = 2;
               npc.lifeMax = 25;
               npc.HitSound = SoundID.NPCHit1;
               npc.DeathSound = SoundID.NPCDeath1;
               npc.value = 25f;
               SetBuffImmune(20, 30, 70, 31, 149);
           }
        void SetBuffImmune(params int[] BuffTypes)
        {
            foreach (int buffType in BuffTypes)
            {
                npc.buffImmune[buffType] = true;
            }
        }

    }
}