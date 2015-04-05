using JJ.Framework.Presentation.Svg.EventArg;
using JJ.Framework.Presentation.Svg.Models.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Gestures
{
    public class DragGesture : IGesture
    {
        public event EventHandler<DraggingEventArgs> OnDragging;

        public Element DraggedElement { get; private set; }

        bool IGesture.MouseCaptureRequired
        {
            get { return false; }
        }

        void IGesture.MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Element != null)
            {
                DraggedElement = e.Element;

                if (OnDragging != null)
                {
                    OnDragging(sender, new DraggingEventArgs(DraggedElement, e.X, e.Y));
                }
            }
        }

        void IGesture.MouseMove(object sender, MouseEventArgs e)
        {
            if (DraggedElement != null)
            {
                if (OnDragging != null)
                {
                    OnDragging(sender, new DraggingEventArgs(DraggedElement, e.X, e.Y));
                }
            }
        }

        void IGesture.MouseUp(object sender, MouseEventArgs e)
        {
            DraggedElement = null;
        }
    }
}
