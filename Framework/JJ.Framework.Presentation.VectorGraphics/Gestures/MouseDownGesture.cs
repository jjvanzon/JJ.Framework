using JJ.Framework.Presentation.VectorGraphics.EventArg;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.Gestures
{
    public class MouseDownGesture : GestureBase
    {
        public event EventHandler<MouseEventArgs> MouseDown;

        protected override void HandleMouseDown(object sender, MouseEventArgs e)
        {
            if (MouseDown != null)
            {
                MouseDown(sender, e);
            }
        }
    }
}
