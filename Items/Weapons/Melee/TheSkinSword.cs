using Terraria.ID;
using Terraria.ModLoader;

namespace YoguContentMod.Items.Weapons.Melee
{
	public class TheSkinSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Skin Sword");
			Tooltip.SetDefault("This is a skin made weapon, not very useful but kinda stinky");
		}
		public override void SetDefaults()
		{
			item.damage = 10;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 13;
			item.knockBack = 3;
			item.value = 000, 000, 000, 069;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
