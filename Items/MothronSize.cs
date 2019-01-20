using Terraria.ID;
using Terraria.ModLoader;

namespace GGD.Items
{
    public class MothronSize : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Test Sprite");
            Tooltip.SetDefault(":Test:");
        }
        public override void SetDefaults()
        {
            item.width = 320;
            item.height = 320;
            item.value = 0;
            item.rare = -12;
            item.maxStack = 10;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(mod.TileType("GodsWB"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
