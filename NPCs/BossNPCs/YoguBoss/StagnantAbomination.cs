using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YoguContentMod.NPCs.BossNPCs.YoguBoss
{
    public class StagnantAbomination : YNPC
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            NPCID.Sets.TrailCacheLength[npc.type] = 15;
            NPCID.Sets.TrailingMode[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            npc.lifeMax = 2_670;
            npc.damage = 82;
            npc.defense = 62;
            npc.width = 82;
            npc.height = 62;
            npc.boss = true;
            npc.noGravity = true;
            npc.aiStyle = -1;
            npc.knockBackResist = 0f;
            npc.value = Item.buyPrice(gold: 13, silver: 50);

        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 5_340;
            npc.damage = 69;
            npc.defense = 24;
            npc.value = Item.buyPrice(gold: 18, silver: 80);
        }

        AIState State { get => (AIState)(int)npc.ai[0]; set => npc.ai[0] = (int)value; }
        ref float Timer => ref npc.ai[1];
        ref float DashCount => ref npc.ai[2];
        bool IsOnSecondPhase => npc.ai[3] > 1;

        Player Target => Main.player[npc.target];

        int MaxDashCount => 4;
        int DashTime => 50;
        int PostDashWaitTime => 20;


        int RandomProjectileSpamTime => 80;
        int TimePerProjectile => 4;
        int PostRandomProjectileSpamWaitTime => 10;

        float n;
        float n2;
        float n3;
        float R { get => n; set => n = value; }
        float R2 { get => n2; set => n2 = value; }
        float R3 { get => n3; set => n3 = value; }
        public void OnDownSpawned()
        {
            npc.dontTakeDamage = false;
            npc.ai[3] = 2;
        }
        public override void AI()
        {
            NPCID.Sets.TrailCacheLength[npc.type] = 15;
            NPCID.Sets.TrailingMode[npc.type] = 3;

            npc.TargetClosest(true);
            npc.velocity *= 0.9f;

            if (!NPC.AnyNPCs(ModContent.NPCType<YoguBoss>()))
            {
                if (!IsOnSecondPhase && npc.life / (float)npc.lifeMax < 0.25f)
                {
                    SpawnKingYogurt();
                }

                switch (State)
                {
                    case AIState.Dash:
                    {
                        if (DashCount < MaxDashCount)
                        {
                            if (Timer < DashTime)
                            {
                                Timer++;
                            }
                            else
                            {
                                Dash();
                                Timer = 0;
                                DashCount++;
                            }
                        }
                        else
                        {
                            DashCount = 0;
                            Timer = 0;
                            State = AIState.PostDash;
                        }
                        break;
                    }

                    case AIState.PostDash:
                    {
                        if (Timer < PostDashWaitTime)
                        {
                            Timer++;
                        }
                        else
                        {
                            Timer = 0;
                            State = AIState.RandomProjectileSpam;
                        }
                        break;
                    }

                    case AIState.RandomProjectileSpam:
                    {
                        if (Timer < RandomProjectileSpamTime)
                        {

                            bool k = R3 < 1; //(R2 * 42.2298f) % 2 < 1;
                            Vector2 n = new Vector2(10, 0).RotatedBy(MathHelper.PiOver2 * Main.rand.Next(4) + (k ? MathHelper.PiOver4 : 0)).RotatedByRandom(MathHelper.PiOver4 / 2f);
                            // .RotatedBy(MathHelper.PiOver2 * r + (k ? MathHelper.PiOver4 : 0)).RotatedBy(0); 
                            Projectile.NewProjectile(npc.Center, n, ProjectileID.EyeLaser, 10, 0, Main.myPlayer);
                            Timer++;
                            Main.NewText(R3);
                        }
                        else
                        {
                            Timer = 0;
                            npc.ai[2] = 0;
                            R2 += 11.2523782f;
                            R2 %= 1f;
                            R3 = ((R3 * 429.7529f) % 2f);
                            State = AIState.PostRandomProjectileSpam;
                        }
                        break;
                    }

                    case AIState.PostRandomProjectileSpam:
                    {
                        if (Timer < PostRandomProjectileSpamWaitTime)
                        {
                            Timer++;
                        }
                        else
                        {
                            Timer = 0;
                            State = AIState.Dash; // reset AI
                        }

                        break;
                    }
                }
            }
            else
            {
                npc.dontTakeDamage = true;
            }

            R = Utils.AngleLerp(R, npc.AngleTo(Target.Center), 0.1f);

            npc.rotation = R;
            //Main.NewText((npc.rotation + MathHelper.TwoPi) % MathHelper.TwoPi);

            if ((npc.rotation - MathHelper.PiOver2 + MathHelper.TwoPi) % MathHelper.TwoPi > MathHelper.Pi)
            {
                //npc.rotation = MathHelper.TwoPi + npc.rotation;
                npc.spriteDirection = -1;
            }
            else
            {
                //npc.rotation = MathHelper.TwoPi - npc.rotation;
                npc.spriteDirection = 1;
            }

            /*if((npc.rotation + MathHelper.TwoPi + MathHelper.PiOver2) % MathHelper.TwoPi > MathHelper.Pi)
            {
                npc.rotation = MathHelper.TwoPi + npc.rotation;
            }

            npc.spriteDirection = Math.Sign(npc.Center.X - Target.Center.X);*/
        }

        public override void NPCLoot()
        {
            base.NPCLoot();
        }

        void SpawnKingYogurt()
        {
            NPC.NewNPC((int)(npc.Center.X), (int)(npc.Center.Y), ModContent.NPCType<YoguBoss>(), 0, ai3: npc.whoAmI + 1, Target: npc.target);

        }



        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Main.instance.LoadNPC(npc.type);
            Texture2D texture = Main.npcTexture[npc.type];
            Vector2 vector10 = new Vector2(texture.Width / 2, texture.Height / Main.npcFrameCount[npc.type] / 2);

            float num64 = 0f;
            float npcHeight = Main.NPCAddHeight(npc.whoAmI);

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (npc.spriteDirection == 1)
                spriteEffects = SpriteEffects.FlipHorizontally;

            Rectangle frame5 = npc.frame;
            Color color9 = Lighting.GetColor((int)(npc.Center.X / 16), (int)(npc.Center.Y / 16));
            NPCLoader.DrawEffects(npc, ref color9);

            Vector2 p = new Vector2(-Main.screenPosition.X + (float)(npc.width / 2) - (float)texture.Width * npc.scale / 2f + vector10.X * npc.scale, -Main.screenPosition.Y + (float)npc.height - (float)texture.Height * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + vector10.Y * npc.scale + npcHeight + num64 + npc.gfxOffY);

            Color alpha = npc.GetAlpha(color9);
            Color color = npc.GetColor(color9);

            for (int i = 0; i < npc.oldPos.Length; i++)
            {
                float progress = 1f - i / (float)npc.oldPos.Length;

                Vector2 position = npc.oldPos[i];
                Vector2 drawPosition = position + p;
                float rot = npc.oldRot[i];
                spriteBatch.Draw(texture, drawPosition, frame5, alpha * progress, rot, vector10, npc.scale, spriteEffects, 0f);
                if (npc.color != default)
                    spriteBatch.Draw(texture, drawPosition, frame5, color * progress, rot, vector10, npc.scale, spriteEffects, 0f);
            }

            return base.PreDraw(spriteBatch, drawColor); // B)
        }


        enum AIState
        {
            Dash,
            PostDash,
            RandomProjectileSpam,
            PostRandomProjectileSpam
        }

        void Dash()
        {
            Vector2 directionToPlayer = npc.DirectionTo(Target.MountedCenter);
            npc.velocity = directionToPlayer * Math.Min(npc.Distance(Target.MountedCenter) / 8, 30f);
        }
    }
}
