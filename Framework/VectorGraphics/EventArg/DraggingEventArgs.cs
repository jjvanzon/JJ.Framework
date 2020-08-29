using System;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.VectorGraphics.Models.Elements;

// ReSharper disable InconsistentNaming
// ReSharper disable once MemberCanBeInternal

namespace JJ.Framework.VectorGraphics.EventArg
{
    /// <summary>
    /// Contains the properties passed along with DragGesture's Dragging event.
    /// </summary>
    public class DraggingEventArgs : EventArgs
    {
        /// <summary>
        /// An element might be picked up by a drag-drop action.
        /// This would be the element that was picked up.
        /// </summary>
        public Element ElementBeingDragged { get; }

        /// <summary>
        /// Indicates the current position of the (mouse) cursor in pixels.
        /// When you might need scaled coordinates for instance,
        /// you might use Diagram.Position members which may allow you to
        /// convert between coordinate systems.
        /// </summary>
        public float XInPixels { get; }

        /// <inheritdoc cref="XInPixels" />
        public float YInPixels { get; }

        /// <inheritdoc cref="DraggingEventArgs"/>
        public DraggingEventArgs(Element elementBeingDragged, float xInPixels, float yInPixels)
        {
            ElementBeingDragged = elementBeingDragged ?? throw new NullException(() => elementBeingDragged);
            XInPixels = xInPixels;
            YInPixels = yInPixels;
        }
    }
}