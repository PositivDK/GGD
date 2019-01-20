using Terraria.ID;
using Terraria.ModLoader;

namespace GGD.Items
{
    public class AreoOrt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Areo Ort");
            Tooltip.SetDefault("Piece of rock capable of flying.");
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.value = 1;
            item.rare = 2;
            item.maxStack = 999;
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}
