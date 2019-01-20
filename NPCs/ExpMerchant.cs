using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace GGD.NPCs
{
    [AutoloadHead]
    public class ExpMerchant : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
            // DisplayName.SetDefault("Example Person");
            Main.npcFrameCount[npc.type] = 25; //First 16 are walking animation. 17 and 18 are rock paper scissor and greetings. 19 is sit frame.
            NPCID.Sets.ExtraFramesCount[npc.type] = 9; //Last 4 is attack animation. 20 and 21 are a wink?
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return true;
            
        }

        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            return true;
        }

        private static int count = 0;

        public override void AI()
        {
            if (Main.eclipse && Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && !NPC.AnyNPCs(NPCID.Mothron) && count < 10)
            {
                NPC.NewNPC((int)npc.position.X, (int)npc.position.Y - 1000, NPCID.Mothron);
                count++;
            }

            if (!Main.dayTime) count = 0;
        }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(4))
            {
                case 0:
                    return "Hoarder";
                case 1:
                    return "Jogen";
                case 2:
                    return "Dealer";
                default:
                    return "Ben";
            }
        }

        public override string GetChat()
        {
            return "Got the exp?";
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton) { shop = true; }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(mod.ItemType("BetterFlyingDagger"));
            shop.item[nextSlot].shopCustomPrice = new int?(5000); 
            shop.item[nextSlot].shopSpecialCurrency = GGD.CustomCurrencyID;
            nextSlot++;
        }

        
        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), mod.ItemType<Items.AreoOrt>());
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = mod.ProjectileType("Knives");
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }

        /*public override void TownNPCAttackShoot(ref bool inBetweenShots)
        {
            npc.t
            Projectile.NewProjectile(npc.position,);
        }*/




    }
}
