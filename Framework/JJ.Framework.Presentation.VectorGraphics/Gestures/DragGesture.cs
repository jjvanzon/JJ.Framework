using JJ.Framework.Presentation.VectorGraphics.EventArg;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Reflection.Exceptions;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.Gestures
{
    public class DragGesture : GestureBase
    {
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

        public event EventHandler<DraggingEventArgs> Dragging;
        public event EventHandler DragCanceled;

        private Diagram _diagram;
        private MouseMoveGesture _diagramMouseMoveGesture;
        private MouseUpGesture _backgroundMouseUpGesture;

        internal Element DraggedElement { get; private set; }

        public override void HandleMouseDown(object sender, MouseEventArgs e)
        {
            if (e == null) throw new NullException(() => e);

            if (e.Element != null)
            {
                DraggedElement = e.Element;

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

            if (DragCanceled != null)
            {
                DragCanceled(sender, EventArgs.Empty);
            }
        }

        private void _background_MouseUp(object sender, MouseEventArgs e)
        {
            if (DraggedElement != null)
            {
                DraggedElement = null;

                if (DragCanceled != null)
                {
                    DragCanceled(sender, EventArgs.Empty);
                }
            }
        }
    }
}
