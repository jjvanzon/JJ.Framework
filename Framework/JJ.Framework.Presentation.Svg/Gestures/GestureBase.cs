using JJ.Framework.Presentation.Svg.EventArg;

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
        /// <summary>
        /// Does nothing.
        /// </summary>
        public virtual void HandleMouseDown(object sender, MouseEventArgs e)
        { }

        /// <summary>
        /// Base member does nothing.
        /// </summary>
        public virtual void HandleMouseMove(object sender, MouseEventArgs e)
        { }

        /// <summary>
        /// Base member does nothing.
        /// </summary>
        public virtual void HandleMouseUp(object sender, MouseEventArgs e)
        { }

        /// <summary>
        /// Base member does nothing.
        /// </summary>
        public virtual void HandleKeyDown(object sender, KeyEventArgs e)
        { }

        /// <summary>
        /// Base member does nothing.
        /// </summary>
        public virtual void HandleKeyUp(object sender, KeyEventArgs e)
        { }

        public virtual bool MouseCaptureRequired
        {
            get { return false; }
        }
    }
}
