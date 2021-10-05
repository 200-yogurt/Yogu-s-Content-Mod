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
    public static class Helpers
    {
        //public static event Action OnLoad;
        //public static event Action OnUnload;

        public static int SpawnNPC<TModNPC>(Vector2 coords, int Start = 0, float ai0 = 0f, float ai1 = 0f, float ai2 = 0f, float ai3 = 0f, int Target = 255) where TModNPC : ModNPC
        {
            return NPC.NewNPC((int)coords.X, (int)coords.Y, ModContent.NPCType<TModNPC>(), Start, ai0, ai1, ai2, ai3, Target);
        }

        public static int SpawnNPC(Vector2 coords, int type, int Start = 0, float ai0 = 0f, float ai1 = 0f, float ai2 = 0f, float ai3 = 0f, int Target = 255)
        {
            return NPC.NewNPC((int)coords.X, (int)coords.Y, type, Start, ai0, ai1, ai2, ai3, Target);
        }

        public static Color GetColor(Vector2 worldCoords)
        {
            return Lighting.GetColor((int)(worldCoords.X / 16), (int)(worldCoords.Y / 16));
        }

        public static Color GetColor(Vector2 worldCoords, Color oldColor)
        {
            return Lighting.GetColor((int)(worldCoords.X / 16), (int)(worldCoords.Y / 16), oldColor);
        }
    }
}
