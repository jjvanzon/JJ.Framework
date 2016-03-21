using System;
using System.Linq;
using System.Collections.Generic;
using JJ.Framework.Reflection.Exceptions;
using JJ.Framework.Mathematics;
using JJ.Framework.Presentation.VectorGraphics.EventArg;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;

namespace JJ.Framework.Presentation.VectorGraphics.Gestures
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

        // MouseDown

        public void HandleMouseDown(MouseEventArgs e)
        {
            _mouseMoveGesture.HandleMouseDown(this, e);

            IEnumerable<Element> zOrdereredElements = _diagram.EnumerateElementsByZIndex();

            Element hitElement = TryGetHitElement(zOrdereredElements, e.XInPixels, e.YInPixels);

            if (hitElement != null)
            {
                var e2 = new MouseEventArgs(hitElement, e.XInPixels, e.YInPixels, e.MouseButtonEnum);

                foreach (IGesture diagramGesture in _diagram.Gestures.ToArray())
                {
                    diagramGesture.HandleMouseDown(hitElement, e);
                }

                foreach (IGesture gesture in hitElement.Gestures.ToArray()) // The ToArray is a safety measure in case delegates modify the gesture collection.
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
            Element parent = child.Parent;

            if (parent == null)
            {
                return;
            }

            if (!parent.CalculatedValues.Enabled)
            {
                return;
            }

            if (!child.MustBubble)
            {
                return;
            }

            var e2 = new MouseEventArgs(parent, e.XInPixels, e.YInPixels, e.MouseButtonEnum);

            foreach (IGesture gesture in parent.Gestures.ToArray()) // The ToArray is a safety measure in case delegates modify the gesture collection.
            {
                gesture.HandleMouseDown(sender, e2);
            }

            TryBubbleMouseDown(sender, parent, e);

            if (parent.Gestures.Any(x => x.MouseCaptureRequired))
            {
                _mouseCapturingElement = child;
            }
        }

        // MouseMove

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
                hitElement = TryGetHitElement(zOrdereredElements, e.XInPixels, e.YInPixels);
            }

            if (hitElement != null)
            {
                var e2 = new MouseEventArgs(hitElement, e.XInPixels, e.YInPixels, e.MouseButtonEnum);

                foreach (IGesture diagramGesture in _diagram.Gestures.ToArray())
                {
                    diagramGesture.HandleMouseMove(hitElement, e2);
                }

                foreach (IGesture gesture in hitElement.Gestures.ToArray()) // The ToArray is a safety measure in case delegates modify the gesture collection.
                {
                    gesture.HandleMouseMove(hitElement, e2);
                }

                TryBubbleMouseMove(hitElement, hitElement, e);
            }
        }

        private void TryBubbleMouseMove(object sender, Element child, MouseEventArgs e)
        {
            if (!child.MustBubble)
            {
                return;
            }

            Element parent = child.Parent;

            if (child.Parent == null)
            {
                return;
            }

            if (!child.Parent.CalculatedValues.Enabled)
            {
                return;
            }

            MouseEventArgs e2 = new MouseEventArgs(parent, e.XInPixels, e.YInPixels, e.MouseButtonEnum);

            foreach (IGesture gesture in parent.Gestures.ToArray()) // The ToArray is a safety measure in case delegates modify the gesture collection.
            {
                gesture.HandleMouseMove(sender, e2);
            }

            TryBubbleMouseMove(sender, parent, e);
        }

        // MouseUp

        public void HandleMouseUp(MouseEventArgs e)
        {
            _mouseMoveGesture.HandleMouseUp(this, e);

            IEnumerable<Element> zOrdereredElements = _diagram.EnumerateElementsByZIndex();

            Element hitElement = _mouseCapturingElement;
            if (hitElement == null)
            {
                hitElement = TryGetHitElement(zOrdereredElements, e.XInPixels, e.YInPixels);
            }

            if (hitElement != null)
            {
                var e2 = new MouseEventArgs(hitElement, e.XInPixels, e.YInPixels, e.MouseButtonEnum);

                foreach (IGesture diagramGesture in _diagram.Gestures.ToArray())
                {
                    diagramGesture.HandleMouseUp(hitElement, e2);
                }

                foreach (IGesture gesture in hitElement.Gestures.ToArray()) // The ToArray is a safety measure in case delegates modify the gesture collection.
                {
                    gesture.HandleMouseUp(hitElement, e2);
                }

                TryBubbleMouseUp(hitElement, hitElement, e);
            }

            _mouseCapturingElement = null;
        }

        private void TryBubbleMouseUp(Element sender, Element child, MouseEventArgs e)
        {
            if (!child.MustBubble)
            {
                return;
            }

            Element parent = child.Parent;

            if (parent == null)
            {
                return;
            }

            if (!parent.CalculatedValues.Enabled)
            {
                return;
            }

            MouseEventArgs e2 = new MouseEventArgs(parent, e.XInPixels, e.YInPixels, e.MouseButtonEnum);

            foreach (IGesture gesture in parent.Gestures.ToArray()) // The ToArray is a safety measure in case delegates modify the gesture collection.
            {
                gesture.HandleMouseUp(sender, e2);
            }

            TryBubbleMouseUp(sender, parent, e);
        }

        // Key Events

        public void HandleKeyDown(KeyEventArgs e)
        {
            foreach (IGesture gesture in _diagram.Gestures.ToArray())
            {
                gesture.HandleKeyDown(_diagram, e);
            }

            foreach (IGesture gesture in _diagram.Background.Gestures.ToArray()) // The ToArray is a safety measure in case delegates modify the gesture collection.
            {
                gesture.HandleKeyDown(_diagram.Background, e);
            }
        }

        public void HandleKeyUp(KeyEventArgs e)
        {
            foreach (IGesture gesture in _diagram.Gestures.ToArray())
            {
                gesture.HandleKeyUp(_diagram, e);
            }

            foreach (IGesture gesture in _diagram.Background.Gestures.ToArray()) // The ToArray is a safety measure in case delegates modify the gesture collection.
            {
                gesture.HandleKeyUp(_diagram.Background, e);
            }
        }

        // Hit Testing

        private Element TryGetHitElement(IEnumerable<Element> zOrderedElements, float pointerXInPixels, float pointerYInPixels)
        {
            foreach (Element element in zOrderedElements.Reverse())
            {
                if (!element.CalculatedValues.Enabled)
                {
                    continue;
                }

                bool isInRectangle = Geometry.IsInRectangle(
                    pointerXInPixels, 
                    pointerYInPixels,
                    element.CalculatedValues.XInPixels, 
                    element.CalculatedValues.YInPixels,
                    element.CalculatedValues.XInPixels + element.CalculatedValues.WidthInPixels, 
                    element.CalculatedValues.YInPixels + element.CalculatedValues.HeightInPixels);

                if (isInRectangle)
                {
                    return element;
                }
            }

            return null;
        }
    }
}
