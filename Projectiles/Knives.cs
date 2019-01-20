using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace GGD.Projectiles
{
    public class Knives : ModProjectile
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
            projectile.friendly = true;
            projectile.melee = true;
            projectile.timeLeft = 100;
            projectile.maxPenetrate = -1;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            aiType = 5;
        }

        /*public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.StrikeNPCNoInteraction(target.lifeMax, 0f, -target.direction);
        }*/
    }
}