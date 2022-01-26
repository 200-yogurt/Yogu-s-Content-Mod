using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace YoguContentMod.Tiles.Ores
{
    public class SluggishOreTile : OreTile
    {
        public override void SetDefaults()
        {
			base.SetDefaults();
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("SluggishOre");
			AddMapEntry(new Color(152, 171, 198), name);

			drop = ModContent.ItemType<Items.Materials.Ores.SluggishOre>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 4f;
		}
	}
}
