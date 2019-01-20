using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using GGD;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;

namespace GGD.Items.LvlS
{
    public class Exp : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Exp Orb");
            Tooltip.SetDefault("Used for lvling \nCurrency");
            // ticksperframe, frameCount
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 3));
            ItemID.Sets.AnimatesAsSoul[item.type] = false;
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = false;           
        }

        public override void SetDefaults()
        {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.SoulofSight);
            item.width = 16;
            item.height = 16;
            item.value = 1;
            item.rare = 7;
            item.maxStack = 999999;
            item.consumable = true;
            item.useAnimation = 2;
            item.useTime = 2;
            item.useStyle = 4;
            item.autoReuse = true;
            item.noUseGraphic = true;

        }

        public override void GrabRange(Player player, ref int grabRange)
        {
            grabRange *= 3;
        }

        /*public override bool GrabStyle(Player player)
        {
            Vector2 vectorItemToPlayer = player.Center - item.Center;
            Vector2 movement = -vectorItemToPlayer.SafeNormalize(default(Vector2)) * 0.1f;
            item.velocity = item.velocity + movement;
            item.velocity = Collision.TileCollision(item.position, item.velocity, item.width, item.height);
            return true;
        }*/

        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<GGDPlayer>().exp < 2000000000)
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
            player.GetModPlayer<GGDPlayer>().exp += 10;
            player.GetModPlayer<GGDPlayer>().lvl = player.GetModPlayer<GGDPlayer>().GetLvl();
            player.GetModPlayer<GGDPlayer>().lvl = player.GetModPlayer<GGDPlayer>().CanLvl();
            if (player.GetModPlayer<GGDPlayer>().exp > 2000000000)
            {
                player.GetModPlayer<GGDPlayer>().exp = 2000000000;
            }
            return true;
        }

        /*public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);
        }*/

        public override void AddRecipes()
        {
            //Exp recipes
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BiggerExp"));
            recipe.AddTile(mod.TileType("ExpTable"));
            recipe.SetResult(this, 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BiggestExp"));
            recipe.AddTile(mod.TileType("ExpTable"));
            recipe.SetResult(this, 100000);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(mod.TileType("GodsWB"));
            recipe.SetResult(this, 999999);
            recipe.AddRecipe();

            //BiggerExp recipes
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Exp"), 100);
            recipe.SetResult(mod.ItemType("BiggerExp"));
            recipe.AddRecipe();
            
            recipe = new ModRecipe(mod);
            recipe.AddTile(mod.TileType("GodsWB"));
            recipe.SetResult(mod.ItemType("BiggerExp"), 999999);
            recipe.AddRecipe();

            //BiggestExp recipes
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Exp"), 100000);
            recipe.AddTile(mod.TileType("ExpTable"));
            recipe.SetResult(mod.ItemType("BiggestExp"));
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BiggerExp"), 1000);
            recipe.AddTile(mod.TileType("ExpTable"));
            recipe.SetResult(mod.ItemType("BiggestExp"));
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(mod.TileType("GodsWB"));
            recipe.SetResult(mod.ItemType("BiggestExp"), 999999);
            recipe.AddRecipe();

            //coin recipes
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BiggestExp"), 10);
            recipe.AddTile(mod.TileType("ExpTable"));
            recipe.SetResult(ItemID.PlatinumCoin);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BiggestExp"));
            recipe.AddTile(mod.TileType("ExpTable"));
            recipe.SetResult(ItemID.GoldCoin, 10);
            recipe.AddRecipe();



            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Exp"), 100);
            recipe.AddTile(mod.TileType("ExpTable"));
            recipe.SetResult(ItemID.SilverCoin);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Exp"));
            recipe.AddTile(mod.TileType("ExpTable"));
            recipe.SetResult(ItemID.CopperCoin);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Exp"), 10000);
            recipe.AddTile(mod.TileType("ExpTable"));
            recipe.SetResult(ItemID.GoldCoin);
            recipe.AddRecipe();



            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BiggerExp"));
            recipe.AddTile(mod.TileType("ExpTable"));
            recipe.SetResult(ItemID.SilverCoin);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BiggerExp"), 100);
            recipe.AddTile(mod.TileType("ExpTable"));
            recipe.SetResult(ItemID.GoldCoin);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BiggerExp"), 10000);
            recipe.AddTile(mod.TileType("ExpTable"));
            recipe.SetResult(ItemID.PlatinumCoin);
            recipe.AddRecipe();
        }
    }
}
