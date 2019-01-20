using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GGD.NPCs.MothronQueen
{
    public class MothronRanger : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mothron Ranger");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 25000;
            npc.damage = 200;
            npc.defense = 100;
            npc.knockBackResist = 0f;
            npc.dontTakeDamage = false;
            npc.width = 160;
            npc.height = 160;
            npc.value = Item.buyPrice(0, 50, 0, 0);
            npc.npcSlots = 1f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }

        public override void AI()
        {
            Player player = Main.player[npc.target];
            npc.TargetClosest(true);
            Vector2 targetPosition = Main.player[npc.target].position;
            npc.ai[0]++;
            if (npc.ai[0] <= 90)
            {
                if (targetPosition.X < npc.Center.X && npc.velocity.X > -8)
                {
                    npc.velocity.X -= 0.22f;
                    npc.ai[0]++;
                }

                if (targetPosition.X > npc.Center.X && npc.velocity.X < 8)
                {
                    npc.velocity.X += 0.22f;
                    npc.ai[0]++;
                }

                if (targetPosition.Y < npc.Center.Y)
                {
                    if (npc.velocity.Y < 0 && npc.velocity.Y > -4)
                        npc.velocity.Y -= 0.7f;
                    else { npc.velocity.Y -= 0.1f; }
                    npc.ai[0]++;
                }

                if (targetPosition.Y > npc.Center.Y)
                {
                    if (npc.velocity.Y > 0 && npc.velocity.Y < 4)
                        npc.velocity.Y += 0.7f;
                    else { npc.velocity.Y += 0.1f; }
                    npc.ai[0]++;
                }
            }

            if(npc.ai[0] > 90)
            {
                ​float Speed = 12f;

                Vector2 position = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));

                int damage = 200;
                int type = mod.ProjectileType("KnifeHostile");
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 17);

                float rotation = (float)Math.Atan2(position.Y - (double)Main.player[npc.target].Center.Y, 
                    position.X - Main.player[npc.target].Center.X);
                for (int i = 0; i < 3; i++)
                {
                    int num54 = Projectile.NewProjectile(position.X, position.Y, (float)(Math.Cos(rotation+(double)i/5f) * Speed * -1),
                        (float)(Math.Sin(rotation+(double)i/5f) * Speed * -1), type, damage, 0f, 0);
                }
                for (int i = 1; i < 3; i++)
                {
                    int num54 = Projectile.NewProjectile(position.X, position.Y, (float)((Math.Cos(rotation + (double)i / 5f) * Speed) * -1),
                        (float)(Math.Sin(rotation - (double)i / 5f) * Speed * -1), type, damage, 0f, 0);
                }
                npc.ai[0] = 0;
            }
        }

        public override bool PreNPCLoot()
        {
            return true;
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), mod.ItemType("GGDMothronShell"), Main.rand.Next(5, 10));
            Item.NewItem(npc.getRect(), ItemID.Heart, 5);
        }

        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            return true;
        }
    }
}
