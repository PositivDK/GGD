using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace GGD.Items.SummoningItems
{
    public class PetiteEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Petite Eye");
            Tooltip.SetDefault("Summons 10 Eyes of Cthulhu");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 16;
            item.value = 0;
            item.rare = 2;
            item.useStyle = 4;
            item.useTime = 40;
            item.useAnimation = 40;
        }

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {
            for (int i = 0; i < 10; i++)
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.EyeofCthulhu);
            }
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(mod.TileType("GodsWB"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 100);
            recipe.AddIngredient(mod.ItemType("EnergyOfCthulhu")); 
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 100);
            recipe.AddIngredient(mod.ItemType("EnergyOfCthulhu"));
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
