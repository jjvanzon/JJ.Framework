using System;
using JJ.Framework.Presentation.VectorGraphics.EventArg;

namespace JJ.Framework.Presentation.VectorGraphics.Gestures
{
    /// <summary>
    /// WinForms sends a mouse move event,
    /// even when I did not move the mouse,
    /// in case of a move up.
    /// This gesture will block that and only send
    /// a mouse move event when you actually moved the mouse.
    /// </summary>
    public class MouseMoveGesture : GestureBase
    {
        public event EventHandler<MouseEventArgs> MouseMove;

        private float _previousPointerX;
        private float _previousPointerY;

        protected override void HandleMouseDown(object sender, MouseEventArgs e)
        {
            _previousPointerX = e.X;
            _previousPointerY = e.Y;
        }

        protected override void HandleMouseMove(object sender, MouseEventArgs e)
        {
            if (MouseMove == null)
            {
                return;
            }

            if (_previousPointerX != e.X ||
                _previousPointerY != e.Y)
            {
                MouseMove(sender, e);
            }

            _previousPointerX = e.X;
            _previousPointerY = e.Y;
        }
    }
}
