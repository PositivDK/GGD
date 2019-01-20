using Terraria.ID;
using Terraria.ModLoader;

namespace GGD.Items
{
    public class AreoiumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Areoium Bar");
            Tooltip.SetDefault("Piece of metal capable of floating.");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 26;
            item.value = 10000;
            item.rare = 2;
            item.maxStack = 999;
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            //recipe.AddIngredient(mod.ItemType("AreoOrt"), 3);
            //recipe.AddIngredient(ItemID.Gel);
            //recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(mod.TileType("GodsWB"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        
        }*/
    }
}
