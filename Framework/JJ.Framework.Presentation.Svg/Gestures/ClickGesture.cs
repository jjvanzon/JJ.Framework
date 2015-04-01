using JJ.Framework.Presentation.Svg.EventArg;
using JJ.Framework.Presentation.Svg.Models.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Mathematics;

namespace JJ.Framework.Presentation.Svg.Gestures
{
    public class ClickGesture : IGesture
    {
        public event EventHandler Click;

        private Element _mouseDownElement;

        bool IGesture.MouseCaptureRequired
        {
            get { return true; }
        }

        void IGesture.MouseDown(object sender, MouseEventArgs e)
        {
            if (Click == null) return;

            var element = sender as Element;
            if (element != null)
            {
                _mouseDownElement = element;
            }
        }

        void IGesture.MouseMove(object sender, MouseEventArgs e)
        { }

        void IGesture.MouseUp(object sender, MouseEventArgs e)
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

                Click(_mouseDownElement, EventArgs.Empty);
            }
        }
    }
}
