using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace GGD.Items.LvlS
{
    public class BiggerExp : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Denser Exp Orb");
            Tooltip.SetDefault("Denser and better!");
            // ticksperframe, frameCount
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 3));
            ItemID.Sets.AnimatesAsSoul[item.type] = false;
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = false;
        }

        // TODO -- Velocity Y smaller, post NewItem?
        public override void SetDefaults()
        {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.SoulofSight);
            item.width = 16;
            item.height = 16;
            item.maxStack = 999999;
            item.value = 0;
            item.rare = 9;
            item.consumable = true;
            item.useAnimation = 2;
            item.useTime = 2;
            item.useStyle = 4;
            item.autoReuse = true;
            item.noUseGraphic = true;
        }

        // The following 2 methods are purely to show off these 2 hooks. Don't use them in your own code.
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
            player.GetModPlayer<GGDPlayer>().exp += 1000;
            player.GetModPlayer<GGDPlayer>().lvl = player.GetModPlayer<GGDPlayer>().GetLvl();
            player.GetModPlayer<GGDPlayer>().lvl = player.GetModPlayer<GGDPlayer>().CanLvl();
            if (player.GetModPlayer<GGDPlayer>().exp > 2000000000)
            {
                player.GetModPlayer<GGDPlayer>().exp = 2000000000;
            }
            return true;
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);
        }
    }

    /*public class SoulGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ExamplePlayer>().ZoneExample)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("ExampleSoul"), 1);
            }
        }
    }*/


}
