using JJ.Framework.Presentation.Svg.Enums;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.EventArg
{
    public class MouseEventArgs : EventArgs
    {
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
