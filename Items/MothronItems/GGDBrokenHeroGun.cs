using Terraria.ModLoader;

namespace GGD.Items.MothronItems
{
    public class GGDBrokenHeroGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Broken Hero Gun");
            Tooltip.SetDefault("'Remains of a Great Heros Gun'");
        }
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 20;
            item.value = 0;
            item.rare = 8;
            item.maxStack = 99;
        }
    }
}
