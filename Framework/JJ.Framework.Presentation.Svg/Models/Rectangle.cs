using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.Svg.Models
{
    public class Rectangle : ElementBase
    {
        public override float X { get; set; }
        public override float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
    }
}
