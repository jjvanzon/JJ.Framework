using JJ.Framework.Business;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.SideEffects
{
    internal class SideEffect_VerifyDiagram_WhenSettingParentOrChild : ISideEffect
    {
        private Element _child;
        private Element _parent;

        /// <param name="child">nullable</param>
        /// <param name="parent">nullable</param>
        public SideEffect_VerifyDiagram_WhenSettingParentOrChild(Element child, Element parent)
        {
            _child = child;
            _parent = parent;
        }

        public void Execute()
        {
            if (_parent != null && _parent.Diagram == null)
            {
                throw new Exception("Elements must be part of a Diagram to manage Parent-Child relationships.");
            }

            if (_child != null && _child.Diagram == null)
            {
                throw new Exception("Elements must be part of a Diagram to manage Parent-Child relationships.");
            }

            if (_parent != null && _child != null && _parent.Diagram != _child.Diagram)
            {
                throw new Exception("Elements must be part of the same Diagram to create a Parent-Child relationships.");
            }
        }
    }
}