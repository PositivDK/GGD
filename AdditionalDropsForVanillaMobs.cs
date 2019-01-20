using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using GGD.Items;
using GGD;

namespace GGD
{ 
    public class AdditionalDropsForVanillaMobs : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            //makes all vanilla mobs drop 1 or 2 exp orps
            if (npc.type > -66 && Main.rand.Next(1,6) == 3 && npc.type != 4 && npc.type != 35 && npc.type != 113 && npc.type != 127 && npc.type != 262 
                && npc.type != 370 && npc.type != 245 && npc.type != 398 && npc.type != 370 && npc.type != 551 && npc.type != 477)
            { 
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("Exp"), Main.rand.Next(1, 2));
            }

            //makes eye of cthulhu the first lvlcapinc 
            if (npc.type == 4)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("LvlcapInc"), 1);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("Exp"), Main.rand.Next(5,25));
                if (Main.rand.NextBool(6))
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("EnergyOfCthulhu"), 1);
                }
            }

            //Skeletron
            if (npc.type == 35)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("LvlcapInc2"), 1);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("Exp"), Main.rand.Next(10, 35));
            }


            //Wall of Flesh
            if (npc.type == 113)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("LvlcapInc3"), 1);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("Exp"), Main.rand.Next(5, 40));
            }

            //Skeletron Prime
            if (npc.type == 127)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("LvlcapInc4"), 1);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("Exp"), Main.rand.Next(40, 75));
            }

            //Plantera
            if (npc.type == 262)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("LvlcapInc5"), 1);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("Exp"), Main.rand.Next(45, 80));
            }

            //Golem
            if (npc.type == 245)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("LvlcapInc6"), 1);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("Exp"), Main.rand.Next(55, 90));
            }

            //Moonlord
            if (npc.type == 398)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("LvlcapInc7"), 1);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("Exp"), Main.rand.Next(150, 300));
            }

            //Betsy
            if (npc.type == 551)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("LvlcapInc8"), 1);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("Exp"), Main.rand.Next(100, 200));
            }

            //Duke Fishron
            if (npc.type == 370)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("LvlcapInc9"), 1);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("Exp"), Main.rand.Next(100, 150));
            }

            //Mothron
            if (npc.type == 477)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width / 2, npc.height / 2, mod.ItemType("Exp"), Main.rand.Next(10, 50));
                /*if (Main.rand.NextBool(3) && !NPC.AnyNPCs(mod.NPCType("MothronQueen1")) && !NPC.AnyNPCs(mod.NPCType("MothronQueen2")))
                {
                    Main.PlaySound(SoundID.Roar, npc.position, 0);
                    NPC.NewNPC((int)npc.position.X - npc.width, (int)npc.position.Y - npc.height, mod.NPCType("MothronQueen1"));
                }*/
            }
        }
    }
}
