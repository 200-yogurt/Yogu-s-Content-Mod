using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YoguContentMod.Items.Materials.KingYoqurt
{
    public class MechanicShard : Material
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanic Shard");
            Tooltip.SetDefault("These shards are dropped from his low quality screen projection, these are very shiny \nIf its made for something i asure you is going to be shiny");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.material = true;
            item.rare = ItemRarityID.Green;
            item.maxStack = 999;
        }
    }
}
