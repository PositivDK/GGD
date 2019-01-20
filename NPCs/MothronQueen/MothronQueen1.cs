
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GGD.NPCs.MothronQueen
{
     [AutoloadBossHead]
     public class MothronQueen1 : ModNPC
     {
         public override void SetStaticDefaults()
         {
             DisplayName.SetDefault("Mothron Queen");
             Main.npcFrameCount[npc.type] = 1;
         }

         public override void SetDefaults()
         {
             npc.aiStyle = -1;
             npc.lifeMax = 1;
             npc.damage = 0;
             npc.defense = 0;
             npc.knockBackResist = 0f;
             npc.dontTakeDamage = true;
             npc.width = 320;
             npc.height = 320;
             npc.value = Item.buyPrice(0, 50, 0, 0);
             npc.npcSlots = 1f;
             npc.boss = true;
             npc.lavaImmune = true;
             npc.noGravity = false;
             npc.noTileCollide = false;
             npc.HitSound = SoundID.NPCHit1;
             npc.DeathSound = null; //SoundID.NPCDeath1;
             npc.buffImmune[24] = true;
             music = MusicID.Boss2;
         }

         public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
         {
             npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
             npc.damage = (int)(npc.damage * 0.6f);
         }

         internal float time = 0;
         internal int wave = 0;
        internal int cooldown = 0;
         
         public override void AI()
         {
            while (time > 0)
            {
                time--;
            }

            if (time == 0 && wave == 0 && !NPC.AnyNPCs(mod.NPCType("MothronLancer")) && !NPC.AnyNPCs(mod.NPCType("MothronGeneral")) 
                && !NPC.AnyNPCs(mod.NPCType("MothronRanger")) && !NPC.AnyNPCs(mod.NPCType("MothronMagi")))
            {
                SpawnMothrons();
                wave++;
                time += 3600f;
            }

            if (time == 0 && wave == 1 && !NPC.AnyNPCs(mod.NPCType("MothronLancer")) && !NPC.AnyNPCs(mod.NPCType("MothronGeneral")) 
                && !NPC.AnyNPCs(mod.NPCType("MothronRanger")) && !NPC.AnyNPCs(mod.NPCType("MothronMagi")))
            {
                cooldown = 3000;
                while (cooldown > 0)
                {
                    cooldown--;
                }
                SpawnMothrons();
                wave++;
                time += 3600f;
            }

            if (wave == 2 && time == 0 && !NPC.AnyNPCs(mod.NPCType("MothronLancer")) && !NPC.AnyNPCs(mod.NPCType("MothronGeneral")) 
                && !NPC.AnyNPCs(mod.NPCType("MothronRanger")) && !NPC.AnyNPCs(mod.NPCType("MothronMagi")))
            {
                SpawnMothrons();
                Main.PlaySound(SoundID.Roar, npc.position, 0);
                Main.NewText("The Mothron Queen broke her shell", 255, 69, 0);
                Item.NewItem(npc.getRect(), mod.ItemType("GGDMothronShell"), Main.rand.Next(5, 10));
                NPC.NewNPC((int)npc.position.X + npc.width / 2, (int)npc.position.Y + npc.height, mod.NPCType("MothronQueen2"));
                npc.life -= 1;
            }
         }
         
         public void SpawnMothrons() {
            for (int k = 0; k < 5; k++)
            {
                switch (Main.rand.Next(0, 3))
                {
                    case 0:
                        NPC.NewNPC((int)npc.position.X + Main.rand.Next(0, npc.width), (int)npc.position.Y + Main.rand.Next(0, npc.height), mod.NPCType("MothronLancer"));
                        break;
                    case 1:
                        NPC.NewNPC((int)npc.position.X + Main.rand.Next(0, npc.width), (int)npc.position.Y + Main.rand.Next(0, npc.height), mod.NPCType("MothronMagi"));
                        break;
                    case 2:
                        NPC.NewNPC((int)npc.position.X + Main.rand.Next(0, npc.width), (int)npc.position.Y + Main.rand.Next(0, npc.height), mod.NPCType("MothronRanger"));
                        break;
                    default:
                        NPC.NewNPC((int)npc.position.X + Main.rand.Next(0, npc.width), (int)npc.position.Y + Main.rand.Next(0, npc.height), mod.NPCType("MothronGeneral"));
                        break;
                }
            }
        }

         public override bool PreNPCLoot() 
         {
             return true;
         }
     }
}
