using Terraria;
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

        /// <summary>
        /// <see cref="Item.useStyle"/> = <see cref="ItemUseStyleID.SwingThrow"/><br />
        /// <see cref="Item.useTurn"/> = <see langword="true"/><br />
        /// <see cref="Item.autoReuse"/> = <see langword="true"/><br />
        /// <see cref="Item.consumable"/> = <see langword="true"/><br />
        /// <see cref="Item.useAnimation"/> = 15<br />
        /// <see cref="Item.useTime"/> = 10<br />
        /// <see cref="Item.maxStack"/> = 999<br />
        /// <see cref="Item.value"/> = 3000<br />
        /// </summary>
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
