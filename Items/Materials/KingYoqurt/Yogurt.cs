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
    public class Yogurt : Material
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Yogurt");
            Tooltip.SetDefault("For some reason, yogurt is collected and stored inside their maximum kingdom leaders\nThese objects are very slippery and shiny, its used to make sluggish stuff with it");
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
