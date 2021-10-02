using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YoguContentMod
{
	public class YoguContentMod : Mod
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
	}
}
