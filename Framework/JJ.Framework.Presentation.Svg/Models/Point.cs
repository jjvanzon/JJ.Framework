using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.Svg.Models
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class Point : ElementBase
    {
        public float X { get; set; }
        public float Y { get; set; }

        public override float CenterX
        {
            get { return X; }
        }

        public override float CenterY
        {
            get { return Y; }
        }

        private string DebuggerDisplay
        {
            get
            {
                return String.Format("({0}, {1}) {{{2}}}", X, Y, GetType().Name);
            }
        }
    }
}
