using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YoguContentMod
{
    public static class AIHelpers
    {
        /// <summary>
        /// Returns the index of the closest enemy or -1 if no enemy is found
        /// </summary>
        /// <param name="position"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int GetClosestEnemy(Vector2 position, Func<NPC, bool> predicate = null)
        {
            int npcCount = Main.npc.Length - 1;
            int indexClosest = -1;
            float closestDistanceSQ = -1;

            for (int i = 0; i < npcCount; i++)
            {
                NPC npc = Main.npc[i];
                if(npc?.active == true && npc.CanBeChasedBy() && !npc.friendly && (predicate?.Invoke(npc) ?? true))
                {
                    float distSQ = npc.DistanceSQ(position);
                    if(closestDistanceSQ == -1 || closestDistanceSQ < distSQ)
                    {
                        closestDistanceSQ = distSQ;
                        indexClosest = i;
                    }
                }
            }

            return indexClosest;
        }

        public static NPC GetClosestEnemyDirect(Vector2 position, Func<NPC, bool> predicate = null)
        {
            int npc = GetClosestEnemy(position, predicate);
            if (npc == -1)
                return null;
            return Main.npc[npc];
        }
    }
}
