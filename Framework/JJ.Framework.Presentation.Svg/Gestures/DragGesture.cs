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
        public event EventHandler<DraggingEventArgs> Dragging;

        public Element DraggedElement { get; private set; }

        private Diagram _diagram;

        public override void FireMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Element != null)
            {
                DraggedElement = e.Element;

                _diagram = DraggedElement.Diagram;
                if (_diagram != null)
                {

                }
            }
        }

        public override void FireMouseMove(object sender, MouseEventArgs e)
        {
            if (DraggedElement != null)
            {
                if (Dragging != null)
                {
                    Dragging(sender, new DraggingEventArgs(DraggedElement, e.X, e.Y));
                }
            }
        }

        public override void FireMouseUp(object sender, MouseEventArgs e)
        {
            DraggedElement = null;
        }
    }
}
