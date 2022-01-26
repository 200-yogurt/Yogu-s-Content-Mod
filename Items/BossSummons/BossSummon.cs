using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YoguContentMod.Items.BossSummons
{
    public abstract class BossSummon : YItem
    {
        public abstract int SummonNPCType { get; }

        public override bool OnlyShootOnSwing => base.OnlyShootOnSwing;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.maxStack = 20;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return base.CanUseItem(player) && !NPC.AnyNPCs(SummonNPCType);
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, SummonNPCType);

            return true;
        }
    }

    public abstract class BossSummon<TModNPC> : BossSummon where TModNPC : ModNPC
    {
        public override int SummonNPCType => ModContent.NPCType<TModNPC>();

        public override void SetDefaults()
        {
            base.SetDefaults();
        }

        public override bool UseItem(Player player)
        {
            return base.UseItem(player);
        }
    }
}
