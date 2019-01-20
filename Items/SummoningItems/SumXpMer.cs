using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace GGD.Items.SummoningItems
{
    public class SumXpMer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("High quality Xp Bait");
            Tooltip.SetDefault("Summons the Exp Merchant Town NPC");
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.value = 0;
            item.rare = 2;
            item.useStyle = 4;
            item.useTime = 40;
            item.consumable = true;
            item.useAnimation = 40;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType("ExpMerchant"));
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("ExpMerchant"));
            Main.PlaySound(SoundID.Duck, player.position, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(mod.TileType("GodsWB"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}