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
        public static string Prefix { get; } = "YoguContentMod";
        public static YoguContentMod Instance { get => ModContent.GetInstance<YoguContentMod>(); }
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

        public override void PostSetupContent()
        {
            base.PostSetupContent();
            BossChecklistCompat.Load();
        }
    }
}
