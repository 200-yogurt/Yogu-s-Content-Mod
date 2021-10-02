using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YoguContentMod.NPCs.HostileNPCs;

namespace YoguContentMod.NPCs.BossNPCs.YoguBoss
{
    public class YoguBoss : ModNPC, IFallThroughPlatforms
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("King Yoqurt"); // its pronounced yogurt but its written as "Yoqurt"
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults() // VS c bugio
        {
            npc.lifeMax = 3_900;
            npc.width = 130;
            npc.height = 134;
            npc.damage = 31;
            npc.defense = 11;
            npc.boss = true;
            npc.aiStyle = -1;  // 
            npc.noGravity = false;
            npc.knockBackResist = 0f;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        { // a
            npc.lifeMax = 6_780; // 
            npc.damage = 62;
            npc.defense = 22;
        }

        const int StateSlot = 0;
        const int TimerSlot = 1;
        const int SecondaryTimerSlot = 2;

        AIState State { get => (AIState)(int)npc.ai[StateSlot]; set => npc.ai[StateSlot] = (int)value; }

        ref float Timer => ref npc.ai[TimerSlot]; //{ get => npc.ai[TimerSlot]; set => npc.ai[TimerSlot] = value; }
        ref float SecondaryTimer => ref npc.ai[SecondaryTimerSlot]; //{ get => npc.ai[SecondaryTimerSlot]; set => npc.ai[SecondaryTimerSlot] = value; }
        bool IsFirst { get => npc.ai[3] == 0; }
        Player Target { get => Main.player[npc.target]; }


        public override void AI()
        {
            if (npc.collideY)
                npc.velocity.X *= 0.8f;

            npc.TargetClosest(true);
            if (State == AIState.NPCJumping)
            {
                if (jumpCount < MaxJumpsUntilLaser) // caca
                {
                    if (npc.collideY) // 
                    {
                        Timer++;
                    }
                    if (Timer > TimePerJump)
                    {
                        Jump();
                        jumpCount++;
                        Timer = 0; // reset timer  
                    }
                }
                else
                {
                    State = AIState.LaserAttack; // change state
                    jumpCount = 0;
                }
            }

            else if (State == AIState.LaserCharge)
            {
                if (Timer < LaserChargeTime)
                {
                    // charging laser
                    Timer++;
                }
                else
                {
                    State = AIState.LaserAttack;
                    Timer = 0;
                }
            }

            else if (State == AIState.LaserAttack)
            {
                float totalTime = LaserShootCount * LaserWaitTime;
                if (Timer < totalTime) // total time between all laser shoots
                {
                    if (Timer % LaserWaitTime < 1)
                    {
                        Vector2 directionToPlayer = npc.DirectionTo(Target.Center);
                        Projectile.NewProjectile(npc.Center, directionToPlayer * 10, ProjectileID.EyeLaser /*placeholder*/, 40, 10f, Main.myPlayer);
                    }

                    Timer++;
                }
                else if (Timer < totalTime + SecondTimerPhaseTime)
                {
                    float d = Timer % SecondLaserPhaseWaitTime;
                    if (d < 1)
                    {
                        Vector2 directionToPlayer = npc.DirectionTo(Target.Center);
                        Projectile.NewProjectile(npc.Center, directionToPlayer * 10, ProjectileID.EyeLaser /*placeholder*/, 40, 10f, Main.myPlayer);
                    }
                    Timer++;

                }
                else // laser attack finish 
                {
                    Timer = 0;
                    SecondaryTimer = 0;
                    if (laserPhaseCount < 4) // repeat jumping and doing lasers 4 times
                    {
                        State = AIState.NPCJumping; // reset everything
                        laserPhaseCount++;
                    }
                    else // after 2 laser shoots
                    {
                        State = AIState.NPCJumping;
                        laserPhaseCount = 0;
                    }
                }
            }
        }

        public override void NPCLoot()
        {
            base.NPCLoot();
        }

        public override bool PreNPCLoot()
        {
            if (IsFirst)
            {
                NPC.NewNPC((int)(npc.Center.X), (int)(npc.Center.Y), ModContent.NPCType<StagnantAbomination>(), Target: npc.target);

                return false;
            }
            return base.PreNPCLoot(); 
        }

        int RandomProjectileShootingTime => 180;

        int laserPhaseCount;
        float SecondLaserPhaseWaitTime => 5; // 
        float SecondTimerPhaseTime => 60; // time for the second phase of pure random shoots
        float LaserWaitTime => 48; // time between each laser shot


        float LaserShootCount => 4; // total time shooting lasers
        float LaserChargeTime => 48;  // 

        int TimePostJumpWait => 80;
        int TimePerJump => 40;

        int MaxJumpsUntilLaser
        {
            get
            {
                /*
                 * 100% - 81%: 8 saltos
                 *  80% - 61%: 7 saltos
                 *  60% - 41%: 5 saltos
                 *  40% - 15%: 4 saltos
                 *  15% - 1%: 3
                 */

                float d = npc.life / (float)npc.lifeMax;
                if (d > 0.8f)
                {
                    return 8;
                }
                else if (d > 0.6f)
                {
                    return 7;
                }
                else if (d > 0.4f)
                {
                    return 5;
                }
                else if (d > 0.15f)
                {
                    return 4;
                }
                else // < 15% 
                {
                    return 3;
                }
            }
        }

        bool IFallThroughPlatforms.CanFall => (Target.Bottom.Y - 16) > (npc.Bottom.Y);
        /*{
            get
            {
                bool n = ;
                Main.NewText(n);
                return n;
            }
        }*/

        int jumpCount;

        public enum AIState
        {
            NPCJumping,
            LaserCharge,
            LaserAttack,
            RandomProjectileShooting,
        }

        void SpawnMiniSoups()
        {
            Vector2 off = new Vector2(100, 0);
            Vector2 center = npc.Center;
            NPC.NewNPC((int)(center.X + off.X), (int)(center.Y + off.Y), ModContent.NPCType<TinySoup>());
            NPC.NewNPC((int)(center.X - off.X), (int)(center.Y - off.Y), ModContent.NPCType<TinySoup>());
        }

        void Jump()
        {
            npc.TargetClosest(true);
            Vector2 toPlayer = Target.MountedCenter - npc.Center;
            npc.velocity.Y = -10; // movement to up 
            npc.velocity.X = 4 * Math.Sign(toPlayer.X); // horizontal (x) movement
        }

        public override void FindFrame(int frameHeight)
        {
            const int maxFrames = 8;
            const int timePerFrame = 10;

            npc.frameCounter++;
            if (npc.frameCounter > timePerFrame)
            {
                npc.frameCounter = 0;

                npc.frame.Y += frameHeight;
                if (npc.frame.Y >= frameHeight * maxFrames)
                {
                    npc.frame.Y = 0;
                }
            }

            base.FindFrame(frameHeight);
        }
    }
}
