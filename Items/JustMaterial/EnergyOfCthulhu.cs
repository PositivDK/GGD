using Terraria.ID;
using Terraria.ModLoader;

namespace GGD.Items.JustMaterial
{
    public class EnergyOfCthulhu : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Energy of Cthulhu");
            Tooltip.SetDefault("Remnants of energy from Eye of Cthulhu");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 32;
            item.value = 0;
            item.rare = 2;
            item.maxStack = 10;
        }
    }
}
