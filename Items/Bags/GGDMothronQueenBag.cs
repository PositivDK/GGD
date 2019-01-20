using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace GGD.Items.Bags
{
    public class GGDMothronQueenBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 32;
            item.height = 32;
            item.rare = 8;
            item.expert = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            player.TryGettingDevArmor();

            if (Main.rand.NextBool(7))
            {
                player.QuickSpawnItem(mod.ItemType("MothronQueenMask"));
            }

            if (Main.rand.NextBool(10))
            {
                player.QuickSpawnItem(mod.ItemType("MothronQueenTrophy"));
            }

            switch (Main.rand.Next(1, 11))
            {
                case 1:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroBow"));
                    break;
                case 2:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroGrimoire"));
                    break;
                case 3:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroGun"));
                    break;
                case 4:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroKnife"));
                    break;
                case 5:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroLance"));
                    break;
                case 6:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroMace"));
                    break;
                case 7:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroOrb"));
                    break;
                case 8:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroSpear"));
                    break;
                case 9:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroStaff"));
                    break;
                case 10:
                    player.QuickSpawnItem(ItemID.BrokenHeroSword);
                    break;
                default:
                    break;
            }

            switch (Main.rand.Next(1, 11))
            {
                case 1:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroBow"));
                    break;
                case 2:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroGrimoire"));
                    break;
                case 3:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroGun"));
                    break;
                case 4:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroKnife"));
                    break;
                case 5:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroLance"));
                    break;
                case 6:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroMace"));
                    break;
                case 7:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroOrb"));
                    break;
                case 8:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroSpear"));
                    break;
                case 9:
                    player.QuickSpawnItem(mod.ItemType("GGDBrokenHeroStaff"));
                    break;
                case 10:
                    player.QuickSpawnItem(ItemID.BrokenHeroSword);
                    break;
                default:
                    break;
            }

            player.QuickSpawnItem(mod.ItemType("GGDMothronShell"), Main.rand.Next(5, 20));
        }
    }
}
