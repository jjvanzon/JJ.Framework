using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    public class PointPosition : ElementPosition
    {
        internal PointPosition(Point point)
            : base(point)
        { }

        public override float X { get; set; }
        public override float Y { get; set; }

        public override float Width
        {
            get { return 0; }
            set { throw new NotSupportedException(); }
        }

        public override float Height
        {
            get { return 0; }
            set { throw new NotSupportedException(); }
        }
    }
}
