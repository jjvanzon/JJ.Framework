using JJ.Framework.Presentation.Svg.EventArg;
using JJ.Framework.Presentation.Svg.Models.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Mathematics;

namespace JJ.Framework.Presentation.Svg.Gestures
{
    public class ClickGesture : GestureBase
    {
        public event EventHandler<ClickEventArgs> Click;

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
            if (Click == null) return;

            if (_mouseDownElement != null)
            {
                bool mouseDownElementIsHit = GeometryCalculations.IsInRectangle(
                    e.X, e.Y,
                    _mouseDownElement.CalculatedX,
                    _mouseDownElement.CalculatedY,
                    _mouseDownElement.CalculatedX + _mouseDownElement.Width,
                    _mouseDownElement.CalculatedY + _mouseDownElement.Height);

                Click(sender, new ClickEventArgs(e.Element));
            }
        }
    }
}
