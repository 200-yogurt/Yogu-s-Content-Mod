using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YoguContentMod.NPCs.HostileNPCs;

namespace YoguContentMod.NPCs.BossNPCs.YoguBoss
{
    public class YoguBoss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("King Yoqurt"); // its pronounced yogurt but its written as "Yoqurt"
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 3_900; 
            npc.width = 130; 
            npc.height = 134;
            npc.damage = 31; 
            npc.boss = true; 
            npc.aiStyle = -1;  
            npc.noGravity = false; 
            npc.value = Item.sellPrice(gold: 13, silver: 50);  
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) 
        { // a
            npc.lifeMax = 6_780;
            npc.damage = 62; // 
            npc.value = Item.sellPrice(gold: 18, silver: 80); ;
        } 

        const int StateSlot = 0;
        const int TimerSlot = 1;
        const int SecondaryTimerSlot = 2;

        AIState State { get => (AIState)(int)npc.ai[StateSlot]; set => npc.ai[StateSlot] = (int)value; }

        ref float Timer => ref npc.ai[TimerSlot]; //{ get => npc.ai[TimerSlot]; set => npc.ai[TimerSlot] = value; }
        ref float SecondaryTimer => ref npc.ai[SecondaryTimerSlot]; //{ get => npc.ai[SecondaryTimerSlot]; set => npc.ai[SecondaryTimerSlot] = value; }
        Player Target { get => Main.player[npc.target]; }


        public override void AI() 
        { 
            if(State ==  AIState.NPCJumping)
            {
                if(jumpCount < MaxJumpsUntilLaser)
                {
                    if(npc.collideY) // q paso AAAAAAAAAAAAA ctm messi metio gol
                    {
                        Timer++;
                        npc.velocity.X *= 0.95f;
                    }
                    if(Timer > TimePerJump) 
                    {
                        npc.TargetClosest(true);
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

            else if(State == AIState.LaserCharge)
            {
                if(Timer < LaserChargeTime){
                    // charging laser
                    Timer++;
                }
                else 
                {      
                    State = AIState.LaserAttack;
                    Timer = 0;
                } 
            } 

            else if(State == AIState.LaserAttack)
            {
                if(Timer < LaserHoldTime) 
                {
                    if(Timer % LaserWaitTime < 1) // 
                    { // ya reintenta
                        npc.TargetClosest(true); 
                        Vector2 directionToPlayer = npc.DirectionTo(Target.Center); // ya vengo voy a probar
                        Projectile.NewProjectile(npc.Center, directionToPlayer * 10, ProjectileID.EyeLaser /*placeholder*/, 40, 10f  , Main.myPlayer);
                    }

                    Timer++;                
                }
                else // laser attack finish 
                {
                    Timer = 0;
                    SecondaryTimer = 0;
                    if(laserShootCount < 2)
                    {
                        State = AIState.NPCJumping; // reset everything
                        laserShootCount++;
                    }
                    else // after 2 laser shoots
                    {
                        State = AIState.RandomProjectileShooting;
                        laserShootCount = 0;
                    }
                }
            }

            else if(State == AIState.RandomProjectileShooting) //keep shooting
            {
                if (Timer < RandomProjectileShootingTime)
                {
                    Timer++;
                    if (Timer % 20 < 1 || npc.life < npc.lifeMax * 0.4f) // if npc is behind 40% projectile spam, otherwise, every 0.3 secs (20 ticks)
                    {
                        // spawn projectile
                        float projectileShootSpeed = 20;
                        Vector2 direction = Vector2.UnitY.RotatedByRandom(28159f) * projectileShootSpeed;

                        Projectile proj = Projectile.NewProjectileDirect(npc.Center, direction, ProjectileID.MeteorShot, 15, 1f, Main.myPlayer);
                        proj.friendly = false;
                        proj.hostile = true;
                    }
                }
                else // shooting stops
                {
                    Timer = 0;
                    State = AIState.NPCJumping; // a
                    SpawnMiniSoups();        
                }
            }    
        }

        int RandomProjectileShootingTime => 120;

        int laserShootCount;
        float LaserWaitTime => 10;
        float LaserHoldTime = 60;
        float LaserChargeTime => 20;

        int TimePostJumpWait => 80;    
        int TimePerJump => 40;
        int MaxJumpsUntilLaser => 4;
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
            Vector2 off = new Vector2(0, 100);
            Vector2 center = npc.Center;
            NPC.NewNPC((int)(center.X + off.X), (int)(center.Y + off.Y), ModContent.NPCType<TinySoup>());
            NPC.NewNPC((int)(center.X - off.X), (int)(center.Y - off.Y), ModContent.NPCType<TinySoup>());
        }
        
        void Jump()
        {
            npc.TargetClosest(true);
            Vector2 toPlayer = npc.Center - Target.MountedCenter;
            npc.velocity.Y = -10; // movement to up 
            npc.velocity.X = 10 * -Math.Sign(toPlayer.X); // horizontal (x) movement
        } 
    } // pos ya intenta
}
