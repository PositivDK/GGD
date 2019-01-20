using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using GGD;
using Terraria.GameInput;
using Terraria.GameContent;
using System.Collections.Generic;

namespace GGD.Items.LvlS
{
    [AutoloadEquip(EquipType.Wings)]
    public class Lvl : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Status screen");
            Tooltip.SetDefault("Use to show your info in chat\nCan be equipped for bonuses\nGrinding time!");
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 8;
            item.value = 0;
            item.rare = -12;
            item.accessory = true;
            item.useStyle = 4;
            item.useTime = 45;
            item.useAnimation = 45;
        }
        //Gotta find out what this does
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeSpeed += player.GetModPlayer<GGDPlayer>().lvl / 1000f;
            player.meleeDamage += player.GetModPlayer<GGDPlayer>().lvl / 1000f;
            player.rangedDamage += player.GetModPlayer<GGDPlayer>().lvl / 1000f;
            player.magicDamage += player.GetModPlayer<GGDPlayer>().lvl / 1000f;

            player.pickSpeed /= 1f + player.GetModPlayer<GGDPlayer>().lvl / 10f;
            player.tileSpeed *= 1f + player.GetModPlayer<GGDPlayer>().lvl / 10f;
            player.wallSpeed *= 1f + player.GetModPlayer<GGDPlayer>().lvl / 10f;
            player.lifeRegen += player.GetModPlayer<GGDPlayer>().lvl;


            if (player.GetModPlayer<GGDPlayer>().lvl >= 20) { item.defense = player.GetModPlayer<GGDPlayer>().lvl / 2; }
            if (player.GetModPlayer<GGDPlayer>().lvl >= 20 && player.GetModPlayer<GGDPlayer>().lvl < 100) { player.wingTimeMax = 180; }
            if (player.GetModPlayer<GGDPlayer>().lvl >= 100) { player.wingTimeMax = 360; }
            if (player.GetModPlayer<GGDPlayer>().lvl >= 5 && hideVisual == false) { player.wereWolf = true; }

            if (player.name == "Wolf")
            {
                player.pickSpeed /= -0.000001f;
                player.tileSpeed *= 100f;
                player.wallSpeed *= 100f;
                player.lifeRegen += 10000000;
                player.moveSpeed *= 5f;
                item.defense = 100000;
                player.meleeCrit += 100;
                player.meleeDamage *= 100f;
                player.meleeSpeed *= 5f;
                player.wingTimeMax = 1000;
                player.statLifeMax2 = 1000000;
                player.noKnockback = true;
                player.armorPenetration += 100000;
            }
            //Magician
            if (player.GetModPlayer<GGDPlayer>().GGDMagician)
            {
                player.magicDamage *= 2f + player.GetModPlayer<GGDPlayer>().lvl / 50f;
                player.thrownDamage *= 0.75f;
                player.meleeDamage *= 0.5f;
                player.minionDamage *= 0.95f;
                player.rangedDamage *= 0.65f;
                player.statManaMax2 += player.GetModPlayer<GGDPlayer>().lvl * 2;
                player.manaRegen += player.GetModPlayer<GGDPlayer>().lvl;
            }
            //Warrior
            else if (player.GetModPlayer<GGDPlayer>().GGDWarrior)
            {
                player.magicDamage *= 0.5f;
                player.thrownDamage *= 0.9f;
                player.meleeDamage *= 1.3f + player.GetModPlayer<GGDPlayer>().lvl / 50f;
                player.minionDamage *= 0.95f;
                player.rangedDamage *= 0.65f;
                player.armorPenetration += player.GetModPlayer<GGDPlayer>().lvl / 2;
            }
            //Ninja
            else if (player.GetModPlayer<GGDPlayer>().GGDNinja)
            {
                player.magicDamage *= 0.95f;
                player.thrownDamage *= 2f + player.GetModPlayer<GGDPlayer>().lvl * 0.1f;
                player.meleeDamage *= 1.15f + player.GetModPlayer<GGDPlayer>().lvl*0.0085f;
                player.minionDamage *= 0.5f;
                player.rangedDamage *= 1.2f + player.GetModPlayer<GGDPlayer>().lvl*0.0085f;
                player.armorPenetration += player.GetModPlayer<GGDPlayer>().lvl / 2;
            }
            //Ranger
            else if (player.GetModPlayer<GGDPlayer>().GGDRanger)
            {
                player.magicDamage *= 0.75f;
                player.thrownDamage *= 0.65f;
                player.meleeDamage *= 0.7f;
                player.minionDamage *= 1f;
                player.rangedDamage *= 1.65f + player.GetModPlayer<GGDPlayer>().lvl / 50f;
            }
            //Summoner
            else if (player.GetModPlayer<GGDPlayer>().GGDSummoner)
            {
                player.magicDamage *= 1.5f + player.GetModPlayer<GGDPlayer>().lvl / 100f;
                player.thrownDamage *= 0.6f;
                player.meleeDamage *= 0.7f;
                player.minionDamage *= 2f + player.GetModPlayer<GGDPlayer>().lvl * 0.03f;
                player.rangedDamage *= 0.7f;
                player.manaRegen += player.GetModPlayer<GGDPlayer>().lvl;
                player.statManaMax2 += player.GetModPlayer<GGDPlayer>().lvl;
                player.maxMinions += player.GetModPlayer<GGDPlayer>().lvl / 20;
                if(player.GetModPlayer<GGDPlayer>().lvl == 100) { player.maxMinions += 1; }
            }
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            if (player.name == "Wolf")
            {
                ascentWhenFalling = 1f;
                ascentWhenRising = 0.5f;
                maxCanAscendMultiplier = 5f;
                maxAscentMultiplier = 10f;
                constantAscend = 0.5f;
            }
            else
            {
                
                if (player.GetModPlayer<GGDPlayer>().lvl >= 20)
                {
                    ascentWhenFalling = 0.85f;
                    ascentWhenRising = 0.15f;
                    maxCanAscendMultiplier = 1f;
                    maxAscentMultiplier = 3f;
                    constantAscend = 0.135f;
                }

                else
                {
                    ascentWhenFalling *= 1f;
                    ascentWhenRising *= 1f;
                    maxCanAscendMultiplier *= 1f;
                    maxAscentMultiplier *= 1f;
                    constantAscend *= 1f;
                }
            }
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            if (player.name == "Wolf")
            {
                speed = 200f;
                acceleration *= 5f;
            }
            else
            {
                if (player.GetModPlayer<GGDPlayer>().lvl >= 20)
                {
                    speed = 9f;
                    acceleration *= 2.5f;
                }

                else
                {
                    speed *= 1f;
                    acceleration *= 1f;
                }
            }
        }

        public override bool UseItem(Player player)
        {
            Main.NewText("|Name/lvl: " + player.name + " : " + player.GetModPlayer<GGDPlayer>().lvl, 32, 178, 170);
            Main.NewText("|Max level/class: " + player.GetModPlayer<GGDPlayer>().maxLvl + " : " + player.GetModPlayer<GGDPlayer>().GGDClassRep());
            Main.NewText("|Exp: " + player.GetModPlayer<GGDPlayer>().exp);
            Main.NewText("|Bonus:");
            if (player.GetModPlayer<GGDPlayer>().lvl >= 5)
            {
                Main.NewText("|Werewolf");
            }
            
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddRecipe(); 
        }
    }
}
