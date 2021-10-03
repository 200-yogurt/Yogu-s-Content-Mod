using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace YoguContentMod
{
    public class AdvancedRecipe : ModRecipe
    {
        public AdvancedRecipe(Mod mod) : base(mod)
        {

        }

        public AdvancedRecipe(Mod mod, ModItem item, int stack = 1) : base(mod)
        {
            base.SetResult(item, stack);
        }

        public new AdvancedRecipe AddIngredient(int type, int stack = 1)
        {
            base.AddIngredient(type, stack);
            return this;
        }

        public new AdvancedRecipe AddIngredient(ModItem item, int stack = 1)
        {
            base.AddIngredient(item, stack);
            return this;
        }

        public new AdvancedRecipe AddIngredient(Mod mod, string itemName, int stack = 1)
        {
            base.AddIngredient(mod, itemName, stack);
            return this;
        }

        public AdvancedRecipe AddIngredient<TModItem>(int stack = 1) where TModItem : ModItem
        {
            base.AddIngredient(ModContent.ItemType<TModItem>(), stack);
            return this;
        }

        public new AdvancedRecipe AddTile(int type)
        {
            base.AddTile(type);
            return this;
        }

        public new AdvancedRecipe AddTile(ModTile tile)
        {
            base.AddTile(tile);
            return this;
        }

        public new AdvancedRecipe AddTile(Mod mod, string tileName)
        {
            base.AddTile(mod, tileName);
            return this;
        }

        public AdvancedRecipe AddTile<TModTile>() where TModTile : ModTile
        {
            base.AddTile(ModContent.TileType<TModTile>());
            return this;
        }

        public new AdvancedRecipe SetResult(int type, int stack = 1)
        {
            base.SetResult(type, stack);
            return this;
        }

        public new AdvancedRecipe SetResult(ModItem item, int stack = 1)
        {
            base.SetResult(item, stack);
            return this;
        }

        public new AdvancedRecipe SetResult(Mod mod, string itemName, int stack = 1)
        {
            base.SetResult(mod, itemName, stack);
            return this;
        }

        public AdvancedRecipe SetResult<TModItem>(int stack = 1) where TModItem : ModItem
        {
            base.SetResult(ModContent.ItemType<TModItem>(), stack);
            return this;
        }

        public new AdvancedRecipe AddRecipeGroup(int recipeGroupID, int stack = 1)
        {
            base.AddRecipeGroup(recipeGroupID, stack);
            return this;
        }

        public new AdvancedRecipe AddRecipeGroup(string name, int stack = 1)
        {
            base.AddRecipeGroup(name, stack);
            return this;
        }

        public void Register()
        {
            base.AddRecipe();
        }
    }
}
