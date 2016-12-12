using JJ.Framework.Common;
using JJ.Framework.Presentation.VectorGraphics.Enums;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Exceptions;
using System.Drawing;
using System.Drawing.Drawing2D;
using VectorGraphicsElements = JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using VectorGraphicsStyling = JJ.Framework.Presentation.VectorGraphics.Models.Styling;

namespace JJ.Framework.Presentation.WinForms.TestForms.VectorGraphicsWithFlatClone
{
    internal static class ConvertExtensions
    {
        // Point

        public static RectangleF ToSystemDrawingRectangleF(this VectorGraphicsElements.Point sourcePoint)
        {
            float pointWidth = sourcePoint.PointStyle.Width;
            var destRectangleF = new RectangleF(
                x: sourcePoint.Position.X - pointWidth / 2,
                y: sourcePoint.Position.Y - pointWidth / 2,
                width: pointWidth,
                height: pointWidth);

            return destRectangleF;
        }

        // Rectangle

        public static RectangleF ToSystemDrawingRectangleF(this VectorGraphicsElements.Rectangle sourceRectangle)
        {
            if (sourceRectangle == null) throw new NullException(() => sourceRectangle);

            var destRectangleF = new RectangleF(
                sourceRectangle.Position.X,
                sourceRectangle.Position.Y,
                sourceRectangle.Position.Width,
                sourceRectangle.Position.Height);

            return destRectangleF;
        }

        //public static System.Drawing.Rectangle ToSystemDrawingRectangle(this VectorGraphicsElements.Rectangle sourceRectangle)
        //{
        //    if (sourceRectangle == null) throw new NullException(() => sourceRectangle);

        //    var destRectangle = new System.Drawing.Rectangle(
        //        (int)sourceRectangle.X,
        //        (int)sourceRectangle.Y,
        //        (int)sourceRectangle.Width,
        //        (int)sourceRectangle.Height);

        //    return destRectangle;
        //}

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

        public static System.Drawing.Font ToSystemDrawing(this VectorGraphicsStyling.Font sourceFont)
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
