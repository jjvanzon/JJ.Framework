using JJ.Framework.Presentation.Svg.EventArg;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Gestures
{
    public class MouseLeaveGesture : GestureBase
    {
        public event EventHandler<MouseEventArgs> MouseLeave;

        private Diagram _diagram;
        private MouseMoveGesture _canvasMouseMoveGesture;

        public MouseLeaveGesture()
        {
            _canvasMouseMoveGesture = new MouseMoveGesture();
            _canvasMouseMoveGesture.MouseMove += _canvasMouseMoveGesture_MouseMove;
        }

        ~MouseLeaveGesture()
        { 
            if (_diagram != null)
            {
                if (_canvasMouseMoveGesture != null)
                {
                    _canvasMouseMoveGesture.MouseMove -= _canvasMouseMoveGesture_MouseMove;
                    if (_diagram.Canvas.Gestures.Contains(_canvasMouseMoveGesture))
                    {
                        _diagram.Canvas.Gestures.Remove(_canvasMouseMoveGesture);
                    }
                }
            }
        }

        private Element _previousSender;

        public override void HandleMouseMove(object sender, MouseEventArgs e)
        {
            if (MouseLeave == null)
            {
                return;
            }

            // We bind to the first diagram we encounter,
            // because we do not want to burdon the interface with passing a Diagram to the constructor.
            if (_diagram == null)
            {
                if (e.Element.Diagram != null)
                {
                    _diagram = e.Element.Diagram;
                    _diagram.Canvas.Gestures.Add(_canvasMouseMoveGesture);
                }
            }

            _previousSender = sender as Element;
        }

        private void _canvasMouseMoveGesture_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender != _previousSender)
            {
                var e2 = new MouseEventArgs(_previousSender, e.X, e.Y, e.MouseButtonEnum);
                MouseLeave(sender, e2);

                _previousSender = sender as Element;
            }
        }
    }
}
