using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Exceptions;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.EventArg
{
    public class DroppedEventArgs : EventArgs
    {
        public Element DraggedElement { get; }
        public Element DroppedOnElement { get; }

        public DroppedEventArgs(Element draggedElement, Element droppedOnElement)
        {
            if (draggedElement == null) throw new NullException(() => draggedElement);
            if (droppedOnElement == null) throw new NullException(() => droppedOnElement);

            DraggedElement = draggedElement;
            DroppedOnElement = droppedOnElement;
        }
    }
}
