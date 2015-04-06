using JJ.Framework.Presentation.Svg.Gestures;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Models.Elements
{
    public class ElementGestures : IEnumerable<ElementGesture>
    {
        private Element _element;
        private IList<ElementGesture> _list;

        internal ElementGestures(Element element)
        {
            _element = element;
            _list = new List<ElementGesture>();
        }

        public void Add(IGesture gesture, bool mustBubble = true)
        {
            ElementGesture elementGesture = new ElementGesture(_element, gesture, mustBubble);
            _list.Add(elementGesture);
        }

        public void Remove(IGesture gesture)
        {
            // TODO: This could be made faster with a for loop and a RemoveAt.
            IList<ElementGesture> elementGestures = _list.Where(x => x.Gesture == gesture).ToArray();
            foreach (ElementGesture elementGesture in elementGestures)
            {
                _list.Remove(elementGesture);
            }
        }

        // IEnumerable

        public IEnumerator<ElementGesture> GetEnumerator()
        {
            foreach (ElementGesture item in _list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (ElementGesture item in _list)
            {
                yield return item;
            }
        }
    }
}
