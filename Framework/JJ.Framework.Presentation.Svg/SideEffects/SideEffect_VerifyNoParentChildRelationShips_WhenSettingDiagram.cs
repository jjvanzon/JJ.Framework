using JJ.Framework.Business;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection.Exceptions;
using System;

namespace JJ.Framework.Presentation.Svg.SideEffects
{
    internal class SideEffect_VerifyNoParentChildRelationShips_WhenSettingDiagram : ISideEffect
    {
        private Element _element;

        public SideEffect_VerifyNoParentChildRelationShips_WhenSettingDiagram(Element element)
        {
            if (element == null) throw new NullException(() => element);

            _element = element;
        }

        public void Execute()
        {
            if (_element.Parent != null)
            {
                throw new Exception("An Element must have no parent-child relationships when you add or remove it from a Diagram.");
            }

            if (_element.Children.Count != 0)
            {
                throw new Exception("An Element must have no parent-child relationships when you add or remove it from a Diagram.");
            }
        }
    }
}
