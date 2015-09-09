using JJ.Framework.Presentation.VectorGraphics.Enums;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.EventArg
{
    public class MouseEventArgs : EventArgs
    {
        public Element Element { get; private set; }

        /// <summary>
        /// The X-coordinate of the mouse pointer.
        /// It is the absolute position within a diagram.
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// The Y-coordinate of the mouse pointer.
        /// It is the absolute position within a diagram.
        /// </summary>
        public float Y { get; private set; }

        public MouseButtonEnum MouseButtonEnum { get; private set; }

        /// <param name="element">nullable</param>
        public MouseEventArgs(Element element, float x, float y, MouseButtonEnum mouseButtonEnum)
        {
            Element = element;
            X = x;
            Y = y;
            MouseButtonEnum = mouseButtonEnum;
        }
    }
}
