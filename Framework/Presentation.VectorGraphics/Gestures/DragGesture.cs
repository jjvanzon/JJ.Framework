﻿using JJ.Framework.Presentation.VectorGraphics.EventArg;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.Gestures
{
    public class DragGesture : GestureBase
    {
        public event EventHandler<DraggingEventArgs> Dragging;
        public event EventHandler DragCanceled;

        private readonly MouseMoveGesture _diagramMouseMoveGesture;
        private readonly MouseUpGesture _backgroundMouseUpGesture;

        internal Element DraggedElement { get; set; }

        private Diagram _diagram;

        public DragGesture()
        {
            _diagramMouseMoveGesture = new MouseMoveGesture();
            _diagramMouseMoveGesture.MouseMove += _diagram_MouseMove;

            _backgroundMouseUpGesture = new MouseUpGesture();
            _backgroundMouseUpGesture.MouseUp += _background_MouseUp;
        }

        ~DragGesture()
        {
            if (_diagramMouseMoveGesture != null)
            {
                if (_diagram != null)
                {
                    if (_diagram.Gestures.Contains(_diagramMouseMoveGesture))
                    {
                        _diagram.Gestures.Remove(_diagramMouseMoveGesture);
                    }
                }
                _diagramMouseMoveGesture.MouseMove -= _diagram_MouseMove;
            }

            if (_backgroundMouseUpGesture != null)
            {
                if (_diagram != null)
                {
                    if (_diagram.Background.Gestures.Contains(_backgroundMouseUpGesture))
                    {
                        _diagram.Background.Gestures.Remove(_backgroundMouseUpGesture);
                    }
                }
                _backgroundMouseUpGesture.MouseUp -= _background_MouseUp;
            }
        }

        protected override void HandleMouseDown(object sender, MouseEventArgs e)
        {
            DoInitializeDiagram(e);

            DoStartDrag(e);
        }

        private void _diagram_MouseMove(object sender, MouseEventArgs e)
        {
            DoDragging(sender, e);
        }

        protected override void HandleMouseUp(object sender, MouseEventArgs e)
        {
            DoDragCancelled(sender);
        }

        private void _background_MouseUp(object sender, MouseEventArgs e)
        {
            DoDragCancelled(sender);
        }

        private void DoInitializeDiagram(MouseEventArgs e)
        {
            if (e.Element != null)
            {
                if (_diagram == null)
                {
                    if (e.Element.Diagram != null)
                    {
                        _diagram = e.Element.Diagram;
                        _diagram.Gestures.Add(_diagramMouseMoveGesture);
                        _diagram.Background.Gestures.Add(_backgroundMouseUpGesture);
                    }
                }
            }
        }

        private void DoStartDrag(MouseEventArgs e)
        {
            if (e.Element != null)
            {
                DraggedElement = e.Element;
            }
        }

        private void DoDragging(object sender, MouseEventArgs e)
        {
            if (DraggedElement != null)
            {
                Dragging?.Invoke(sender, new DraggingEventArgs(DraggedElement, e.XInPixels, e.YInPixels));
            }
        }

        private void DoDragCancelled(object sender)
        {
            if (DraggedElement != null)
            {
                DraggedElement = null;

                DragCanceled?.Invoke(sender, EventArgs.Empty);
            }
        }
    }
}
