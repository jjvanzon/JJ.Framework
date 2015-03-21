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
        public override float X { get; set; }
        public override float Y { get; set; }

        private string DebuggerDisplay
        {
            get
            {
                return String.Format("({0}, {1}) {{{2}}}", X, Y, GetType().Name);
            }
        }
    }
}
