using System;
using JJ.Framework.Reflection.Exceptions;
using JJ.Framework.Mathematics;
using JJ.Framework.Presentation.VectorGraphics.EventArg;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;

namespace JJ.Framework.Presentation.VectorGraphics.Gestures
{
    public class ClickGesture : GestureBase
    {
        public event EventHandler<ElementEventArgs> Click;

        private Element _mouseDownElement;

        public override bool MouseCaptureRequired
        {
            get { return true; }
        }

        public override void HandleMouseDown(object sender, MouseEventArgs e)
        {
            if (Click == null) return;

            var element = sender as Element;
            if (element != null)
            {
                _mouseDownElement = element;
            }
        }

        public override void HandleMouseUp(object sender, MouseEventArgs e)
        {
            if (e == null) throw new NullException(() => e);

            if (Click == null) return;

            if (_mouseDownElement != null)
            {
                bool mouseDownElementIsHit = Geometry.IsInRectangle(
                    e.X, e.Y,
                    _mouseDownElement.CalculatedX,
                    _mouseDownElement.CalculatedY,
                    _mouseDownElement.CalculatedX + _mouseDownElement.Width,
                    _mouseDownElement.CalculatedY + _mouseDownElement.Height);

                if (mouseDownElementIsHit)
                {
                    Click(sender, new ElementEventArgs(e.Element));
                }
            }
        }
    }
}
