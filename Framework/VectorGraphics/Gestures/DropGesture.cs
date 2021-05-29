using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.VectorGraphics.EventArg;
// ReSharper disable InvertIf

namespace JJ.Framework.VectorGraphics.Gestures
{
    /// <inheritdoc />
    public class DropGesture : GestureBase
    {
        /// <summary> May go off when a user might drop one element onto another in a drag-drop action. </summary>
        public event EventHandler<DroppedEventArgs> Dropped;

        /// <summary>
        /// A drop gesture would be associated with specific drag gestures for them to work together.
        /// </summary>
        private readonly IList<DragGesture> _dragGestures;

        /// <inheritdoc cref="DropGesture" />
        /// <param name="dragGestures">
        /// A drop gesture could be associated with specific drag gestures for them to work together.
        /// </param>
        public DropGesture(params DragGesture[] dragGestures)
            : this((IList<DragGesture>)dragGestures)
        { }

        /// <inheritdoc cref="DropGesture(DragGesture[])" />
        [PublicAPI]
        public DropGesture(IList<DragGesture> dragGestures) => _dragGestures = dragGestures ?? throw new NullException(() => dragGestures);

        /// <summary>
        /// Would go by DragGestures that would currently have a DraggedElement.
        /// If the mouse up on the DropGesture also has an Element, this would become the DroppedOnElement.
        /// A DraggedElement and a DroppedOnElement might then be passed along to a Dropped event.
        /// Some of the DragGestures would then be finished.
        /// The DraggedElements of those DragGestures may be set to null then.
        /// </summary>
        protected override void HandleMouseUp(object sender, MouseEventArgs e)
        {
            foreach (DragGesture dragGesture in _dragGestures)
            {
                if (dragGesture.DraggedElement != null)
                {
                    if (e.Element != null)
                    {
                        Dropped?.Invoke(sender, new DroppedEventArgs(dragGesture.DraggedElement, e.Element));
                    }

                    dragGesture.DraggedElement = null;
                }
            }
        }
    }
}
