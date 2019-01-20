using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using GGD;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace GGD.Items.LvlS
{
    public class BiggestExp : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Densest Exp Orb");
            Tooltip.SetDefault("As dense as they get");
            // ticksperframe, frameCount
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 3));
            ItemID.Sets.AnimatesAsSoul[item.type] = false;
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = false;
        }

        public override void SetDefaults()
        {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.SoulofSight);
            item.width = 16;
            item.height = 16;
            item.value = 1;
            item.rare = -12;
            item.maxStack = 999999;
            item.consumable = true;
            item.useAnimation = 2;
            item.useTime = 2;
            item.useStyle = 4;
            item.autoReuse = true;
            item.noUseGraphic = true;
        }

        public override void GrabRange(Player player, ref int grabRange)
        {
            grabRange *= 3;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<GGDPlayer>().exp < 2000000000)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<GGDPlayer>().exp += 1000000;
            player.GetModPlayer<GGDPlayer>().lvl = player.GetModPlayer<GGDPlayer>().GetLvl();
            player.GetModPlayer<GGDPlayer>().lvl = player.GetModPlayer<GGDPlayer>().CanLvl();
            if (player.GetModPlayer<GGDPlayer>().exp > 2000000000)
            {
                player.GetModPlayer<GGDPlayer>().exp = 2000000000;
                Main.NewText("You have capped exp");
            }
            if(player.GetModPlayer<GGDPlayer>().lvl == 100 && !player.GetModPlayer<GGDPlayer>().capLvl)
            {
                player.GetModPlayer<GGDPlayer>().capLvl = true;
                Main.NewText("You have reached lvl 100!!", 75, 0, 130);
            }

            return true;
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);
        }
    }
}
