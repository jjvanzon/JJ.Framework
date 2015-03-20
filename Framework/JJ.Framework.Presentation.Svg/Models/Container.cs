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

        public override float CenterX
        {
            get { return 0; }
        }

        public override float CenterY
        {
            get { return 0; }
        }
    }
}
