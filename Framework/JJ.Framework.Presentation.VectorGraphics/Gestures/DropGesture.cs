using JJ.Framework.Presentation.VectorGraphics.EventArg;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;

namespace JJ.Framework.Presentation.VectorGraphics.Gestures
{
    public class DropGesture : GestureBase
    {
        public event EventHandler<DroppedEventArgs> Dropped;

        private IList<DragGesture> _dragGestures;

        public DropGesture(params DragGesture[] dragGestures)
            : this((IList<DragGesture>)dragGestures)
        { }

        public DropGesture(IList<DragGesture> dragGestures)
        {
            if (dragGestures == null) throw new NullException(() => dragGestures);

            _dragGestures = dragGestures;
        }

        protected override void HandleMouseUp(object sender, MouseEventArgs e)
        {
            foreach (DragGesture dragGesture in _dragGestures)
            {
                if (dragGesture.DraggedElement != null)
                {
                    if (e.Element != null)
                    {
                        if (Dropped != null)
                        {
                            Dropped(sender, new DroppedEventArgs(dragGesture.DraggedElement, e.Element));
                        }
                    }

                    dragGesture.DraggedElement = null;
                }
            }
        }
    }
}
