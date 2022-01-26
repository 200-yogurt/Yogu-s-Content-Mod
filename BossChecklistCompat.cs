using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using YoguContentMod.Common;
using YoguContentMod.Items.BossSummons.KingYoqurt;
using YoguContentMod.Items.Materials.KingYoqurt;
using YoguContentMod.Items.Weapons.Magic;
using YoguContentMod.Items.Weapons.Melee;
using YoguContentMod.Items.Weapons.Ranged;
using YoguContentMod.Items.Weapons.Summon;
using YoguContentMod.NPCs.BossNPCs.YoguBoss;

namespace YoguContentMod
{
    internal static class BossChecklistCompat
    {
        public static void Load()
        {
            var instance = YoguContentMod.Instance;
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist == null)
                return;

            AddBossChecklistBossEntry(
            //"AddBoss",
            bossChecklistMod: bossChecklist,
            priority: 1.55f,
            npctype: ModContent.NPCType<YoguBoss>(),
            mod: instance,
            name: "King Yoqurt",
            defeated: (Func<bool>)(() => DownedNPCsModWorld.downedYoguBoss),
            summonItem: ModContent.ItemType<LethargicAutomation>(),
            list: new List<int> { },
            loot: new List<int> { ModContent.ItemType<StickySword>(), ModContent.ItemType<StagnantBow>(), ModContent.ItemType<DrippyGun>(), ModContent.ItemType<SluggishStaff>(), ModContent.ItemType<OrdinaryDrink>(), ModContent.ItemType<MechanicShard>(), ModContent.ItemType<Yogurt>() }, // BossCheckList adds a book were you can see the bosses drops, items, summon and hot it went to the player meanwhile on fight, so these objects appear on the drops
            description: $"Use a [i:{ModContent.ItemType<LethargicAutomation>()} in the surface \nThis boss comes from a small kingdom near the player's island \nUse this if you want to disturb the poor people from his kingdom"
            );
        }

        static void AddBossChecklistBossEntry(Mod bossChecklistMod, float priority, int npctype, Mod mod, string name, Func<bool> defeated, int summonItem, List<int> list, List<int> loot, string description = null)
        {
            bossChecklistMod.Call("AddBoss", priority, npctype, mod, name, defeated, summonItem, list, loot, description);
        }
    }
}
