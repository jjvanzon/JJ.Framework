using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.Presentation.VectorGraphics.Enums;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Reflection.Exceptions;

namespace JJ.Framework.Presentation.VectorGraphics.Helpers
{
    public static class ScaleHelper
    {
        // Diagram

        public static float PixelsToX(Diagram diagram, float xInPixels)
        {
            if (diagram == null) throw new NullException(() => diagram);

            switch (diagram.ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return xInPixels;

                case ScaleModeEnum.ViewPort:
                    float scaledX = diagram.ScaledX + xInPixels / diagram.WidthInPixels * diagram.ScaledWidth;
                    return scaledX;

                default:
                    throw new ValueNotSupportedException(diagram.ScaleModeEnum);
            }
        }

        public static float PixelsToY(Diagram diagram, float yInPixels)
        {
            if (diagram == null) throw new NullException(() => diagram);

            switch (diagram.ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return yInPixels;

                case ScaleModeEnum.ViewPort:
                    float scaledY = diagram.ScaledY + yInPixels / diagram.HeightInPixels * diagram.ScaledHeight;
                    return scaledY;

                default:
                    throw new ValueNotSupportedException(diagram.ScaleModeEnum);
            }
        }

        public static float XToPixels(Diagram diagram, float scaledX)
        {
            if (diagram == null) throw new NullException(() => diagram);

            switch (diagram.ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return scaledX;

                case ScaleModeEnum.ViewPort:
                    float xInPixels = (scaledX - diagram.ScaledX) / diagram.ScaledWidth * diagram.WidthInPixels;
                    return xInPixels;

                default:
                    throw new ValueNotSupportedException(diagram.ScaleModeEnum);
            }
        }

        public static float YToPixels(Diagram diagram, float scaledY)
        {
            if (diagram == null) throw new NullException(() => diagram);

            switch (diagram.ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return scaledY;

                case ScaleModeEnum.ViewPort:
                    float yInPixels = (scaledY - diagram.ScaledY) / diagram.ScaledHeight * diagram.HeightInPixels;
                    return yInPixels;

                default:
                    throw new ValueNotSupportedException(diagram.ScaleModeEnum);
            }
        }

        public static float PixelsToWidth(Diagram diagram, float widthInPixels)
        {
            if (diagram == null) throw new NullException(() => diagram);

            switch (diagram.ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return widthInPixels;

                case ScaleModeEnum.ViewPort:
                    float result = widthInPixels / diagram.WidthInPixels * diagram.ScaledWidth;
                    return result;

                default:
                    throw new ValueNotSupportedException(diagram.ScaleModeEnum);
            }
        }

        public static float PixelsToHeight(Diagram diagram, float heightInPixels)
        {
            if (diagram == null) throw new NullException(() => diagram);

            switch (diagram.ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return heightInPixels;

                case ScaleModeEnum.ViewPort:
                    float result = heightInPixels / diagram.HeightInPixels * diagram.ScaledHeight;
                    return result;

                default:
                    throw new ValueNotSupportedException(diagram.ScaleModeEnum);
            }
        }

        public static float WidthToPixels(Diagram diagram, float scaledWidth)
        {
            if (diagram == null) throw new NullException(() => diagram);

            switch (diagram.ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return scaledWidth;

                case ScaleModeEnum.ViewPort:
                    float result = scaledWidth / diagram.ScaledWidth * diagram.WidthInPixels;
                    return result;

                default:
                    throw new ValueNotSupportedException(diagram.ScaleModeEnum);
            }
        }

        public static float HeightToPixels(Diagram diagram, float scaledHeight)
        {
            if (diagram == null) throw new NullException(() => diagram);

            switch (diagram.ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return scaledHeight;

                case ScaleModeEnum.ViewPort:
                    float result = scaledHeight / diagram.ScaledHeight * diagram.HeightInPixels;
                    return result;

                default:
                    throw new ValueNotSupportedException(diagram.ScaleModeEnum);
            }
        }

        // Element

        public static float RelativeToAbsoluteX(Element element, float relativeX)
        {
            if (element == null) throw new NullException(() => element);

            float absoluteX = relativeX;

            while (element != null)
            {
                absoluteX += element.X;
                element = element.Parent;
            }

            return absoluteX;
        }

        public static float RelativeToAbsoluteY(Element element, float relativeY)
        {
            if (element == null) throw new NullException(() => element);

            float absoluteY = relativeY;

            while (element != null)
            {
                absoluteY += element.Y;
                element = element.Parent;
            }

            return absoluteY;
        }

        public static float AbsoluteToRelativeX(Element element, float absoluteX)
        {
            if (element == null) throw new NullException(() => element);

            float relativeX = absoluteX;

            while (element != null)
            {
                relativeX -= element.X;
                element = element.Parent;
            }

            return relativeX;
        }

        public static float AbsoluteToRelativeY(Element element, float absoluteY)
        {
            if (element == null) throw new NullException(() => element);

            float relativeY = absoluteY;

            while (element != null)
            {
                relativeY -= element.Y;
                element = element.Parent;
            }

            return relativeY;
        }

        // To and from pixels is derived from the conversions between relative and absolute,
        // and the diagram's conversions between pixels and scaled.

        public static float PixelsToRelativeX(Element element, float xInPixels)
        {
            if (element == null) throw new NullException(() => element);

            float value = ScaleHelper.PixelsToX(element.Diagram, xInPixels);
            value = ScaleHelper.AbsoluteToRelativeX(element, value);
            return value;
        }

        public static float PixelsToRelativeY(Element element, float yInPixels)
        {
            if (element == null) throw new NullException(() => element);

            float value = ScaleHelper.PixelsToY(element.Diagram, yInPixels);
            value = ScaleHelper.AbsoluteToRelativeY(element, value);
            return value;
        }

        public static float RelativeToPixelsX(Element element, float relativeX)
        {
            if (element == null) throw new NullException(() => element);

            float value = ScaleHelper.RelativeToAbsoluteX(element, relativeX);
            value = ScaleHelper.XToPixels(element.Diagram, value);
            return value;
        }

        public static float RelativeToPixelsY(Element element, float relativeY)
        {
            if (element == null) throw new NullException(() => element);

            float value = ScaleHelper.RelativeToAbsoluteY(element, relativeY);
            value = ScaleHelper.YToPixels(element.Diagram, value);
            return value;
        }

        public static float PixelsToAbsoluteX(Element element, float xInPixels)
        {
            if (element == null) throw new NullException(() => element);

            // Just delegates to the Diagram method. These methods are here for syntactic sugar.
            float value = ScaleHelper.PixelsToX(element.Diagram, xInPixels);
            return value;
        }

        public static float PixelsToAbsoluteY(Element element, float yInPixels)
        {
            if (element == null) throw new NullException(() => element);

            // Just delegates to the Diagram method. These methods are here for syntactic sugar.
            float value = ScaleHelper.PixelsToY(element.Diagram, yInPixels);
            return value;
        }

        public static float AbsoluteToPixelsX(Element element, float absoluteX)
        {
            if (element == null) throw new NullException(() => element);

            // Just delegates to the Diagram method. These methods are here for syntactic sugar.
            float value = ScaleHelper.XToPixels(element.Diagram, absoluteX);
            return value;
        }

        public static float AbsoluteToPixelsY(Element element, float absoluteY)
        {
            if (element == null) throw new NullException(() => element);

            // Just delegates to the Diagram method. These methods are here for syntactic sugar.
            float value = ScaleHelper.YToPixels(element.Diagram, absoluteY);
            return value;
        }

    }
}
