using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.Utilities;
using Terraria.World.Generation;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YoguContentMod.Tiles.Ores;

namespace YoguContentMod.Common
{
    public class OreGenerationWorld : ModWorld
    {
        public static string SluggishOrePassName { get; } = "Sluggish Ore Gen";
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            base.ModifyWorldGenTasks(tasks, ref totalWeight);
            tasks.Add(new PassLegacy(SluggishOrePassName, SluggishOreGen));
        }
        private static void SluggishOreGen(GenerationProgress progress)
        {
            CommonOreGen(0, Main.maxTilesX, (int)WorldGen.worldSurfaceLow, Main.maxTilesY, ModContent.TileType<SluggishOreTile>());
        }
        private static void CommonOreGen(int minX, int maxX, int minY, int maxY, int tileType, Action<float> progressUpdate = null, float tileFrequency = 0.00006f, UnifiedRandom genRand = null, float strengthMin = 3, float strengthMax = 6, int stepsMin = 2, int stepsMax = 6)
        {
            if (genRand == null)
                genRand = WorldGen.genRand;
            int tileCount = (int)(Main.maxTilesX * Main.maxTilesY * tileFrequency);
            for(int i = 0; i < tileCount; i++)
            {
                int x = genRand.Next(minX, maxX);
                int y = genRand.Next(minY, maxY);
                WorldGen.TileRunner(x, y, genRand.NextFloat(strengthMin, strengthMax), genRand.Next(stepsMin, stepsMax), tileType);
                progressUpdate?.Invoke(i / (float)tileCount);
            }
        }
    }
}
