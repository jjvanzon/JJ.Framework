using JJ.Framework.Presentation.Svg.EventArg;
using System;

namespace JJ.Framework.Presentation.Svg.Gestures
{
    public class MouseDownGesture : GestureBase
    {
        public event EventHandler<MouseEventArgs> MouseDown;

        public override void HandleMouseDown(object sender, MouseEventArgs e)
        {
            if (MouseDown != null)
            {
                MouseDown(sender, e);
            }
        }
    }
}
