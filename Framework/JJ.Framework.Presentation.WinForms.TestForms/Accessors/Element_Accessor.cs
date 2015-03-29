using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.WinForms.TestForms.Accessors
{
    internal class Element_Accessor
    {
        private Accessor _accessor;

        public Element_Accessor(Element element)
        {
            _accessor = new Accessor(element, typeof(Element));
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
