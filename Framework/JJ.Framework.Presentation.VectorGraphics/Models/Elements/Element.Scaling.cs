using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Reflection.Exceptions;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    public abstract partial class Element
    {
        // Scaling

        public float RelativeToAbsoluteX(float relativeX)
        {
            float absoluteX = relativeX;

            Element element = this;
            while (element != null)
            {
                absoluteX += element.X;
                element = element.Parent;
            }

            return absoluteX;
        }

        public float RelativeToAbsoluteY(float relativeY)
        {
            float absoluteY = relativeY;

            Element element = this;
            while (element != null)
            {
                absoluteY += element.Y;
                element = element.Parent;
            }

            return absoluteY;
        }

        public float AbsoluteToRelativeX(float absoluteX)
        {
            float relativeX = absoluteX;

            Element element = this;
            while (element != null)
            {
                relativeX -= element.X;
                element = element.Parent;
            }

            return relativeX;
        }

        public float AbsoluteToRelativeY(float absoluteY)
        {
            float relativeY = absoluteY;

            Element element = this;
            while (element != null)
            {
                relativeY -= element.Y;
                element = element.Parent;
            }

            return relativeY;
        }

        // To and from pixels is derived from the conversions between relative and absolute,
        // and the diagram's conversions between pixels and scaled.

        public float PixelsToRelativeX(float xInPixels)
        {
            if (Diagram == null) throw new NullException(() => Diagram);

            float value = Diagram.PixelsToScaledX(xInPixels);
            value = AbsoluteToRelativeX(value);
            return value;
        }

        public float PixelsToRelativeY(float yInPixels)
        {
            if (Diagram == null) throw new NullException(() => Diagram);

            float value = Diagram.PixelsToScaledY(yInPixels);
            value = AbsoluteToRelativeY(value);
            return value;
        }

        public float RelativeToPixelsX(float relativeX)
        {
            if (Diagram == null) throw new NullException(() => Diagram);

            float value = RelativeToAbsoluteX(relativeX);
            value = Diagram.ScaledToPixelsX(value);
            return value;
        }

        public float RelativeToPixelsY(float relativeY)
        {
            if (Diagram == null) throw new NullException(() => Diagram);

            float value = RelativeToAbsoluteY(relativeY);
            value = Diagram.ScaledToPixelsY(value);
            return value;
        }

        public float PixelsToAbsoluteX(float xInPixels)
        {
            if (Diagram == null) throw new NullException(() => Diagram);

            // Just delegates to the Diagram method. These methods are here for syntactic sugar.
            float value = Diagram.PixelsToScaledX(xInPixels);
            return value;
        }

        public float PixelsToAbsoluteY(float yInPixels)
        {
            if (Diagram == null) throw new NullException(() => Diagram);

            // Just delegates to the Diagram method. These methods are here for syntactic sugar.
            float value = Diagram.PixelsToScaledY(yInPixels);
            return value;
        }

        public float AbsoluteToPixelsX(float absoluteX)
        {
            if (Diagram == null) throw new NullException(() => Diagram);

            // Just delegates to the Diagram method. These methods are here for syntactic sugar.
            float value = Diagram.ScaledToPixelsX(absoluteX);
            return value;
        }

        public float AbsoluteToPixelsY(float absoluteY)
        {
            if (Diagram == null) throw new NullException(() => Diagram);

            // Just delegates to the Diagram method. These methods are here for syntactic sugar.
            float value = Diagram.ScaledToPixelsY(absoluteY);
            return value;
        }

        public float AbsoluteX
        {
            get { return RelativeToAbsoluteX(0); }
        }

        public float AbsoluteY
        {
            get { return RelativeToAbsoluteY(0); }
        }

        public float XInPixels
        {
            get { return RelativeToPixelsX(0); }
        }

        public float YInPixels
        {
            get { return RelativeToPixelsY(0); }
        }
    }
}
