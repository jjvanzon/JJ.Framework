using JJ.Framework.Presentation.Svg.EventArg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Gestures
{
    public class MouseUpGesture : IGesture
    {
        public event EventHandler<MouseEventArgs> OnMouseUp;

        bool IGesture.MouseCaptureRequired
        {
            get { return false; }
        }

        void IGesture.MouseDown(object sender, MouseEventArgs e)
        { }

        void IGesture.MouseMove(object sender, MouseEventArgs e)
        {}

        void IGesture.MouseUp(object sender, MouseEventArgs e)
        {
            if (OnMouseUp != null)
            {
                OnMouseUp(sender, e);
            }
        }
    }
}
