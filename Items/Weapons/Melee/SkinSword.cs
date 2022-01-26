using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YoguContentMod.Items.Materials;
using YoguContentMod.Projectiles.Hostile;

namespace YoguContentMod.Items.Weapons.Melee
{
	public class SkinSword : YItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Skin Sword");
			Tooltip.SetDefault("This is a skin made weapon, not very useful but kinda cursed");
		}

		public override void SetDefaults()
		{
			item.damage = 5;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3;
			item.value = Item.sellPrice(copper: 69);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;

		}

        public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient<Skin>(18)
			.AddRecipeGroup(RecipeGroupID.Wood, 10)
			.AddTile(TileID.Loom)
			.Register();
			/*ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Skin>(), 18);
			recipe.AddRecipeGroup(RecipeGroupID.Wood, 10);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();*/
		}
	}
}
