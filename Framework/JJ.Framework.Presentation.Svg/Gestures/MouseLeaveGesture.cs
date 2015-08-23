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
        private MouseMoveGesture _diagramMouseMoveGesture;

        public MouseLeaveGesture()
        {
            _diagramMouseMoveGesture = new MouseMoveGesture();
            _diagramMouseMoveGesture.MouseMove += _diagramMouseMoveGesture_MouseMove;
        }

        ~MouseLeaveGesture()
        { 
            if (_diagram != null)
            {
                if (_diagramMouseMoveGesture != null)
                {
                    _diagramMouseMoveGesture.MouseMove -= _diagramMouseMoveGesture_MouseMove;
                    if (_diagram.Gestures.Contains(_diagramMouseMoveGesture))
                    {
                        _diagram.Gestures.Remove(_diagramMouseMoveGesture);
                    }
                }
            }
        }

        private Element _previousSender;

        public override void HandleMouseMove(object sender, MouseEventArgs e)
        {
            if (e == null) throw new NullException(() => e);

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
                    _diagram.Gestures.Add(_diagramMouseMoveGesture);
                }
            }

            _previousSender = sender as Element;
        }

        private void _diagramMouseMoveGesture_MouseMove(object sender, MouseEventArgs e)
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
