using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YoguContentMod.Items.Vanities
{
    [AutoloadEquip(EquipType.Head)]
    class KingYoqurtMask : YItem
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
