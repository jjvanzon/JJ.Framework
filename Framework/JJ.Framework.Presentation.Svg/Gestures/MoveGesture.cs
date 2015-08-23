using JJ.Framework.Presentation.Svg.EventArg;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Gestures
{
    public class MoveGesture : GestureBase
    {
        public event EventHandler<MoveEventArgs> Moving;
        public event EventHandler<MoveEventArgs> Moved;

        private float _mouseDownElementX;
        private float _mouseDownElementY;
        private float _mouseDownPointerX;
        private float _mouseDownPointerY;

        private Element _element;

        private bool _wasMoved;

        public override bool MouseCaptureRequired
        {
            get { return true; }
        }

        public override void HandleMouseDown(object sender, MouseEventArgs e)
        {
            if (e == null) throw new NullException(() => e);

            if (e.Element != null)
            {
                _element = e.Element;

                _mouseDownElementX = _element.X;
                _mouseDownElementY = _element.Y;

                _mouseDownPointerX = e.X;
                _mouseDownPointerY = e.Y;

                _wasMoved = false;
            }
        }

        public override void HandleMouseMove(object sender, MouseEventArgs e)
        {
            if (e == null) throw new NullException(() => e);

            if (_element != null)
            {
                float deltaX = e.X - _mouseDownPointerX;
                float deltaY = e.Y - _mouseDownPointerY;

                _element.X = _mouseDownElementX + deltaX;
                _element.Y = _mouseDownElementY + deltaY;

                if (Moving != null)
                {
                    Moving(sender, new MoveEventArgs(_element));
                }

                _wasMoved = true;
            }
        }

        public override void HandleMouseUp(object sender, MouseEventArgs e)
        {
            // TODO: I don't know for sure why _element could be null, but it was at one point. 
            // I suspect this happens when you are clicking around very fast and get a race condition,
            // since it is one gesture object for multiple elements.
            if (_element == null)
            {
                return;
            }

            if (!_wasMoved)
            {
                return;
            }

            if (Moved != null)
            {
                Moved(sender, new MoveEventArgs(_element));
            }

            _element = null;
        }
    }
}
