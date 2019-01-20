using Terraria.ModLoader;

namespace GGD.Items.MothronItems
{
    public class GGDBrokenHeroStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Broken Hero Staff");
            Tooltip.SetDefault("'Remains of a Great Heros Staff'");
        }
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 36;
            item.value = 0;
            item.rare = 8;
            item.maxStack = 99;
        }
    }
}
