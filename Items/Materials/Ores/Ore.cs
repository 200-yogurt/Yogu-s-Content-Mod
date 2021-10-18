using Terraria.ID;

namespace YoguContentMod.Items.Materials.Ores
{
    public abstract class Ore : YItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            ItemID.Sets.SortingPriorityMaterials[item.type] = 58;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.maxStack = 999;

            item.value = 3000;
        }
    }
}
