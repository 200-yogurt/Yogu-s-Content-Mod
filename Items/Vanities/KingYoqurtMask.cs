using Terraria.ID;
using Terraria.ModLoader;

namespace YoguContentMod.Items.Vanities
{
    [AutoloadEquip(EquipType.Head)]
    public class KingYoqurtMask : YItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("King Yoqurt Mask");
            Tooltip.SetDefault("You will have control over yogurts, would you feel proud of it?");
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.width = 18;
            item.height = 18;
            item.rare = ItemRarityID.Green;
            item.vanity = true;
        }
    }
}
