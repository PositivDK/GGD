using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace GGD.Projectiles
{
    public class DropKnife : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("DropKnife");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 32;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.timeLeft = 100;
            aiType = 5;
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                // Drop a javelin item, 1 in 15 chance (6,66% chance)
                int item =
                Main.rand.NextBool(15)
                    ? Item.NewItem(projectile.getRect(), mod.ItemType("KnivesItem"))
                    : 0;
            }

        }
    }
}
