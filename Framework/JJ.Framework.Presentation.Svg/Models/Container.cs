using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.Svg.Models
{
    public class Container : ElementBase
    {
        // TODO: Return something other than 0 for the Center coordinates?

        public override float X
        {
            get { return 0; }
            set { throw new NotSupportedException(); }
        }

        public override float Y
        {
            get { return 0; }
            set { throw new NotSupportedException(); }
        }
    }
}
