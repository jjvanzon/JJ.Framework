using JJ.Framework.Presentation.Svg.EventArg;
using JJ.Framework.Presentation.Svg.Models.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Gestures
{
    public class MoveGesture : IGesture
    {
        public event EventHandler<MoveEventArgs> Moving;
        public event EventHandler<MoveEventArgs> Moved;

        private float _mouseDownElementX;
        private float _mouseDownElementY;
        private float _mouseDownPointerX;
        private float _mouseDownPointerY;

        private Element _element;

        bool IGesture.MouseCaptureRequired
        {
            get { return true; }
        }

        void IGesture.MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Element != null)
            {
                _element = e.Element;

                _mouseDownElementX = _element.X;
                _mouseDownElementY = _element.Y;

                _mouseDownPointerX = e.X;
                _mouseDownPointerY = e.Y;
            }
        }

        void IGesture.MouseMove(object sender, MouseEventArgs e)
        {
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
            }
        }

        void IGesture.MouseUp(object sender, MouseEventArgs e)
        {
            // TODO: I don't know for sure why _element could be null, but it was at one point. 
            // I suspect this happens when you are clicking around very fast and get a race condition,
            // since it is one gesture object for multiple elements.
            if (_element == null)
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
