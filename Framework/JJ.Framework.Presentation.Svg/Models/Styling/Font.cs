﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Models.Styling
{
    public class Font
    {
        public Font()
        {
            Name = "Arial";
            Size = 12;
        }

        public string Name { get; set; }
        public float Size { get; set; }
        public bool Bold { get; set; }
        public bool Italic { get; set; }
    }
}