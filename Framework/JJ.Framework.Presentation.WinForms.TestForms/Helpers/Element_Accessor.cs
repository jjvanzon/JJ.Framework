using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Reflection;

namespace JJ.Framework.Presentation.WinForms.TestForms.Helpers
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
