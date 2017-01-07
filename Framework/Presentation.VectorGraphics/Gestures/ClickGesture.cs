using System;
using JJ.Framework.Mathematics;
using JJ.Framework.Presentation.VectorGraphics.EventArg;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;

namespace JJ.Framework.Presentation.VectorGraphics.Gestures
{
    public class ClickGesture : GestureBase
    {
        public event EventHandler<ElementEventArgs> Click;

        private Element _mouseDownElement;

        protected override bool MouseCaptureRequired => true;

        protected override void HandleMouseDown(object sender, MouseEventArgs e)
        {
            if (Click == null) return;

            var element = sender as Element;
            if (element != null)
            {
                _mouseDownElement = element;
            }
        }

        protected override void HandleMouseUp(object sender, MouseEventArgs e)
        {
            if (Click == null) return;

            if (_mouseDownElement != null)
            {
                bool mouseDownElementIsHit = Geometry.IsInRectangle(
                    e.XInPixels, 
                    e.YInPixels,
                    _mouseDownElement.CalculatedValues.XInPixels,
                    _mouseDownElement.CalculatedValues.YInPixels,
                    _mouseDownElement.CalculatedValues.XInPixels + _mouseDownElement.CalculatedValues.WidthInPixels,
                    _mouseDownElement.CalculatedValues.YInPixels + _mouseDownElement.CalculatedValues.HeightInPixels);

                if (mouseDownElementIsHit)
                {
                    Click(sender, new ElementEventArgs(e.Element));
                }
            }
        }
    }
}
