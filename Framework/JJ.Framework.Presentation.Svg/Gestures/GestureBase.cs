using JJ.Framework.Presentation.Svg.EventArg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Gestures
{
    /// <summary>
    /// Base class for gestures.
    /// Apart from what IGesture does, this base class adds
    /// the MouseCaptureRequired property returning false
    /// by default.
    /// </summary>
    public abstract class GestureBase : IGesture
    {
        public abstract void FireMouseDown(object sender, MouseEventArgs e);
        public abstract void FireMouseMove(object sender, MouseEventArgs e);
        public abstract void FireMouseUp(object sender, MouseEventArgs e);

        public virtual bool MouseCaptureRequired
        {
            get { return false; }
        }
    }
}
