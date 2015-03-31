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
        private float _mouseDownElementX;
        private float _mouseDownElementY;
        private float _mouseDownPointerX;
        private float _mouseDownPointerY;

        private Element _element;

        void IGesture.MouseDown(object sender, MouseEventArgs e)
        {
            var element = sender as Element;
            if (element != null)
            {
                _element = element;

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
            }
        }

        void IGesture.MouseUp(object sender, MouseEventArgs e)
        {
            _element = null;
        }
    }
}
