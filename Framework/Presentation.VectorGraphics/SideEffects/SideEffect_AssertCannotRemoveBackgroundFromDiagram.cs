using System;
using System.Collections.Generic;
using System.Linq;
using JJ.Framework.Business;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Reflection.Exceptions;

namespace JJ.Framework.Presentation.VectorGraphics.SideEffects
{
    internal class SideEffect_AssertCannotRemoveBackgroundFromDiagram : ISideEffect
    {
        private readonly Element _element;

        public SideEffect_AssertCannotRemoveBackgroundFromDiagram(Element element)
        {
            if (element == null) throw new NullException(() => element);

            _element = element;
        }

        public void Execute()
        {
            if (_element == _element.Diagram.Background)
            {
                throw new Exception("Cannot remove Background Element from Diagram.");
            }
        }
    }
}
