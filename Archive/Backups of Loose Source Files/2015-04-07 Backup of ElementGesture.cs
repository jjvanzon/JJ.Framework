using JJ.Framework.Presentation.Svg.Gestures;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Models.Elements
{
    public class ElementGesture
    {
        public ElementGesture(Element element, IGesture gesture, bool mustBubble = true)
        {
            if (element == null) throw new NullException(() => element);
            if (gesture == null) throw new NullException(() => gesture);

            Element = element;
            Gesture = gesture;
            MustBubble = mustBubble;
        }

        public Element Element { get; private set; }
        public IGesture Gesture { get; private set; }
        public bool MustBubble { get; set; }
    }
}
