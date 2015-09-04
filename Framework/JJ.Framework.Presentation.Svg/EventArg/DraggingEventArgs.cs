using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection.Exceptions;
using System;

namespace JJ.Framework.Presentation.Svg.EventArg
{
    public class DraggingEventArgs : EventArgs
    {
        public Element ElementBeingDragged { get; private set; }
        public float X { get; set; }
        public float Y { get; set; }

        public DraggingEventArgs(Element elementBeingDragged, float x, float y)
        {
            if (elementBeingDragged == null) throw new NullException(() => elementBeingDragged);

            ElementBeingDragged = elementBeingDragged;
            X = x;
            Y = y;
        }
    }
}
