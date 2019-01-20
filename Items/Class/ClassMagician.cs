using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace GGD.Items.Class
{
    public class ClassMagician : ModItem
    {
        public override string Texture { get { return "Terraria/Item_" + ItemID.WaterBolt; } }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magician class");
            Tooltip.SetDefault("Use to set class to Magician\nBoosts magic damage");
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
            player.GetModPlayer<GGDPlayer>().GGDRanger = false;
            player.GetModPlayer<GGDPlayer>().GGDSummoner = false;
            player.GetModPlayer<GGDPlayer>().GGDNinja = false;
            player.GetModPlayer<GGDPlayer>().GGDMagician = true;
            return true;
        }
    }
}
