using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.EventArg
{
    public class DragDropEventArgs : EventArgs
    {
        public Element DraggedElement { get; private set; }
        public Element DroppedOnElement { get; private set; }

        public DragDropEventArgs(Element draggedElement, Element droppedOnElement)
        {
            if (draggedElement == null) throw new NullException(() => draggedElement);
            if (droppedOnElement == null) throw new NullException(() => droppedOnElement);

            DraggedElement = draggedElement;
            DroppedOnElement = droppedOnElement;
        }
    }
}
