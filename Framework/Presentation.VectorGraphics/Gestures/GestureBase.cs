using System.Runtime.CompilerServices;
using JJ.Framework.Presentation.VectorGraphics.EventArg;

namespace JJ.Framework.Presentation.VectorGraphics.Gestures
{
    /// <summary> Base class for gestures. </summary>
    public abstract class GestureBase
    {
        public GestureBase()
        {
            Internals = new GestureInternals(this);
        }

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

        protected virtual bool MouseCaptureRequired => false;

        public GestureInternals Internals { get; }

        // These are here for GestureInternals to delegate to, all to make the interface look clean.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void InternalHandleMouseDown(object sender, MouseEventArgs e) => HandleMouseDown(sender, e);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void InternalHandleMouseMove(object sender, MouseEventArgs e) => HandleMouseMove(sender, e);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void InternalHandleMouseUp(object sender, MouseEventArgs e) => HandleMouseUp(sender, e);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void InternalHandleKeyDown(object sender, KeyEventArgs e) => HandleKeyDown(sender, e);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void InternalHandleKeyUp(object sender, KeyEventArgs e) => HandleKeyUp(sender, e);

        internal bool InternalMouseCaptureRequired
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return MouseCaptureRequired; }
        }
    }
}