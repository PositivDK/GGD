using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GGD.Items.Bags
{
    public class GGDStartBag : ModItem
    {
        //Sprite by Jexzy
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("GGD Starter Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}"+ "\nNeeded to get to mod content\nRare chance to contain Great Power");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 64;
            item.height = 64;
            item.rare = 9;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = Main.itemTexture[item.type];
            Vector2 position = item.position - Main.screenPosition;
            Vector2 offsetPosition = new Vector2(texture.Width / 1.6f, texture.Height);
            Color color = new Color(192, 192, 192);

            spriteBatch.Draw(texture, position + offsetPosition, null, color, rotation, texture.Size(), scale *= 0.5f, SpriteEffects.None, 0f);

            return false;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(mod.ItemType("Exp"));
            player.QuickSpawnItem(mod.ItemType("Lvl"));
            player.QuickSpawnItem(mod.ItemType("ClassMaterial"));
            player.QuickSpawnItem(ItemID.WoodenBow);
            player.QuickSpawnItem(ItemID.WoodenSword);
            player.QuickSpawnItem(ItemID.Shuriken);
            player.QuickSpawnItem(ItemID.AmethystStaff);
            player.QuickSpawnItem(ItemID.AmethystStaff);
            player.QuickSpawnItem(ItemID.SlimeStaff);
            player.QuickSpawnItem(ItemID.SlimeStaff);

            if (Main.rand.NextBool(10))
            {
                player.QuickSpawnItem(ItemID.Arkhalis);
            }

            if (player.name == "Wolf")
            {
                player.QuickSpawnItem(mod.ItemType("GodsWorkbench"));
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(mod.TileType("GodsWB"));
            recipe.SetResult(this, 100);
            recipe.AddRecipe();

        }
    }
}
