﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace YoguContentMod.Items.Tools
{
    public class OozeAxe : YItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.width = 38;
            item.height = 30;
        }
    }
}