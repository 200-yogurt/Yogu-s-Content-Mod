using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace YoguContentMod
{
    public class CommonSounds
    {
        private static LegacySoundStyle _itemSwing, _bowShot;
        public static LegacySoundStyle ItemSwing => _itemSwing ?? (_itemSwing = new LegacySoundStyle(2, 1));
        public static LegacySoundStyle BowShot => _bowShot ?? (_bowShot =  new LegacySoundStyle(2, 5));
    }
}
