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
        [AutoloadBossHead]
        public class MothronQueen2 : ModNPC
        {
            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("Mothron Queen");
                Main.npcFrameCount[npc.type] = 1;
            }

            public override void SetDefaults()
            {
                npc.aiStyle = -1;
                npc.lifeMax = 250000;
                npc.damage = 400;
                npc.defense = 150;
                npc.knockBackResist = 0f;
                npc.dontTakeDamage = false;
                npc.width = 320;
                npc.height = 320;
                npc.value = Item.buyPrice(0, 50, 0, 0);
                npc.npcSlots = 1f;
                npc.boss = true;
                npc.lavaImmune = true;
                npc.noGravity = true;
                npc.noTileCollide = true;
                npc.HitSound = SoundID.NPCHit1;
                npc.DeathSound = SoundID.NPCDeath1;
                npc.buffImmune[24] = true;
                music = MusicID.Boss2;
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
            if (Main.rand.NextBool(10))
            {
                Item.NewItem(npc.getRect(), mod.ItemType("MothronQueenTrophy"));
            }

            if (Main.expertMode)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("GGDMothronQueenBag"));
            }

            else
            {
                if (Main.rand.NextBool(7))
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("MothronQueenMask"));
                }
                Item.NewItem(npc.getRect(), mod.ItemType("GGDMothronShell"), Main.rand.Next(5, 10));
            }

            if (!GGDWorld.downedMothronQueen)
            {
                GGDWorld.downedMothronQueen = true;
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
                }
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
            {
                name = "Mothron Queen";
                potionType = ItemID.GreaterHealingPotion;
            }

            public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
            {
                return true;
            }
        }
    
}
