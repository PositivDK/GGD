using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GGD.Items
{
    public class KnivesItem : ModItem
    {
        public override void SetDefaults()
        {
           //Taken from ExampleJavelin.cs in the tmod exaplemod
            item.shootSpeed = 10f;
            item.damage = 40;
            item.knockBack = 5f;
            item.useStyle = 1;
            item.useAnimation = 25;
            item.useTime = 25;
            item.width = 28;
            item.height = 28;
            item.maxStack = 999;
            item.rare = 5;

            item.consumable = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(copper: 1);
            item.shoot = mod.ProjectileType("DropKnife");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 15f * 0.0174f;
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
            double deltaAngle = spread / 8f;
            double offsetAngle;
            int i;
            for (i = 0; i < 8; i++)
            {
                offsetAngle = startAngle + deltaAngle * i;
                Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), item.shoot, damage, knockBack, item.owner);
            }
            /*
            int numberProjectiles = 5;

            float rotation = MathHelper.ToRadians(20);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }*/
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }

    }
}
