using Terraria.ID;
using Terraria.ModLoader;

namespace GGD.Items.Class
{
    public class ClassMaterial : ModItem
    {
        public override string Texture { get { return "Terraria/Item_" + ItemID.GoldHelmet; } }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Class material");
            Tooltip.SetDefault("Combine with one of five items to get a class item");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 32;
            item.value = 0;
            item.rare = -12;
            item.maxStack = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddIngredient(ItemID.WoodenBow);
            recipe.SetResult(mod.ItemType("ClassRanger"));
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddIngredient(ItemID.WoodenSword);
            recipe.SetResult(mod.ItemType("ClassWarrior"));
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddIngredient(ItemID.Shuriken);
            recipe.SetResult(mod.ItemType("ClassNinja"));
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddIngredient(ItemID.SlimeStaff);
            recipe.SetResult(mod.ItemType("ClassSummoner"));
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddIngredient(ItemID.AmethystStaff);
            recipe.SetResult(mod.ItemType("ClassMagician"));
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(mod.TileType("GodsWB"));
            recipe.SetResult(mod.ItemType("ClassMagician"));
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(mod.TileType("GodsWB"));
            recipe.SetResult(mod.ItemType("ClassNinja"));
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(mod.TileType("GodsWB"));
            recipe.SetResult(mod.ItemType("ClassWarrior"));
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(mod.TileType("GodsWB"));
            recipe.SetResult(mod.ItemType("ClassSummoner"));
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(mod.TileType("GodsWB"));
            recipe.SetResult(mod.ItemType("ClassRanger"));
            recipe.AddRecipe();
        }
    }
}
