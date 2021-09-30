using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YoguContentMod.Items.Materials
{
    public class Skin : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skin");
            Tooltip.SetDefault("An object dropped by those unfortunate \nUsed to make useless stuff and very cursed stuff");
        }
        public override void SetDefaults()
        {
            item.material = true;
            item.rare = 1;
            item.maxStack = 9999;
        }
    }
}
