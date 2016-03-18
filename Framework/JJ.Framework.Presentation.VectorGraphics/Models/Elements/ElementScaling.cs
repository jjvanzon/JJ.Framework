using System;
using System.Collections.Generic;
using System.Linq;
using JJ.Framework.Presentation.VectorGraphics.Helpers;
using JJ.Framework.Reflection.Exceptions;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    public class ElementScaling
    {
        private readonly Element _element;

        public ElementScaling(Element element)
        {
            if (element == null) throw new NullException(() => element);

            _element = element;
        }

        public float AbsoluteX
        {
            get { return ScaleHelper.RelativeToAbsoluteX(_element, 0); }
        }

        public float AbsoluteY
        {
            get { return ScaleHelper.RelativeToAbsoluteY(_element, 0); }
        }

        public float XInPixels
        {
            get { return ScaleHelper.RelativeToPixelsX(_element, 0); }
        }

        public float YInPixels
        {
            get { return ScaleHelper.RelativeToPixelsY(_element, 0); }
        }

        public float RelativeToAbsoluteX(float relativeX)
        {
            return ScaleHelper.RelativeToAbsoluteX(_element, relativeX);
        }

        public float RelativeToAbsoluteY(float relativeY)
        {
            return ScaleHelper.RelativeToAbsoluteY(_element, relativeY);
        }

        public float AbsoluteToRelativeX(float absoluteX)
        {
            return ScaleHelper.AbsoluteToRelativeX(_element, absoluteX);
        }

        public float AbsoluteToRelativeY(float absoluteY)
        {
            return ScaleHelper.AbsoluteToRelativeY(_element, absoluteY);
        }

        public float PixelsToRelativeX(float xInPixels)
        {
            return ScaleHelper.PixelsToRelativeX(_element, xInPixels);
        }

        public float PixelsToRelativeY(float yInPixels)
        {
            return ScaleHelper.PixelsToRelativeY(_element, yInPixels);
        }

        public float RelativeToPixelsX(float relativeX)
        {
            return ScaleHelper.RelativeToPixelsX(_element, relativeX);
        }

        public float RelativeToPixelsY(float relativeY)
        {
            return ScaleHelper.RelativeToPixelsY(_element, relativeY);
        }

        public float PixelsToAbsoluteX(float xInPixels)
        {
            return ScaleHelper.PixelsToAbsoluteX(_element, xInPixels);
        }

        public float PixelsToAbsoluteY(float yInPixels)
        {
            return ScaleHelper.PixelsToAbsoluteY(_element, yInPixels);
        }

        public float AbsoluteToPixelsX(float absoluteX)
        {
            return ScaleHelper.AbsoluteToPixelsX(_element, absoluteX);
        }

        public float AbsoluteToPixelsY(float absoluteY)
        {
            return ScaleHelper.AbsoluteToPixelsY(_element, absoluteY);
        }

        public float RelativeRight
        {
            get { return _element.X + _element.Width; }
        }

        public float RelativeBottom
        {
            get { return _element.Y + _element.Height; }
        }

        public float AbsoluteRight
        {
            get { return AbsoluteX + _element.Width; }
        }

        public float AbsoluteBottom
        {
            get { return AbsoluteY + _element.Height; }
        }
    }
}
