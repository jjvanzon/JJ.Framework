using JJ.Framework.Presentation.VectorGraphics.Enums;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.EventArg
{
    public class MouseEventArgs : EventArgs
    {
        public Element Element { get; }
        public float XInPixels { get; }
        public float YInPixels { get; }
        public MouseButtonEnum MouseButtonEnum { get; }

        /// <param name="element">nullable</param>
        public MouseEventArgs(Element element, float xInPixels, float yInPixels, MouseButtonEnum mouseButtonEnum)
        {
            Element = element;
            XInPixels = xInPixels;
            YInPixels = yInPixels;
            MouseButtonEnum = mouseButtonEnum;
        }
    }
}
