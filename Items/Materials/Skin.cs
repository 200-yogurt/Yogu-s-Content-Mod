using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YoguContentMod.Items.Materials
{
    public class Skin : YItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skin");
            Tooltip.SetDefault("An object dropped by those unfortunate \nUsed to make useless stuff and very cursed stuff");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.material = true;
            item.rare = ItemRarityID.Blue;
            item.maxStack = 999;
        }
    }
}
