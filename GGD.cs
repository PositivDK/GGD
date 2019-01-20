using Terraria.ModLoader;
using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;
using GGD.Items;

namespace GGD
{
	public class GGD : Mod
	{
        public static int CustomCurrencyID;
		public GGD()
		{
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadBackgrounds = true,
                AutoloadGores = true,
                AutoloadSounds = true

            };
		}

        public override void Load()
        {
            CustomCurrencyID = CustomCurrencyManager.RegisterCurrency(new ExpData(ItemType("Exp"), 999999L));
        }


    }
}
