using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace GGD.Items.Class
{
    public class ClassRanger : ModItem
    {
        public override string Texture { get { return "Terraria/Item_" + ItemID.WoodenBow; } }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ranger class");
            Tooltip.SetDefault("Use to set class to Ranger\nBoosts ranged damage");
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
            player.GetModPlayer<GGDPlayer>().GGDWarrior = false;
            player.GetModPlayer<GGDPlayer>().GGDRanger = true;
            player.GetModPlayer<GGDPlayer>().GGDSummoner = false;
            player.GetModPlayer<GGDPlayer>().GGDNinja = false;
            player.GetModPlayer<GGDPlayer>().GGDMagician = false;
            return true;
        }
    }
}
