using JJ.Framework.Presentation.Svg.EventArg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Gestures
{
    public interface IGesture
    {
        void MouseDown(object sender, MouseEventArgs e);
        void MouseMove(object sender, MouseEventArgs e);
        void MouseUp(object sender, MouseEventArgs e);

        /// <summary>
        /// Tells if mouse down makes the control receive all mouse events
        /// until mouse up. This prevents mouse events from
        /// reaching other elements, even when going outside the capturing element's rectangle.
        /// </summary>
        bool MouseCaptureRequired { get; }
    }
}
