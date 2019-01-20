using Terraria.ModLoader;

namespace GGD.Items.MothronItems
{
    public class GGDMothronShell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mothron Shells");
            Tooltip.SetDefault("'Shell pieces from the Mothrons'");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 30;
            item.value = 0;
            item.rare = 11;
            item.maxStack = 99;
        }
    }
}
