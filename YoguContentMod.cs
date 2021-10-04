using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YoguContentMod.Items.BossSummons.KingYoqurt;
using YoguContentMod.Items.Weapons;
using YoguContentMod.Items.Weapons.Magic;
using YoguContentMod.Items.Weapons.Melee;
using YoguContentMod.Items.Weapons.Ranged;
using YoguContentMod.Items.Weapons.Summon;
using YoguContentMod.NPCs.BossNPCs.YoguBoss;
using YoguContentMod.Items.Materials.KingYoqurt;

namespace YoguContentMod
{
    public class YoguContentMod : Mod //
    {
        public YoguContentMod()
        {
        }

        public override void Load()
        {
            base.Load();
            ILAndDetours.Load();
        }

        public override void Unload()
        {
            base.Unload();
        }

        public static void Test(object arg)
        {
            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 300; i++)
                {
                    int x = (int)(Main.LocalPlayer.Center.X / 16) + i;
                    int y = (int)(Main.LocalPlayer.Center.Y / 16) + j * 5;
                    WorldGen.PlaceTile(x, y, TileID.Platforms);
                }
            }
        }

        public override void PostSetupContent()
        {
            base.PostSetupContent();
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {

                AddBossChecklistBossEntry(
                //"AddBoss",
                bossChecklistMod: bossChecklist,
                priority: 1.55f,
                npctype: ModContent.NPCType<YoguBoss>(), 
                mod: this,
                name: "King Yoqurt",
                defeated: (Func<bool>)(() => DownedNPCsModWorld.DownedYoguBoss), 
                summonItem: ModContent.ItemType<LethargicAutomation>(),
                list: new List<int> { },
                loot: new List<int> { ModContent.ItemType<StickySword>(), ModContent.ItemType<StagnantBow>(), ModContent.ItemType<DrippyGun>(), ModContent.ItemType<SluggishStaff>(), ModContent.ItemType<OrdinaryDrink>(), ModContent.ItemType<MechanicShard>(), ModContent.ItemType<Yogurt>() }, // BossCheckList adds a book were you can see the bosses drops, items, summon and hot it went to the player meanwhile on fight, so these objects appear on the drops
                description: $"Use a [i:{ModContent.ItemType<LethargicAutomation>()} in the surface \nThis boss comes from a small kingdom near the player's island \nUse this if you want to disturb the poor people from his kingdom" 
                );
                

            }
        }

        static void AddBossChecklistBossEntry(Mod bossChecklistMod, float priority, int npctype, Mod mod, string name, Func<bool> defeated, int summonItem, List<int> list, List<int> loot, string description = null)
        {
            bossChecklistMod.Call("AddBoss", priority, npctype, mod, name, defeated, summonItem, list, loot, description);
        }
    }
}
