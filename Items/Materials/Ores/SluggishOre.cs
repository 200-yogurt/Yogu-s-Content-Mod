using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YoguContentMod.Items.Materials.Ores
{
    public class SluggishOre : Ore
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.createTile = ModContent.TileType<Tiles.Ores.SluggishOreTile>();
            item.width = 14;
            item.height = 14;
        }
    }
}
