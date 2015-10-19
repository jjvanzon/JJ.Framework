using System;
using JJ.Framework.Presentation.VectorGraphics.EventArg;

namespace JJ.Framework.Presentation.VectorGraphics.Gestures
{
    /// <summary>
    /// Base class for gestures.
    /// Apart from what IGesture does, this base class adds
    /// the MouseCaptureRequired property returning false
    /// by default.
    /// </summary>
    public abstract class GestureBase : IGesture
    {
        /// <summary> Base member does nothing. </summary>
        protected virtual void HandleMouseDown(object sender, MouseEventArgs e)
        { }

        /// <summary> Base member does nothing. </summary>
        protected virtual void HandleMouseMove(object sender, MouseEventArgs e)
        { }

        /// <summary> Base member does nothing. </summary>
        protected virtual void HandleMouseUp(object sender, MouseEventArgs e)
        { }

        /// <summary> Base member does nothing. </summary>
        protected virtual void HandleKeyDown(object sender, KeyEventArgs e)
        { }

        /// <summary> Base member does nothing. </summary>
        protected virtual void HandleKeyUp(object sender, KeyEventArgs e)
        { }

        protected virtual bool MouseCaptureRequired
        {
            get { return false; }
        }

        void IGesture.HandleMouseDown(object sender, MouseEventArgs e) { HandleMouseDown(sender, e); }
        void IGesture.HandleMouseMove(object sender, MouseEventArgs e) { HandleMouseMove(sender, e); }
        void IGesture.HandleMouseUp(object sender, MouseEventArgs e) { HandleMouseUp(sender, e); }
        void IGesture.HandleKeyDown(object sender, KeyEventArgs e) { HandleKeyDown(sender, e); }
        void IGesture.HandleKeyUp(object sender, KeyEventArgs e) { HandleKeyUp(sender, e); }
        bool IGesture.MouseCaptureRequired { get { return MouseCaptureRequired; } }
    }
}
