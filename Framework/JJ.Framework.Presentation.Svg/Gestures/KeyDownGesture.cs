using JJ.Framework.Presentation.Svg.EventArg;
using System;

namespace JJ.Framework.Presentation.Svg.Gestures
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
