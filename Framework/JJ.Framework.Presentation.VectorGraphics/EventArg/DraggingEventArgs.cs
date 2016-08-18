using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Reflection.Exceptions;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.EventArg
{
    public class DraggingEventArgs : EventArgs
    {
        public Element ElementBeingDragged { get; }
        public float X { get; }
        public float Y { get; }

        public DraggingEventArgs(Element elementBeingDragged, float x, float y)
        {
            if (elementBeingDragged == null) throw new NullException(() => elementBeingDragged);

            ElementBeingDragged = elementBeingDragged;
            X = x;
            Y = y;
        }
    }
}
