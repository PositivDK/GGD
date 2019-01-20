using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace GGD
{
    public class GGDPlayer : ModPlayer
    {
        public int lvl; 
        public int maxLvl;
        public int exp;
        public bool lvlCap1;
        public bool lvlCap2;
        public bool lvlCap3;
        public bool lvlCap4;
        public bool lvlCap5;
        public bool lvlCap6;
        public bool lvlCap7;
        public bool lvlCap8;
        public bool lvlCap9;
        public bool GGDWarrior;
        public bool GGDMagician;
        public bool GGDRanger;
        public bool GGDSummoner;
        public bool GGDNinja;
        public bool capLvl;
        

        //Calls what class you are playing as
        public string GGDClassRep()
        {
            if (GGDWarrior == true) { return "Warrior"; }
            if (GGDMagician == true) { return "Magician"; }
            if (GGDRanger == true) { return "Ranger"; }
            if (GGDSummoner == true) { return "Summoner"; }
            if (GGDNinja == true) { return "Ninja"; }
            else { return "No Class"; }
        }

        public int GetLvl()
        {
            if (exp >= 39 && exp < 86) { return 1; }
            if (exp < 144 && exp >= 86) { return 2; }
            if (exp < 213 && exp >= 144) { return 3; }
            if (exp < 296 && exp >= 213) { return 4; }
            if (exp < 395 && exp >= 296) { return 5; }
            if (exp < 512 && exp >= 395) { return 6; }
            if (exp < 650 && exp >= 512) { return 7; }
            if (exp < 813 && exp >= 650) { return 8; }
            if (exp < 1004 && exp >= 813) { return 9; }
            if (exp < 1227 && exp >= 1004) { return 10; }
            if (exp < 1487 && exp >= 1227) { return 11; }
            if (exp < 1790 && exp >= 1487) { return 12; }
            if (exp < 2142 && exp >= 1790) { return 13; }
            if (exp < 2550 && exp >= 2142) { return 14; }
            if (exp < 3022 && exp >= 2550) { return 15; }
            if (exp < 3568 && exp >= 3022) { return 16; }
            if (exp < 4197 && exp >= 3568) { return 17; }
            if (exp < 4923 && exp >= 4197) { return 18; }
            if (exp < 5758 && exp >= 4923) { return 19; }
            if (exp < 6717 && exp >= 5758) { return 20; }
            if (exp < 7819 && exp >= 6717) { return 21; }
            if (exp < 9083 && exp >= 7819) { return 22; }
            if (exp < 10531 && exp >= 9083) { return 23; }
            if (exp < 12188 && exp >= 10531) { return 24; }
            if (exp < 14084 && exp >= 12188) { return 25; }
            if (exp < 16251 && exp >= 14084) { return 26; }
            if (exp < 18726 && exp >= 16251) { return 27; }
            if (exp < 21549 && exp >= 18726) { return 28; }
            if (exp < 24769 && exp >= 21549) { return 29; }
            if (exp < 28439 && exp >= 24769) { return 30; }
            if (exp < 32618 && exp >= 28439) { return 31; }
            if (exp < 37375 && exp >= 32618) { return 32; }
            if (exp < 42786 && exp >= 37375) { return 33; }
            if (exp < 48938 && exp >= 42786) { return 34; }
            if (exp < 55929 && exp >= 48938) { return 35; }
            if (exp < 63870 && exp >= 55929) { return 36; }
            if (exp < 72885 && exp >= 63870) { return 37; }
            if (exp < 83114 && exp >= 72885) { return 38; }
            if (exp < 94717 && exp >= 83114) { return 39; }
            if (exp < 107872 && exp >= 94717) { return 40; }
            if (exp < 122781 && exp >= 107872) { return 41; }
            if (exp < 139672 && exp >= 122781) { return 42; }
            if (exp < 158800 && exp >= 139672) { return 43; }
            if (exp < 180454 && exp >= 158800) { return 44; }
            if (exp < 204961 && exp >= 180454) { return 45; }
            if (exp < 232685 && exp >= 204961) { return 46; }
            if (exp < 264039 && exp >= 232685) { return 47; }
            if (exp < 299489 && exp >= 264039) { return 48; }
            if (exp < 339557 && exp >= 299489) { return 49; }
            if (exp < 384831 && exp >= 339557) { return 50; }
            if (exp < 435974 && exp >= 384831) { return 51; }
            if (exp < 493732 && exp >= 435974) { return 52; }
            if (exp < 558941 && exp >= 493732) { return 53; }
            if (exp < 632547 && exp >= 558941) { return 54; }
            if (exp < 715609 && exp >= 632547) { return 55; }
            if (exp < 809319 && exp >= 715609) { return 56; }
            if (exp < 915020 && exp >= 809319) { return 57; }
            if (exp < 1034218 && exp >= 915020) { return 58; }
            if (exp < 1168608 && exp >= 1034218) { return 59; }
            if (exp < 1320094 && exp >= 1168608) { return 60; }
            if (exp < 1490816 && exp >= 1320094) { return 61; }
            if (exp < 1683180 && exp >= 1490816) { return 62; }
            if (exp < 1899885 && exp >= 1683180) { return 63; }
            if (exp < 2143968 && exp >= 1899885) { return 64; }
            if (exp < 2418836 && exp >= 2143968) { return 65; }
            if (exp < 2728316 && exp >= 2418836) { return 66; }
            if (exp < 3076708 && exp >= 2728316) { return 67; }
            if (exp < 3468838 && exp >= 3076708) { return 68; }
            if (exp < 3910123 && exp >= 3468838) { return 69; }
            if (exp < 4406647 && exp >= 3910123) { return 70; }
            if (exp < 4965236 && exp >= 4406647) { return 71; }
            if (exp < 5593552 && exp >= 4965236) { return 72; }
            if (exp < 6300196 && exp >= 5593552) { return 73; }
            if (exp < 7094815 && exp >= 6300196) { return 74; }
            if (exp < 7988237 && exp >= 7094815) { return 75; }
            if (exp < 8992606 && exp >= 7988237) { return 76; }
            if (exp < 10121547 && exp >= 8992606) { return 77; }
            if (exp < 11390345 && exp >= 10121547) { return 78; }
            if (exp < 12816141 && exp >= 11390345) { return 79; }
            if (exp < 14418159 && exp >= 12816141) { return 80; }
            if (exp < 16217956 && exp >= 14418159) { return 81; }
            if (exp < 18239707 && exp >= 16217956) { return 82; }
            if (exp < 20510514 && exp >= 18239707) { return 83; }
            if (exp < 23060763 && exp >= 20510514) { return 84; }
            if (exp < 25924518 && exp >= 23060763) { return 85; }
            if (exp < 29139962 && exp >= 25924518) { return 86; }
            if (exp < 32749893 && exp >= 29139962) { return 87; }
            if (exp < 36802279 && exp >= 32749893) { return 88; }
            if (exp < 41350875 && exp >= 36802279) { return 89; }
            if (exp < 46455921 && exp >= 41350875) { return 90; }
            if (exp < 52184918 && exp >= 46455921) { return 91; }
            if (exp < 58613495 && exp >= 52184918) { return 92; }
            if (exp < 65826386 && exp >= 58613495) { return 93; }
            if (exp < 73918518 && exp >= 65826386) { return 94; }
            if (exp < 82996231 && exp >= 73918518) { return 95; }
            if (exp < 93178639 && exp >= 82996231) { return 96; }
            if (exp < 104599160 && exp >= 93178639) { return 97; }
            if (exp < 117407220 && exp >= 104599160) { return 98; }
            if (exp < 131770168 && exp >= 117407220) { return 99; }
            if (exp >= 131770168) { return 100; }    
            else { return lvl; }
        }

        public int CanLvl()
        {

            if (lvl > maxLvl) { return maxLvl; }
            else { return lvl; }
        }

        public override void Initialize()
        {

            lvl = 0;
            maxLvl = 10;
            capLvl = false;
            lvlCap1 = false;
            lvlCap2 = false;
            lvlCap3 = false;
            lvlCap4 = false;
            lvlCap5 = false;
            lvlCap6 = false;
            lvlCap7 = false;
            lvlCap8 = false;
            lvlCap9 = false;
            GGDWarrior = false;
            GGDMagician = false;
            GGDRanger = false;
            GGDSummoner = false;
            GGDNinja = false;
            exp = 0;
    }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"capLvl", capLvl },
                {"exp", exp },
                {"lvl", lvl },
                {"maxLvl", maxLvl },
                {"lvlCap1", lvlCap1 },
                {"lvlCap2", lvlCap2 },
                {"lvlCap3", lvlCap3 },
                {"lvlCap4", lvlCap4 },
                {"lvlCap5", lvlCap5 },
                {"lvlCap6", lvlCap6 },
                {"lvlCap7", lvlCap7 },
                {"lvlCap8", lvlCap8 },
                {"lvlCap9", lvlCap9 },
                {"GGDNinja", GGDNinja },
                {"GGDSummoner", GGDSummoner },
                {"GGDRanger", GGDRanger },
                {"GGDMagician", GGDMagician },
                {"GGDWarrior", GGDWarrior },
            };
        }

        public override void Load(TagCompound tag)
        {
            capLvl = tag.GetBool("capLvl");
            exp = tag.GetInt("exp");
            lvl = tag.GetInt("lvl");
            maxLvl = tag.GetInt("maxLvl");
            lvlCap1 = tag.GetBool("lvlCap1");
            lvlCap2 = tag.GetBool("lvlCap2");
            lvlCap3 = tag.GetBool("lvlCap3");
            lvlCap4 = tag.GetBool("lvlCap4");
            lvlCap5 = tag.GetBool("lvlCap5");
            lvlCap6 = tag.GetBool("lvlCap6");
            lvlCap7 = tag.GetBool("lvlCap7");
            lvlCap8 = tag.GetBool("lvlCap8");
            lvlCap9 = tag.GetBool("lvlCap9");
            GGDNinja = tag.GetBool("GGDNinja");
            GGDSummoner = tag.GetBool("GGDSummoner");
            GGDRanger = tag.GetBool("GGDRanger");
            GGDMagician = tag.GetBool("GGDMagician");
            GGDWarrior = tag.GetBool("GGDWarrior");
        }
        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
        {
            Item GGDitem = new Item();
            GGDitem.SetDefaults(mod.ItemType("GGDStartBag"));
            GGDitem.stack = 1;
            items.Add(GGDitem);   //How to add more starting items.

            /*Item GGDitem1 = new Item();
            GGDitem1.SetDefaults(ItemID.TerraBlade);
            GGDitem1.stack = 1;
            items.Add(GGDitem1);

            Item GGDitem2 = new Item();
            GGDitem2.SetDefaults(mod.ItemType("Exp"));
            GGDitem2.stack = 999999;
            items.Add(GGDitem2);*/
            
        }
    }
}
