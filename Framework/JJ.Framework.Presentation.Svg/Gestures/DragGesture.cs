using JJ.Framework.Presentation.Svg.EventArg;
using JJ.Framework.Presentation.Svg.Models.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Gestures
{
    public class DragGesture : GestureBase
    {
        public DragGesture()
        {
            _diagramMouseMoveGesture = new MouseMoveGesture();
            _diagramMouseMoveGesture.MouseMove += _diagram_MouseMove;

            _canvasMouseUpGesture = new MouseUpGesture();
            _canvasMouseUpGesture.MouseUp += _canvas_MouseUp;
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

            if (_canvasMouseUpGesture != null)
            {
                if (_diagram != null)
                {
                    if (_diagram.Canvas.Gestures.Contains(_canvasMouseUpGesture))
                    {
                        _diagram.Canvas.Gestures.Remove(_canvasMouseUpGesture);
                    }
                }
                _canvasMouseUpGesture.MouseUp -= _canvas_MouseUp;
            }
        }

        public event EventHandler<DraggingEventArgs> Dragging;
        public event EventHandler DragCancelled;

        private Diagram _diagram;
        private MouseMoveGesture _diagramMouseMoveGesture;
        private MouseUpGesture _canvasMouseUpGesture;

        internal Element DraggedElement { get; private set; }

        public override void HandleMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Element != null)
            {
                DraggedElement = e.Element;

                if (_diagram == null)
                {
                    if (e.Element.Diagram != null)
                    {
                        _diagram = e.Element.Diagram;
                        _diagram.Gestures.Add(_diagramMouseMoveGesture);
                        _diagram.Canvas.Gestures.Add(_canvasMouseUpGesture);
                    }
                }
            }
        }

        //public override void HandleMouseMove(object sender, MouseEventArgs e)
        //{
        //    if (_draggedElement != null)
        //    {
        //        if (Dragging != null)
        //        {
        //            Dragging(sender, new DraggingEventArgs(_draggedElement, e.X, e.Y));
        //        }
        //    }
        //}

        private void _diagram_MouseMove(object sender, MouseEventArgs e)
        {
            if (DraggedElement != null)
            {
                if (Dragging != null)
                {
                    Dragging(sender, new DraggingEventArgs(DraggedElement, e.X, e.Y));
                }
            }
        }

        public override void HandleMouseUp(object sender, MouseEventArgs e)
        {
            DraggedElement = null;

            if (DragCancelled != null)
            {
                DragCancelled(sender, EventArgs.Empty);
            }
        }

        private void _canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (DraggedElement != null)
            {
                DraggedElement = null;

                if (DragCancelled != null)
                {
                    DragCancelled(sender, EventArgs.Empty);
                }
            }
        }
    }
}
