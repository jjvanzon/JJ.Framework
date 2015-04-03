using JJ.Framework.Presentation.Svg.Gestures;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.EventArg
{
    public class GestureEventArgs : EventArgs
    {
        public GestureEventArgs(IGesture gesture, Element element)
        {
            // TODO: Enable null check again.
            //if (gesture == null) throw new NullException(() => gesture);
            if (element == null) throw new NullException(() => element);

            Gesture = gesture;
            Element = element;
        }

        public IGesture Gesture { get; private set; }
        public Element Element { get; private set; }
    }
}
