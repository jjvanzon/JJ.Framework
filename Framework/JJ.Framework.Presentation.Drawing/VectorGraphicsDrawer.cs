using System;
using System.Drawing;
using VectorGraphicsElements = JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Reflection.Exceptions;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;

namespace JJ.Framework.Presentation.Drawing
{
    public static class VectorGraphicsDrawer
    {
        public static void Draw(Diagram diagram, Graphics destGraphics)
        {
            if (diagram == null) throw new NullException(() => diagram);
            if (destGraphics == null) throw new NullException(() => destGraphics);

            foreach (Element element in diagram.EnumerateElementsByZIndex())
            {
                DrawPolymorphic(element, destGraphics);
            }
        }

        private static void DrawPolymorphic(Element sourceElement, Graphics destGraphics)
        {
            var sourcePoint = sourceElement as VectorGraphicsElements.Point;
            if (sourcePoint != null)
            {
                DrawPoint(sourcePoint, destGraphics);
                return;
            }

            var sourceLine = sourceElement as Line;
            if (sourceLine != null)
            {
                DrawLine(sourceLine, destGraphics);
                return;
            }

            var sourceRectangle = sourceElement as VectorGraphicsElements.Rectangle;
            if (sourceRectangle != null)
            {
                DrawRectangle(sourceRectangle, destGraphics);
                return;
            }

            var sourceLabel = sourceElement as Label;
            if (sourceLabel != null)
            {
                DrawLabel(sourceLabel, destGraphics);
                return;
            }

            var sourceCurve = sourceElement as Curve;
            if (sourceCurve != null)
            {
                DrawCurve(sourceCurve, destGraphics);
                return;
            }

            throw new UnexpectedTypeException(() => sourceElement);
        }

        // TODO:
        // Warning CA1811	'VectorGraphicsDrawer.DrawBackground(Rectangle, Graphics)' appears to have no upstream public or protected callers.
        private static void DrawBackground(VectorGraphicsElements.Rectangle sourceRectangle, Graphics destGraphics)
        {
            if (sourceRectangle.CalculatedValues.Visible && sourceRectangle.Style.BackStyle.Visible)
            {
                Color destBackColor = sourceRectangle.Style.BackStyle.Color.ToSystemDrawing();
                destGraphics.Clear(destBackColor);
            }
        }

        private static void DrawPoint(VectorGraphicsElements.Point sourcePoint, Graphics destGraphics)
        {
            if (sourcePoint.CalculatedValues.Visible && sourcePoint.PointStyle.Visible)
            {
                RectangleF destRectangle = sourcePoint.ToSystemDrawingRectangleF();
                using (Brush destBrush = sourcePoint.PointStyle.ToSystemDrawingBrush())
                {
                    destGraphics.FillEllipse(destBrush, destRectangle);
                }
            }
        }

        private static void DrawLine(Line sourceLine, Graphics destGraphics)
        {
            if (sourceLine.CalculatedValues.Visible && sourceLine.LineStyle.Visible)
            {
                if (sourceLine.PointA == null) throw new NullException(() => sourceLine.PointA);
                if (sourceLine.PointB == null) throw new NullException(() => sourceLine.PointB);

                float x1 = BoundsHelper.CorrectCoordinate(sourceLine.PointA.CalculatedValues.XInPixels);
                float y1 = BoundsHelper.CorrectCoordinate(sourceLine.PointA.CalculatedValues.YInPixels);
                float x2 = BoundsHelper.CorrectCoordinate(sourceLine.PointB.CalculatedValues.XInPixels);
                float y2 = BoundsHelper.CorrectCoordinate(sourceLine.PointB.CalculatedValues.YInPixels);

                using (Pen destPen = sourceLine.LineStyle.ToSystemDrawing())
                {
                    destGraphics.DrawLine(destPen, x1, y1, x2, y2);
                }
            }
        }

        private static void DrawRectangle(VectorGraphicsElements.Rectangle sourceRectangle, Graphics destGraphics)
        {
            if (!sourceRectangle.CalculatedValues.Visible)
            {
                return;
            }

            // Draw Back
            if (sourceRectangle.Style.BackStyle.Visible)
            {
                RectangleF destRectangle = sourceRectangle.ToSystemDrawingRectangleF();

                using (Brush destBrush = sourceRectangle.Style.BackStyle.ToSystemDrawing())
                {
                    destGraphics.FillRectangle(destBrush, destRectangle);
                }
            }

            // Draw Rectangle
            float left = BoundsHelper.CorrectCoordinate(sourceRectangle.CalculatedValues.XInPixels);
            float top = BoundsHelper.CorrectCoordinate(sourceRectangle.CalculatedValues.YInPixels);
            float width = BoundsHelper.CorrectLength(sourceRectangle.CalculatedValues.WidthInPixels);
            float height = BoundsHelper.CorrectLength(sourceRectangle.CalculatedValues.HeightInPixels);

            LineStyle lineStyle = sourceRectangle.Style.LineStyle;
            if (lineStyle != null)
            {
                if (lineStyle.Visible)
                {
                    using (Pen destPen = lineStyle.ToSystemDrawing())
                    {
                        destGraphics.DrawRectangle(destPen, left, top, width, height);
                    }
                }
            }
            else
            {
                // Draw 4 Border Lines (with different styles)

                // TODO: You would think that bounds check is unnecessary here.
                float right = left + width;
                float bottom = top + height;

                var destTopLeftPointF = new PointF(left, top);
                var destTopRightPointF = new PointF(right, top);
                var destBottomRightPointF = new PointF(right, bottom);
                var destBottomLeftPointF = new PointF(left, bottom);

                using (Pen destTopPen = sourceRectangle.Style.TopLineStyle.ToSystemDrawing())
                {
                    destGraphics.DrawLine(destTopPen, destTopLeftPointF, destTopRightPointF);
                }

                using (Pen destRightPen = sourceRectangle.Style.RightLineStyle.ToSystemDrawing())
                {
                    destGraphics.DrawLine(destRightPen, destTopRightPointF, destBottomRightPointF);
                }

                using (Pen destBottomPen = sourceRectangle.Style.BottomLineStyle.ToSystemDrawing())
                {
                    destGraphics.DrawLine(destBottomPen, destBottomRightPointF, destBottomLeftPointF);
                }

                using (Pen destLeftPen = sourceRectangle.Style.LeftLineStyle.ToSystemDrawing())
                {
                    destGraphics.DrawLine(destLeftPen, destBottomLeftPointF, destTopLeftPointF);
                }
            }
        }

        private static void DrawLabel(Label sourceLabel, Graphics destGraphics)
        {
            if (!sourceLabel.CalculatedValues.Visible)
            {
                return;
            }

            float x = BoundsHelper.CorrectCoordinate(sourceLabel.CalculatedValues.XInPixels);
            float y = BoundsHelper.CorrectCoordinate(sourceLabel.CalculatedValues.YInPixels);

            // Calling CorrectCoordinate instead of CorrectLength,
            // because apparently System.Drawing hates it when I correct 0 to 1E-9f.
            float width = BoundsHelper.CorrectCoordinate(sourceLabel.CalculatedValues.WidthInPixels);
            float height = BoundsHelper.CorrectCoordinate(sourceLabel.CalculatedValues.HeightInPixels);

            var destRectangle = new RectangleF(x, y, width, height);

            using (System.Drawing.Font destFont = sourceLabel.TextStyle.Font.ToSystemDrawing(destGraphics.DpiX))
            {
                using (Brush destBrush = sourceLabel.TextStyle.ToSystemDrawingBrush())
                {
                    using (StringFormat destStringFormat = sourceLabel.TextStyle.ToSystemDrawingStringFormat())
                    {
                        destGraphics.DrawString(sourceLabel.Text, destFont, destBrush, destRectangle, destStringFormat);
                    }
                }
            }
        }

        private static void DrawCurve(Curve sourceCurve, Graphics destGraphics)
        {
            foreach (Line calculatedLine in sourceCurve.CalculatedLines)
            {
                DrawLine(calculatedLine, destGraphics);
            }
        }
    }
}
