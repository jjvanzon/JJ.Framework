using JJ.Framework.Presentation.Svg.EventArg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Gestures
{
    public interface IGesture
    {
        void FireMouseDown(object sender, MouseEventArgs e);
        void FireMouseMove(object sender, MouseEventArgs e);
        void FireMouseUp(object sender, MouseEventArgs e);

        /// <summary>
        /// Tells if mouse down makes the control receive all mouse events
        /// until mouse up. This prevents mouse events from
        /// reaching other elements, even when going outside the capturing element's rectangle.
        /// </summary>
        bool MouseCaptureRequired { get; }

        /// <summary>
        /// When true, events that go off on a child element
        /// also go off on a parent element.
        /// </summary>
        //bool MustBubble { get; set; }
    }
}
