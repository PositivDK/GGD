using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using GGD;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GGD.Items.LvlS
{
    public class Levels : ModItem
    {
        //Sprite by Jexzy
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Free Levels");
            Tooltip.SetDefault("Used for leveling");
        }
        public override void SetDefaults()
        {
            item.width = 64;
            item.height = 64;
            item.value = 1;
            item.rare = 7;
            item.maxStack = 999999;
            item.consumable = true;
            item.useAnimation = 2;
            item.useTime = 2;
            item.useStyle = 4;
            item.autoReuse = true;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = Main.itemTexture[item.type];
            Vector2 position = item.position - Main.screenPosition;
            Vector2 offsetPosition = new Vector2(texture.Width / 1.6f, texture.Height);
            Color color = new Color(255, 255, 255);

            spriteBatch.Draw(texture, position + offsetPosition, null, color, rotation, texture.Size(), scale *= 0.25f, SpriteEffects.None, 0f);
           
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<GGDPlayer>().lvl += 1;
            return true;
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
