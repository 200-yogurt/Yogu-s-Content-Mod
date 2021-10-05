using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using YoguContentMod.Items.Materials.KingYoqurt;
using YoguContentMod.Items.Vanities;
using YoguContentMod.Items.Weapons.Magic;
using YoguContentMod.Items.Weapons.Melee;
using YoguContentMod.Items.Weapons.Ranged;
using YoguContentMod.Items.Weapons.Summon;

namespace YoguContentMod.Items.TreasureBags
{
    public class YoqurtBossBag : YItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yoqurt Bag");
            Tooltip.SetDefault("Right click to open");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.maxStack = 999;
            item.consumable = true;
            item.width = 32;
            item.height = 50;
            item.rare = ItemRarityID.Green;
            item.expert = true;
        }
        public override bool CanRightClick()
        {
            return true;
        }
        public override void OpenBossBag(Player player)
        {
            int choice = Main.rand.Next(7); 
            
            if (choice == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<StickySword>());
            }
            else if (choice == 1) 
            {
                player.QuickSpawnItem(ModContent.ItemType<SluggishStaff>());
            }
            else if (choice == 2)
            {
                player.QuickSpawnItem(ModContent.ItemType<StagnantBow>());
            }
            else if (choice == 3)
            {
                player.QuickSpawnItem(ModContent.ItemType<OrdinaryDrink>());
            }
            if (Main.rand.NextBool(4))
            {
                player.QuickSpawnItem(ModContent.ItemType<KingYoqurtMask>());
            }
            player.QuickSpawnItem(ModContent.ItemType<Yogurt>(), Main.rand.Next(5, 11)); // aqi sta bien

        }
    }
} 
