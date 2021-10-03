using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using YoguContentMod.NPCs.BossNPCs.YoguBoss;

namespace YoguContentMod.Items.BossSummons.KingYoqurt
{
    public class LethargicAutomation : BossSummon<YoguBoss>
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.width = 26;
            item.height = 26;
        }

        public override bool CanUseItem(Player player)
        {
            return base.CanUseItem(player) && Main.LocalPlayer.ZoneOverworldHeight;
        }
    }
}
