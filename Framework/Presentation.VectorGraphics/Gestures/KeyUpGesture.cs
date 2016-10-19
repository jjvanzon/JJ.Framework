using JJ.Framework.Presentation.VectorGraphics.EventArg;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.Gestures
{
    public class KeyUpGesture : GestureBase
    {
        public EventHandler<KeyEventArgs> KeyUp;

        protected override void HandleKeyUp(object sender, EventArg.KeyEventArgs e)
        {
            KeyUp?.Invoke(sender, e);
        }
    }
}
