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

        public float AbsoluteX
        {
            get { return _accessor.GetPropertyValue(() => AbsoluteX); }
            set { _accessor.SetPropertyValue(() => AbsoluteX, value); }
        }

        public float AbsoluteY
        {
            get { return _accessor.GetPropertyValue(() => AbsoluteY); }
            set { _accessor.SetPropertyValue(() => AbsoluteY, value); }
        }
    }
}
