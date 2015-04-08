using JJ.Framework.Presentation.Svg.EventArg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
