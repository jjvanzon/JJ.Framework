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
        private Diagram _diagram;

        private Element _mouseCapturingElement;

        public GestureHandler(Diagram diagram)
        {
            if (diagram == null) throw new NullException(() => diagram);

            _diagram = diagram;

            InitializeMouseMoveGesture();
        }

        ~GestureHandler()
        {
            FinalizeMouseMoveGesture();
        }

        public void HandleMouseDown(MouseEventArgs e)
        {
            _mouseMoveGesture.HandleMouseDown(this, e);

            IEnumerable<Element> zOrdereredElements = _diagram.EnumerateElementsByZIndex();

            Element hitElement = TryGetHitElement(zOrdereredElements, e.X, e.Y);

            if (hitElement != null)
            {
                var e2 = new MouseEventArgs(hitElement, e.X, e.Y, e.MouseButtonEnum);

                foreach (IGesture gesture in hitElement.Gestures)
                {
                    gesture.HandleMouseDown(hitElement, e2);
                }

                TryBubbleMouseDown(hitElement, hitElement, e);

                if (hitElement.Gestures.Any(x => x.MouseCaptureRequired))
                {
                    _mouseCapturingElement = hitElement;
                }
            }
        }

        private void TryBubbleMouseDown(Element sender, Element child, MouseEventArgs e)
        {
            if (child.Parent == null)
            {
                return;
            }

            Element parent = child.Parent;
            var e2 = new MouseEventArgs(parent, e.X, e.Y, e.MouseButtonEnum);

            if (!child.MustBubble)
            {
                return;
            }

            foreach (IGesture gesture in parent.Gestures)
            {
                gesture.HandleMouseDown(sender, e2);
            }

            TryBubbleMouseDown(sender, parent, e);

            if (parent.Gestures.Any(x => x.MouseCaptureRequired))
            {
                _mouseCapturingElement = child;
            }
        }

        /// <summary>
        /// In WinForms a mouse move will go off upon mouse down, even though you did not even move the mouse at all
        /// All gestures have trouble with this if you do not solve it at this level.
        /// </summary>
        private IGesture _mouseMoveGesture;

        private void InitializeMouseMoveGesture()
        {
            MouseMoveGesture mouseMoveGesture = new MouseMoveGesture();
            mouseMoveGesture.MouseMove += mouseMoveGesture_MouseMove;
            _mouseMoveGesture = mouseMoveGesture;
        }

        private void FinalizeMouseMoveGesture()
        {
            if (_mouseMoveGesture != null)
            {
                MouseMoveGesture mouseMoveGesture = (MouseMoveGesture)_mouseMoveGesture;
                mouseMoveGesture.MouseMove -= mouseMoveGesture_MouseMove;
            }
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            _mouseMoveGesture.HandleMouseMove(this, e);
        }

        private void mouseMoveGesture_MouseMove(object sender, MouseEventArgs e)
        {
            IEnumerable<Element> zOrdereredElements = _diagram.EnumerateElementsByZIndex();

            Element hitElement = _mouseCapturingElement;
            if (hitElement == null)
            {
                hitElement = TryGetHitElement(zOrdereredElements, e.X, e.Y);
            }

            if (hitElement != null)
            {
                var e2 = new MouseEventArgs(hitElement, e.X, e.Y, e.MouseButtonEnum);

                foreach (IGesture gesture in hitElement.Gestures)
                {
                    gesture.HandleMouseMove(hitElement, e2);
                }

                TryBubbleMouseMove(hitElement, hitElement, e);
            }
        }

        private void TryBubbleMouseMove(object sender, Element child, MouseEventArgs e)
        {
            if (child.Parent == null)
            {
                return;
            }

            if (!child.MustBubble)
            {
                return;
            }

            Element parent = child.Parent;
            MouseEventArgs e2 = new MouseEventArgs(parent, e.X, e.Y, e.MouseButtonEnum);

            foreach (IGesture gesture in parent.Gestures)
            {
                gesture.HandleMouseMove(sender, e2);
            }

            TryBubbleMouseMove(sender, parent, e);
        }

        public void HandleMouseUp(MouseEventArgs e)
        {
            _mouseMoveGesture.HandleMouseUp(this, e);

            IEnumerable<Element> zOrdereredElements = _diagram.EnumerateElementsByZIndex();

            Element hitElement = _mouseCapturingElement;
            if (hitElement == null)
            {
                hitElement = TryGetHitElement(zOrdereredElements, e.X, e.Y);
            }

            if (hitElement != null)
            {
                var e2 = new MouseEventArgs(hitElement, e.X, e.Y, e.MouseButtonEnum);

                foreach (IGesture gesture in hitElement.Gestures)
                {
                    gesture.HandleMouseUp(hitElement, e2);
                }

                TryBubbleMouseUp(hitElement, hitElement, e);
            }

            _mouseCapturingElement = null;
        }

        private void TryBubbleMouseUp(Element sender, Element child, MouseEventArgs e)
        {
            if (child.Parent == null)
            {
                return;
            }

            if (!child.MustBubble)
            {
                return;
            }

            Element parent = child.Parent;
            MouseEventArgs e2 = new MouseEventArgs(parent, e.X, e.Y, e.MouseButtonEnum);

            foreach (IGesture gesture in parent.Gestures)
            {
                gesture.HandleMouseUp(sender, e2);
            }

            TryBubbleMouseUp(sender, parent, e);
        }

        public void HandleKeyDown(KeyEventArgs e)
        {
            foreach (IGesture gesture in _diagram.Canvas.Gestures)
            {
                gesture.HandleKeyDown(_diagram.Canvas, e);
            }
        }

        public void HandleKeyUp(KeyEventArgs e)
        {
            foreach (IGesture gesture in _diagram.Canvas.Gestures)
            {
                gesture.HandleKeyUp(_diagram.Canvas, e);
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
