using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using YoguContentMod.Items.Materials;

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
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = Item.sellPrice(copper: 69);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Skin>(), 30);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
