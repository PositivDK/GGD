using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using GGD;

namespace GGD.Items.LvlS
{
    public class LvlcapInc4 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Levelcap increase");
            Tooltip.SetDefault("Adds 10 to lvlcap once");
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.value = Item.sellPrice(gold: 1);
            item.rare = 2;
            item.maxStack = 999;
            item.consumable = true;
            item.useAnimation = 6;
            item.useTime = 6;
            item.useStyle = 4;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<GGDPlayer>().lvlCap4 == false)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<GGDPlayer>().maxLvl += 10;
            player.GetModPlayer<GGDPlayer>().lvlCap4 = true;
            Main.NewText("Your potential increase slightly", 139, 0, 139);
            return true;
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
