﻿using JJ.Framework.Common;
using JJ.Framework.Presentation.VectorGraphics.Enums;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Presentation.WinForms.TestForms.Helpers;
using JJ.Framework.Reflection.Exceptions;
using System.Drawing;
using System.Drawing.Drawing2D;
using VectorGraphicsElements = JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using VectorGraphicsStyling = JJ.Framework.Presentation.VectorGraphics.Models.Styling;

namespace JJ.Framework.Presentation.WinForms.TestForms.VectorGraphicsWithoutCloning
{
    internal static class ConvertExtensions_WithoutCloning
    {
        // Point

        //public static PointF ToSystemDrawingPointF(this VectorGraphicsElements.Point sourcePoint)
        //{
        //    if (sourcePoint == null) throw new NullException(() => sourcePoint);

        //    var destPointF = new PointF(sourcePoint.X, sourcePoint.Y);
        //    return destPointF;
        //}

        //public static System.Drawing.Point ToSystemDrawingPoint(this VectorGraphicsElements.Point sourcePoint)
        //{
        //    if (sourcePoint == null) throw new NullException(() => sourcePoint);

        //    var destPoint = new System.Drawing.Point((int)sourcePoint.X, (int)sourcePoint.Y);
        //    return destPoint;
        //}

        public static RectangleF ToSystemDrawingRectangleF(this VectorGraphicsElements.Point sourcePoint)
        {
            var sourcePoint_Accessor = new Element_Accessor(sourcePoint);

            float pointWidth = sourcePoint.PointStyle.Width;
            var destRectangleF = new RectangleF(
                x: sourcePoint_Accessor.CalculatedX - pointWidth / 2,
                y: sourcePoint_Accessor.CalculatedY - pointWidth / 2,
                width: pointWidth,
                height: pointWidth);

            return destRectangleF;
        }

        // Rectangle

        public static RectangleF ToSystemDrawingRectangleF(this VectorGraphicsElements.Rectangle sourceRectangle)
        {
            if (sourceRectangle == null) throw new NullException(() => sourceRectangle);

            var sourceRectangle_Accessor = new Element_Accessor(sourceRectangle);

            var destRectangleF = new RectangleF(
                sourceRectangle_Accessor.CalculatedX,
                sourceRectangle_Accessor.CalculatedY,
                sourceRectangle.Width,
                sourceRectangle.Height);

            return destRectangleF;
        }

        //public static System.Drawing.Rectangle ToSystemDrawingRectangle(this VectorGraphicsElements.Rectangle sourceRectangle)
        //{
        //    if (sourceRectangle == null) throw new NullException(() => sourceRectangle);

        //    var sourceRectangle_Accessor = new Element_Accessor(sourceRectangle);

        //    var destRectangle = new System.Drawing.Rectangle(
        //        (int)sourceRectangle_Accessor.CalculatedX,
        //        (int)sourceRectangle_Accessor.CalculatedY,
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
