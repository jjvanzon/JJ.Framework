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

        /// <inheritdoc cref="MouseEventArgs.XInPixels" />
        public float XInPixels { get; }

        /// <inheritdoc cref="MouseEventArgs.YInPixels" />
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