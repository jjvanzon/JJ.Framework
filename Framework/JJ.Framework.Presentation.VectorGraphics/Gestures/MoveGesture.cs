using JJ.Framework.Presentation.VectorGraphics.EventArg;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.Gestures
{
    public class MoveGesture : GestureBase
    {
        public event EventHandler<ElementEventArgs> Moving;
        public event EventHandler<ElementEventArgs> Moved;

        private float _mouseDownElementX;
        private float _mouseDownElementY;
        private float _mouseDownPointerX;
        private float _mouseDownPointerY;

        private Diagram _diagram;
        private MouseMoveGesture _diagramMouseMoveGesture;
        private Element _elementBeingMoved;
        private bool _wasMoved;

        public MoveGesture()
        {
            _diagramMouseMoveGesture = new MouseMoveGesture();
            _diagramMouseMoveGesture.MouseMove += _diagram_MouseMove;
        }

        ~MoveGesture()
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
        }

        public override bool MouseCaptureRequired
        {
            get { return true; }
        }

        public override void HandleMouseDown(object sender, MouseEventArgs e)
        {
            DoInitializeDiagram(e);
            DoMouseDown(e);
        }

        private void _diagram_MouseMove(object sender, MouseEventArgs e)
        {
            DoMouseMove(sender, e);
        }

        public override void HandleMouseUp(object sender, MouseEventArgs e)
        {
            DoMouseUp(sender);
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
                    }
                }
            }
        }

        private void DoMouseDown(MouseEventArgs e)
        {
            if (e.Element != null)
            {
                _elementBeingMoved = e.Element;

                _mouseDownElementX = _elementBeingMoved.X;
                _mouseDownElementY = _elementBeingMoved.Y;

                _mouseDownPointerX = e.X;
                _mouseDownPointerY = e.Y;

                _wasMoved = false;
            }
        }

        private void DoMouseMove(object sender, MouseEventArgs e)
        {
            if (_elementBeingMoved != null)
            {
                float deltaX = e.X - _mouseDownPointerX;
                float deltaY = e.Y - _mouseDownPointerY;

                // TODO: Probably e.X and _mouseDownPointerX should already have been scaled coordinates.
                deltaX = _diagram.PixelsToScaledX(deltaX) - _diagram.Background.X;
                deltaY = _diagram.PixelsToScaledY(deltaY) - _diagram.Background.Y;

                _elementBeingMoved.X = _mouseDownElementX + deltaX;
                _elementBeingMoved.Y = _mouseDownElementY + deltaY;

                _wasMoved = true;

                if (Moving != null)
                {
                    Moving(sender, new ElementEventArgs(_elementBeingMoved));
                }
            }
        }

        private void DoMouseUp(object sender)
        {
            // TODO: I don't know for sure why _element could be null, but it was at one point. 
            // I suspect this happens when you are clicking around very fast and get a race condition,
            // since it is one gesture object for multiple elements.
            if (_elementBeingMoved != null)
            {
                if (_wasMoved)
                {
                    if (Moved != null)
                    {
                        Moved(sender, new ElementEventArgs(_elementBeingMoved));
                    }
                }
            }

            _elementBeingMoved = null;
            _wasMoved = false; // Not really required, but it seems weird not to set it to false.
        }
    }
}