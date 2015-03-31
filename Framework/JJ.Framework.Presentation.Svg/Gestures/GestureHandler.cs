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
        private Diagram _diagram;

        private IList<IGesture> _gestures;
        //public event EventHandler<GestureEventArgs> OnGesture;

        public GestureHandler(Diagram diagram, IList<IGesture> gestures = null)
        {
            if (diagram == null) throw new NullException(() => diagram);

            _diagram = diagram;
            _gestures = gestures ?? new IGesture[0];
        }

        public void MouseDown(MouseEventArgs e)
        {
            IEnumerable<Element> zOrdereredElements = _diagram.EnumerateElementsByZIndex();

            Element hitElement = TryGetHitElement(zOrdereredElements, e.X, e.Y);

            if (hitElement != null)
            {
                hitElement.MouseDown(hitElement, e);

                foreach (IGesture gesture in _gestures)
                {
                    gesture.MouseDown(hitElement, e);
                }

                //if (OnGesture != null)
                //{
                //    OnGesture(hitElement, new GestureEventArgs(null, hitElement));
                //}

                // Event bubbling
                Element parent = hitElement.Parent;
                while (parent != null && parent.EventBubblingEnabled)
                {
                    parent.MouseDown(hitElement, e);

                    foreach (IGesture gesture in _gestures)
                    {
                        gesture.MouseDown(parent, e);
                    }

                    //if (OnGesture != null)
                    //{
                    //    OnGesture(parent, new GestureEventArgs(null, hitElement));
                    //}

                    parent = parent.Parent;
                }
            }
        }

        public void MouseMove(MouseEventArgs e)
        {
            IEnumerable<Element> zOrdereredElements = _diagram.EnumerateElementsByZIndex();
            Element hitElement = TryGetHitElement(zOrdereredElements, e.X, e.Y);
            if (hitElement != null)
            {
                hitElement.MouseMove(hitElement, e);

                foreach (IGesture gesture in _gestures)
                {
                    gesture.MouseMove(hitElement, e);
                }

                // Event bubbling
                Element parent = hitElement.Parent;
                while (parent != null && parent.EventBubblingEnabled)
                {
                    parent.MouseMove(hitElement, e);

                    foreach (IGesture gesture in _gestures)
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
            Element hitElement = TryGetHitElement(zOrdereredElements, e.X, e.Y);
            if (hitElement != null)
            {
                hitElement.MouseUp(hitElement, e);

                foreach (IGesture gesture in _gestures)
                {
                    gesture.MouseUp(hitElement, e);
                }

                // Event bubbling
                Element parent = hitElement.Parent;
                while (parent != null && parent.EventBubblingEnabled)
                {
                    parent.MouseUp(hitElement, e);

                    foreach (IGesture gesture in _gestures)
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
