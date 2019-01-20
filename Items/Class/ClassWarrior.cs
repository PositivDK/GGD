using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GGD.Items.Class
{
    public class ClassWarrior : ModItem
    {
        public override string Texture { get { return "Terraria/Item_" + ItemID.WoodenSword; } }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warrior class");
            Tooltip.SetDefault("Use to sert class to Warrior\nBoosts melee damage");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 32;
            item.value = 0;
            item.rare = -12;
            item.maxStack = 1;
            item.useStyle = 4;
            item.useTime = 45;
            item.useAnimation = 45;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<GGDPlayer>().GGDWarrior = true;
            player.GetModPlayer<GGDPlayer>().GGDRanger = false;
            player.GetModPlayer<GGDPlayer>().GGDSummoner = false;
            player.GetModPlayer<GGDPlayer>().GGDNinja = false;
            player.GetModPlayer<GGDPlayer>().GGDMagician = false;
            return true;
        }
    }
}
