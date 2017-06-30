using JJ.Framework.Presentation.VectorGraphics.Enums;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.EventArg
{
    public class MouseEventArgs : EventArgs
    {
        /// <summary> Null if e.g. passed from client technology without having a hit element yet. </summary>
        public Element Element { get; private set; }
        public float X { get; private set; }
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
