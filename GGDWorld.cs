using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace GGD
{
    public class GGDWorld : ModWorld
    {
        public static bool downedMothronQueen;

        public override void Initialize()
        {
            downedMothronQueen = false;
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"downedMothronQueen", downedMothronQueen }
            };
        }

        public override void Load(TagCompound tag)
        {
            downedMothronQueen = tag.GetBool("downedMothronQueen");
        }
    }
}
