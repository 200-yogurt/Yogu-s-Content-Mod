using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

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
            npc.buffImmune[20] = true;
            npc.buffImmune[30] = true;
            npc.buffImmune[70] = true;
            npc.buffImmune[31] = true;
            npc.buffImmune[149] = true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.55f;
        }

        private const int AI_State_Slot = 0;
        private const int AI_Timer_Slot = 1;
        private const int AI_TinySoup_Slot = 2;
        private const int AI_Unused_Slot_3 = 3;

        private const int Local_AI_Unused_Slot_0 = 0;
        private const int Local_AI_Unused_Slot_1 = 1;
        private const int Local_AI_Unused_Slot_2 = 2;
        private const int Local_AI_Unused_Slot_3 = 3;

        private const int State_Asleep = 0;
        private const int State_Notice = 1;
        private const int State_Attack = 2;
        private const int State_Running = 3;
        private const int State_Away = 4;
        private const int State_Float = 5;

        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;
        }

        public float AI_Timer
        {
            get => npc.ai[AI_Timer_Slot];
            set => npc.ai[AI_Timer_Slot] = value;
        }

        public float AI_TinySoup
        {
            get => npc.ai[AI_TinySoup_Slot];
            set => npc.ai[AI_TinySoup_Slot] = value;
        }

        public override void AI()
        {
            if (AI_State == State_Asleep)
            {
                npc.TargetClosest(true);

                if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 320f)
                {
                    AI_State = State_Notice;
                    AI_Timer = 0;
                }
            }

            else if (AI_State == State_Notice)
            {
                if (Main.player[npc.target].Distance(npc.Center) < 192f)
                {
                    AI_Timer++;
                    if (AI_Timer >= 20)
                    {
                        AI_State = State_Attack;
                        AI_Timer = 0;
                    }
                }
                else
                {
                    npc.TargetClosest(true);
                    if (!npc.HasValidTarget || Main.player[npc.target].Distance(npc.Center) > 500f)
                    {
                        AI_State = State_Float;
                        AI_Timer = 0;

                    }
                }
            }

            else if (AI_State == State_Float)
            {
                npc.TargetClosest(true);
                Player target = Main.player[npc.target];
                Vector2 directionToPlayer = npc.DirectionTo(target.Center);
                npc.velocity = Vector2.Lerp(npc.velocity, directionToPlayer * 1f, 0.1f);
                if(target.WithinRange(npc.Center, 112f))
                {
                    AI_State = State_Attack;
                }
            }

            else if (AI_State == State_Attack)
            {
                npc.TargetClosest(true);
                Player target = Main.player[npc.target];
                Vector2 directionToPlayer = npc.DirectionTo(target.Center);
                npc.velocity = Vector2.Lerp(npc.velocity, directionToPlayer * 1f, 0.1f);
            }
        }
    }
}
