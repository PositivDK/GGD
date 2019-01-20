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
    public class MothronLancer : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mothron Lancer");
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
        }

        private void LookToPlayer()
        {
            Vector2 look = Main.player[npc.target].Center - npc.Center;
            LookInDirection(look);
        }

        private void LookInDirection(Vector2 look)
        {
            float angle = 0.5f * (float)Math.PI;
            if (look.X != 0f)
            {
                angle = (float)Math.Atan(look.Y / look.X);
            }
            else if (look.Y < 0f)
            {
                angle += (float)Math.PI;
            }
            if (look.X < 0f)
            {
                angle += (float)Math.PI;
            }
            npc.rotation = angle;
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
