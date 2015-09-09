using JJ.Framework.Presentation.VectorGraphics.EventArg;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.Gestures
{
    public class KeyDownGesture : GestureBase
    {
        public EventHandler<KeyEventArgs> KeyDown;

        public override void HandleKeyDown(object sender, EventArg.KeyEventArgs e)
        {
            if (KeyDown != null)
            {
                KeyDown(sender, e);
            }
        }
    }
}
