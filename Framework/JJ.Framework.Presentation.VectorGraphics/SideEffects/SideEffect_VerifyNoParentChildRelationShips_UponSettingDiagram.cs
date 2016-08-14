using JJ.Framework.Business;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Reflection.Exceptions;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.SideEffects
{
    internal class SideEffect_VerifyNoParentChildRelationShips_UponSettingDiagram : ISideEffect
    {
        private Element _element;

        public SideEffect_VerifyNoParentChildRelationShips_UponSettingDiagram(Element element)
        {
            if (element == null) throw new NullException(() => element);

            _element = element;
        }

        public void Execute()
        {
            if (_element.Parent != null)
            {
                throw new Exception("An Element must have no parent-child relationships when you add or remove it from a Diagram. The element still has a parent.");
            }

            if (_element.Children.Count != 0)
            {
                throw new Exception("An Element must have no parent-child relationships when you add or remove it from a Diagram. the element still has children.");
            }
        }
    }
}
