using JJ.Framework.Presentation.Svg.EventArg;
using JJ.Framework.Presentation.Svg.Models.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Gestures
{
    public class DragGesture : GestureBase
    {
        public DragGesture()
        {
            //MustBubble = false;
        }

        public event EventHandler<DraggingEventArgs> OnDragging;

        public Element DraggedElement { get; private set; }

        public override void FireMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Element != null)
            {
                DraggedElement = e.Element;

                // TODO: Remove outcommented code if it proves they are not necessary.
                //if (OnDragging != null)
                //{
                //    OnDragging(sender, new DraggingEventArgs(DraggedElement, e.X, e.Y));
                //}
            }
        }

        public override void FireMouseMove(object sender, MouseEventArgs e)
        {
            if (DraggedElement != null)
            {
                if (OnDragging != null)
                {
                    OnDragging(sender, new DraggingEventArgs(DraggedElement, e.X, e.Y));
                }
            }
        }

        public override void FireMouseUp(object sender, MouseEventArgs e)
        {
            DraggedElement = null;
        }
    }
}
