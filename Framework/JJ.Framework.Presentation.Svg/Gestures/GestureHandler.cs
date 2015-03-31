using JJ.Framework.Presentation.Svg.EventArg;
using JJ.Framework.Presentation.Svg.Gestures;
using JJ.Framework.Presentation.Svg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection;
using JJ.Framework.Common;
using JJ.Framework.Mathematics;
using JJ.Framework.Presentation.Svg.Elements;

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

                // Event bubbling
                Element parent = hitElement.Parent;
                while (parent != null && parent.Bubble)
                {
                    parent.MouseDown(hitElement, e);

                    foreach (IGesture gesture in parent.Gestures)
                    {
                        gesture.MouseDown(parent, e);
                    }

                    if (parent.MouseCaptureEnabled)
                    {
                        _pointerCapturingElement = hitElement;
                    }

                    parent = parent.Parent;
                }

                if (hitElement.MouseCaptureEnabled)
                {
                    _pointerCapturingElement = hitElement;
                }
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
                hitElement.MouseMove(hitElement, e);

                foreach (IGesture gesture in hitElement.Gestures)
                {
                    gesture.MouseMove(hitElement, e);
                }

                // Event bubbling
                Element parent = hitElement.Parent;
                while (parent != null && parent.Bubble)
                {
                    parent.MouseMove(hitElement, e);

                    foreach (IGesture gesture in parent.Gestures)
                    {
                        gesture.MouseMove(parent, e);
                    }

                    parent = parent.Parent;
                }
            }
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

                // Event bubbling
                Element parent = hitElement.Parent;
                while (parent != null && parent.Bubble)
                {
                    parent.MouseUp(hitElement, e);

                    foreach (IGesture gesture in parent.Gestures)
                    {
                        gesture.MouseUp(parent, e);
                    }

                    parent = parent.Parent;
                }
            }
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
