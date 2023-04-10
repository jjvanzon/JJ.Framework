using System;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.VectorGraphics.Models.Elements;
// ReSharper disable MemberCanBeInternal

namespace JJ.Framework.VectorGraphics.EventArg
{
    /// <summary>
    /// Contains the properties passed along with the DropGesture's Dropped event.
    /// </summary>
    public class DroppedEventArgs : EventArgs
    {
        /// <summary>
        /// An element might be picked up by a drag-drop action.
        /// This would be the element that was picked up.
        /// </summary>
        public Element DraggedElement { get; }
        /// <summary>
        /// Indicates the element over which the (mouse) cursor was positioned
        /// at the end of a drag-drop action.
        /// </summary>
        public Element DroppedOnElement { get; }

        /// <inheritdoc cref="DroppedEventArgs"/>
        /// <param name="draggedElement"> See DraggedElement property.</param>
        /// <param name="droppedOnElement"> See DroppedOnElement property.</param>
        public DroppedEventArgs(Element draggedElement, Element droppedOnElement)
        {
            DraggedElement = draggedElement ?? throw new NullException(() => draggedElement);
            DroppedOnElement = droppedOnElement ?? throw new NullException(() => droppedOnElement);
        }
    }
}
