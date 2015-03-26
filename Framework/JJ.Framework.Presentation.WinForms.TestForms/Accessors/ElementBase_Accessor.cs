using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.WinForms.TestForms.Accessors
{
    internal class ElementBase_Accessor
    {
        private Accessor _accessor;

        public ElementBase_Accessor(ElementBase elementBase)
        {
            _accessor = new Accessor(elementBase, typeof(ElementBase));
        }

        public float CalculatedX
        {
            get { return _accessor.GetPropertyValue(() => CalculatedX); }
            set { _accessor.SetPropertyValue(() => CalculatedX, value); }
        }

        public float CalculatedY
        {
            get { return _accessor.GetPropertyValue(() => CalculatedY); }
            set { _accessor.SetPropertyValue(() => CalculatedY, value); }
        }
    }
}
