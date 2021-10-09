using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using YoguContentMod.NPCs.BossNPCs.YoguBoss;

namespace YoguContentMod.Items.BossSummons.KingYoqurt
{
    public class LethargicAutomation : BossSummon<YoguBoss>
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lethargic Automation");
            Tooltip.SetDefault("Summons King Yoqurt \nUse this to disturb some poor people");
        } 

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.width = 26;
            item.height = 26;
            item.rare = ItemRarityID.Blue;
        }

        public override bool CanUseItem(Player player)
        {
            return base.CanUseItem(player) && Main.LocalPlayer.ZoneOverworldHeight && !NPC.AnyNPCs(ModContent.NPCType<StagnantAbomination>());
        }
    }
}
