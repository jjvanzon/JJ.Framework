using System;
using JJ.Framework.VectorGraphics.EventArg;

namespace JJ.Framework.VectorGraphics.Gestures
{
    /// <inheritdoc />
    public class MouseDownGesture : GestureBase
    {
        /// <summary> Would go off when a user might press a mouse button down. </summary>
        public event EventHandler<MouseEventArgs> MouseDown;

        /// <summary> Would raise the MouseDown event. </summary>
        protected override void HandleMouseDown(object sender, MouseEventArgs e) => MouseDown?.Invoke(sender, e);
    }
}
