using JJ.Framework.Common;
using JJ.Framework.Presentation.Svg.Enums;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Presentation.Svg.Models.Styling;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SvgElements = JJ.Framework.Presentation.Svg.Models.Elements;
using SvgStyling = JJ.Framework.Presentation.Svg.Models.Styling;

namespace JJ.Framework.Presentation.Drawing
{
    public static class ConvertExtensions
    {
        // Point

        public static PointF ToSystemDrawingPointF(this SvgElements.Point sourcePoint)
        {
            if (sourcePoint == null) throw new NullException(() => sourcePoint);

            var destPointF = new PointF(sourcePoint.X, sourcePoint.Y);
            return destPointF;
        }

        public static System.Drawing.Point ToSystemDrawingPoint(this SvgElements.Point sourcePoint)
        {
            if (sourcePoint == null) throw new NullException(() => sourcePoint);

            var destPoint = new System.Drawing.Point((int)sourcePoint.X, (int)sourcePoint.Y);
            return destPoint;
        }

        public static RectangleF ToSystemDrawingRectangleF(this SvgElements.Point sourcePoint)
        {
            float pointWidth = sourcePoint.PointStyle.Width;
            var destRectangleF = new RectangleF(
                x: sourcePoint.X - pointWidth / 2,
                y: sourcePoint.Y - pointWidth / 2,
                width: pointWidth,
                height: pointWidth);

            return destRectangleF;
        }

        // Rectangle

        public static RectangleF ToSystemDrawingRectangleF(this SvgElements.Rectangle sourceRectangle)
        {
            if (sourceRectangle == null) throw new NullException(() => sourceRectangle);

            var destRectangleF = new RectangleF(
                sourceRectangle.X,
                sourceRectangle.Y,
                sourceRectangle.Width,
                sourceRectangle.Height);

            return destRectangleF;
        }

        public static System.Drawing.Rectangle ToSystemDrawingRectangle(this SvgElements.Rectangle sourceRectangle)
        {
            if (sourceRectangle == null) throw new NullException(() => sourceRectangle);

            var destRectangle = new System.Drawing.Rectangle(
                (int)sourceRectangle.X,
                (int)sourceRectangle.Y,
                (int)sourceRectangle.Width,
                (int)sourceRectangle.Height);

            return destRectangle;
        }

        // Style Values

        public static Color ToSystemDrawing(this int color)
        {
            return Color.FromArgb(color);
        }

        public static StringAlignment ToSystemDrawing(this HorizontalAlignmentEnum horizontalAlignmentEnum)
        {
            switch (horizontalAlignmentEnum)
            {
                case HorizontalAlignmentEnum.Center:
                    return StringAlignment.Center;

                case HorizontalAlignmentEnum.Left:
                    return StringAlignment.Near;

                case HorizontalAlignmentEnum.Right:
                    return StringAlignment.Far;

                default:
                    throw new InvalidValueException(horizontalAlignmentEnum);
            }
        }

        public static StringAlignment ToSystemDrawing(this VerticalAlignmentEnum verticalAlignmentEnum)
        {
            switch (verticalAlignmentEnum)
            {
                case VerticalAlignmentEnum.Center:
                    return StringAlignment.Center;

                case VerticalAlignmentEnum.Top:
                    return StringAlignment.Near;

                case VerticalAlignmentEnum.Bottom:
                    return StringAlignment.Far;

                default:
                    throw new InvalidValueException(verticalAlignmentEnum);
            }
        }

        // Style Objects

        /// <summary>
        /// TODO: Is this method even used? 
        /// </summary>
        public static Pen ToSystemDrawingPen(this PointStyle sourcePointStyle)
        {
            if (sourcePointStyle == null) throw new NullException(() => sourcePointStyle);

            Color destColor = sourcePointStyle.Color.ToSystemDrawing();
            var destPen = new Pen(destColor, sourcePointStyle.Width);
            return destPen;
        }

        public static Brush ToSystemDrawingBrush(this PointStyle sourcePointStyle)
        {
            if (sourcePointStyle == null) throw new NullException(() => sourcePointStyle);

            Color destColor = sourcePointStyle.Color.ToSystemDrawing();
            var destBrush = new SolidBrush(destColor);
            return destBrush;
        }

        public static Pen ToSystemDrawing(this LineStyle sourceLineStyle)
        {
            if (sourceLineStyle == null) throw new NullException(() => sourceLineStyle);

            Color destColor = sourceLineStyle.Color.ToSystemDrawing();
            Pen destPen = new Pen(destColor, sourceLineStyle.Width);

            switch (sourceLineStyle.DashStyleEnum)
            {
                case DashStyleEnum.Dotted:
                    destPen.DashStyle = DashStyle.Dot;
                    destPen.DashPattern = new float[] { 1, 1.5f };
                    break;

                case DashStyleEnum.Dashed:
                    destPen.DashStyle = DashStyle.Dash;
                    destPen.DashPattern = new float[] { 3, 1 };
                    break;

                case DashStyleEnum.Solid:
                    destPen.DashStyle = DashStyle.Solid;
                    break;

                default:
                    throw new InvalidValueException(sourceLineStyle.DashStyleEnum);
            }

            return destPen;
        }

        public static Brush ToSystemDrawing(this BackStyle sourceBackStyle)
        {
            if (sourceBackStyle == null) throw new NullException(() => sourceBackStyle);

            Color destColor = sourceBackStyle.Color.ToSystemDrawing();
            Brush destBrush = new SolidBrush(destColor);
            return destBrush;
        }

        public static StringFormat ToSystemDrawingStringFormat(this TextStyle sourceTextStyle)
        {
            if (sourceTextStyle == null) throw new NullException(() => sourceTextStyle);

            var destStringFormat = new StringFormat();

            destStringFormat.Alignment = sourceTextStyle.HorizontalAlignmentEnum.ToSystemDrawing();
            destStringFormat.LineAlignment = sourceTextStyle.VerticalAlignmentEnum.ToSystemDrawing();

            if (sourceTextStyle.Wrap == false)
            {
                destStringFormat.FormatFlags |= StringFormatFlags.NoWrap;
            }

            if (sourceTextStyle.Abbreviate)
            {
                destStringFormat.Trimming = StringTrimming.EllipsisCharacter;
            }

            return destStringFormat;
        }

        public static Brush ToSystemDrawingBrush(this TextStyle sourceTextStyle)
        {
            if (sourceTextStyle == null) throw new NullException(() => sourceTextStyle);

            Color destColor = sourceTextStyle.Color.ToSystemDrawing();
            Brush destBrush = new SolidBrush(destColor);

            return destBrush;
        }

        public static System.Drawing.Font ToSystemDrawing(this SvgStyling.Font sourceFont)
        {
            FontStyle destFontStyle = 0;

            if (sourceFont.Bold)
            {
                destFontStyle |= FontStyle.Bold;
            }

            if (sourceFont.Italic)
            {
                destFontStyle |= FontStyle.Italic;
            }

            var destFont = new System.Drawing.Font(sourceFont.Name, sourceFont.Size, destFontStyle);
            return destFont;
        }
    }
}
