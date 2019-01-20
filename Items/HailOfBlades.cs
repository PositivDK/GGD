using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace GGD.Items
{
	public class HailOfBlades : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hail of Blades");
			Tooltip.SetDefault("Calls forth falling knives from the sky");
		}
		public override void SetDefaults()
		{
			item.damage = 200;
			item.melee = true;
			item.width = 60;
			item.height = 60;
			item.useTime = 6;
			item.useAnimation = 6;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = 9;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("Knives");
            item.shootSpeed = 20f;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            //Taken from ExampleSword in the examplemod
            Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            for (int i = 0; i < 5; i++)
            {
                position = player.Center + new Vector2((-(float)Main.rand.Next(0, 401) * player.direction), -600f);
                position.Y -= (100 * i);
                Vector2 heading = target - position;
                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }
                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }
                heading.Normalize();
                heading *= new Vector2(speedX, speedY).Length();
                speedX = heading.X;
                speedY = heading.Y + Main.rand.Next(-40, 41) * 0.02f;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage * 10, knockBack, player.whoAmI, 0f, ceilingLimit);
            }
            return false;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("KnivesItem"), 400);
            recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
