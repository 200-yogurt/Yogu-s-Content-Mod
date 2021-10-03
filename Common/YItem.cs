using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace YoguContentMod
{
    public abstract class YItem : ModItem
    {
        public AdvancedRecipe CreateRecipe(int stack = 1)
        {
            return new AdvancedRecipe(mod, this, stack);
        }
    }
}
