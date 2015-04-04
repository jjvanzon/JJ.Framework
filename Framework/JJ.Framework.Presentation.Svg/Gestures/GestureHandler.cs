using JJ.Framework.Presentation.Svg.EventArg;
using JJ.Framework.Presentation.Svg.Gestures;
using JJ.Framework.Presentation.Svg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection.Exceptions;
using JJ.Framework.Common;
using JJ.Framework.Mathematics;

namespace JJ.Framework.Presentation.Svg.Gestures
{
    internal class GestureHandler
    {
        private Element _pointerCapturingElement;

        private Diagram _diagram;

        public GestureHandler(Diagram diagram)
        {
            if (diagram == null) throw new NullException(() => diagram);

            _diagram = diagram;
        }

        public void MouseDown(MouseEventArgs e)
        {
            IEnumerable<Element> zOrdereredElements = _diagram.EnumerateElementsByZIndex();

            Element hitElement = TryGetHitElement(zOrdereredElements, e.X, e.Y);

            if (hitElement != null)
            {
                hitElement.MouseDown(hitElement, e);

                foreach (IGesture gesture in hitElement.Gestures)
                {
                    gesture.MouseDown(hitElement, e);
                }

                TryBubbleMouseDown(hitElement, hitElement, e);

                if (hitElement.Gestures.Any(x => x.MouseCaptureRequired))
                {
                    _pointerCapturingElement = hitElement;
                }
            }
        }

        private void TryBubbleMouseDown(Element sender, Element child, MouseEventArgs e)
        {
            if (!child.Bubble)
            {
                return;
            }

            if (child.Parent == null)
            {
                return;
            }

            Element parent = child.Parent;

            parent.MouseDown(sender, e);

            foreach (IGesture gesture in parent.Gestures)
            {
                gesture.MouseDown(parent, e);
            }

            TryBubbleMouseDown(sender, parent, e);

            if (parent.Gestures.Any(x => x.MouseCaptureRequired))
            {
                _pointerCapturingElement = child;
            }
        }

        public void MouseMove(MouseEventArgs e)
        {
            IEnumerable<Element> zOrdereredElements = _diagram.EnumerateElementsByZIndex();

            Element hitElement = _pointerCapturingElement;
            if (hitElement == null)
            {
                hitElement = TryGetHitElement(zOrdereredElements, e.X, e.Y);
            }

            if (hitElement != null)
            {
                foreach (IGesture gesture in hitElement.Gestures)
                {
                    gesture.MouseMove(hitElement, e);
                }

                TryBubbleMouseMove(hitElement, e);
            }
        }

        private void TryBubbleMouseMove(Element child, MouseEventArgs e)
        {
            if (!child.Bubble)
            {
                return;
            }

            if (child.Parent == null)
            {
                return;
            }

            Element parent = child.Parent;

            foreach (IGesture gesture in parent.Gestures)
            {
                gesture.MouseMove(parent, e);
            }

            TryBubbleMouseMove(parent, e);
        }

        public void MouseUp(MouseEventArgs e)
        {
            IEnumerable<Element> zOrdereredElements = _diagram.EnumerateElementsByZIndex();

            Element hitElement = _pointerCapturingElement;
            if (hitElement == null)
            {
                hitElement = TryGetHitElement(zOrdereredElements, e.X, e.Y);
            }

            if (hitElement != null)
            {
                hitElement.MouseUp(hitElement, e);

                foreach (IGesture gesture in hitElement.Gestures)
                {
                    gesture.MouseUp(hitElement, e);
                }

                TryBubbleMouseUp(hitElement, hitElement, e);
            }

            _pointerCapturingElement = null;
        }

        private void TryBubbleMouseUp(Element sender, Element child, MouseEventArgs e)
        {
            if (!child.Bubble)
            {
                return;
            }

            if (child.Parent == null)
            {
                return;
            }

            Element parent = child.Parent;

            parent.MouseUp(sender, e);

            foreach (IGesture gesture in parent.Gestures)
            {
                gesture.MouseUp(parent, e);
            }

            TryBubbleMouseUp(sender, parent, e);
        }

        private static Element TryGetHitElement(IEnumerable<Element> zOrderedElements, float pointerX, float pointerY)
        {
            foreach (Element element in zOrderedElements.Reverse())
            {
                if (element != null)
                {
                    bool isInRectangle = GeometryCalculations.IsInRectangle(
                            pointerX, pointerY,
                            element.CalculatedX, element.CalculatedY,
                            element.CalculatedX + element.Width, element.CalculatedY + element.Height);

                    if (isInRectangle)
                    {
                        return element;
                    }
                }
            }

            return null;
        }
    }
}
