using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace GGD.Projectiles
{
    public class KnifeHostile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knives");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 32;
            projectile.aiStyle = 1;
            projectile.friendly = false;
            projectile.ranged = true;
            projectile.timeLeft = 200;
            projectile.maxPenetrate = 3;
            projectile.penetrate = 3;
            projectile.hostile = true;
            projectile.tileCollide = false;
            aiType = 5;
        }
    }
}
