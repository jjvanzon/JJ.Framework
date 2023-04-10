using System;
using JJ.Framework.VectorGraphics.EventArg;

namespace JJ.Framework.VectorGraphics.Gestures
{
    /// <inheritdoc />
    public class KeyDownGesture : GestureBase
    {
        /// <summary> Would go off when a user might press a keyboard key down. </summary>
        public event EventHandler<KeyEventArgs> KeyDown;

        /// <summary> Would raise the KeyDown event. </summary>
        protected override void HandleKeyDown(object sender, KeyEventArgs e) => KeyDown?.Invoke(sender, e);
    }
}
