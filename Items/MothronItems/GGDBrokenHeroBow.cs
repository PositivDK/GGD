using Terraria.ModLoader;

namespace GGD.Items.MothronItems
{
    public class GGDBrokenHeroBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Broken Hero Bow");
            Tooltip.SetDefault("'Remains of a Great Heros Bow'");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 36;
            item.value = 0;
            item.rare = 8;
            item.maxStack = 99;
        }
    }
}
