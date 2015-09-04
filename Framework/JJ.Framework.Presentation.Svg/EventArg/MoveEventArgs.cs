using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection.Exceptions;
using System;

namespace JJ.Framework.Presentation.Svg.EventArg
{
    public class MoveEventArgs : EventArgs
    {
        public Element Element { get; private set; }

        public MoveEventArgs(Element element)
        {
            if (element == null) throw new NullException(() => element);

            Element = element;
        }
    }
}
