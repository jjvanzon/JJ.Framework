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

            throw new Exception(String.Format("Unexpected Element type '{0}'", sourceElement.GetType().FullName));
        }

        // TODO:
        // Warning CA1811	'VectorGraphicsDrawer.DrawBackground(Rectangle, Graphics)' appears to have no upstream public or protected callers.
        private static void DrawBackground(VectorGraphicsElements.Rectangle sourceRectangle, Graphics destGraphics)
        {
            ICalculatedValues calculatedValues = sourceRectangle;

            if (calculatedValues.CalculatedVisible && sourceRectangle.BackStyle.Visible)
            {
                Color destBackColor = sourceRectangle.BackStyle.Color.ToSystemDrawing();
                destGraphics.Clear(destBackColor);
            }
        }

        private static void DrawPoint(VectorGraphicsElements.Point sourcePoint, Graphics destGraphics)
        {
            ICalculatedValues calculatedValues = sourcePoint;

            if (calculatedValues.CalculatedVisible && sourcePoint.PointStyle.Visible)
            {
                RectangleF destRectangle = sourcePoint.ToSystemDrawingRectangleF();
                Brush destBrush = sourcePoint.PointStyle.ToSystemDrawingBrush();

                destGraphics.FillEllipse(destBrush, destRectangle);
            }
        }

        private static void DrawLine(Line sourceLine, Graphics destGraphics)
        {
            ICalculatedValues sourceLine_CalculatedValues = sourceLine;

            if (sourceLine_CalculatedValues.CalculatedVisible && sourceLine.LineStyle.Visible)
            {
                ICalculatedValues pointA_CalculatedValues = sourceLine.PointA;
                ICalculatedValues pointB_CalculatedValues = sourceLine.PointB;

                Pen destPen = sourceLine.LineStyle.ToSystemDrawing();
                destGraphics.DrawLine(
                    destPen, 
                    pointA_CalculatedValues.CalculatedXInPixels, pointA_CalculatedValues.CalculatedYInPixels,
                    pointB_CalculatedValues.CalculatedXInPixels, pointB_CalculatedValues.CalculatedYInPixels);
            }
        }

        private static void DrawRectangle(VectorGraphicsElements.Rectangle sourceRectangle, Graphics destGraphics)
        {
            ICalculatedValues calculatedValues = sourceRectangle;

            if (!calculatedValues.CalculatedVisible)
            {
                return;
            }

            // Draw Back
            if (sourceRectangle.BackStyle.Visible)
            {
                Brush destBrush = sourceRectangle.BackStyle.ToSystemDrawing();
                RectangleF destRectangle = sourceRectangle.ToSystemDrawingRectangleF();

                destGraphics.FillRectangle(destBrush, destRectangle);
            }

            // Draw Rectangle
            LineStyle lineStyle = sourceRectangle.LineStyle;
            if (lineStyle != null)
            {
                if (lineStyle.Visible)
                {
                    Pen destPen = lineStyle.ToSystemDrawing();
                    destGraphics.DrawRectangle(
                        destPen,
                        calculatedValues.CalculatedXInPixels,
                        calculatedValues.CalculatedYInPixels,
                        calculatedValues.CalculatedWidthInPixels,
                        calculatedValues.CalculatedHeightInPixels);
                }
            }
            else
            {
                // Draw 4 Border Lines (with different styles)

                float right = calculatedValues.CalculatedXInPixels + calculatedValues.CalculatedWidthInPixels;
                float bottom = calculatedValues.CalculatedYInPixels + calculatedValues.CalculatedHeightInPixels;

                PointF destTopLeftPointF = new PointF(calculatedValues.CalculatedXInPixels, calculatedValues.CalculatedYInPixels);
                PointF destTopRightPointF = new PointF(right, calculatedValues.CalculatedYInPixels);
                PointF destBottomRightPointF = new PointF(right, bottom);
                PointF destBottomLeftPointF = new PointF(calculatedValues.CalculatedXInPixels, bottom);
                
                Pen destTopPen = sourceRectangle.TopLineStyle.ToSystemDrawing();
                destGraphics.DrawLine(destTopPen, destTopLeftPointF, destTopRightPointF);

                Pen destRightPen = sourceRectangle.RightLineStyle.ToSystemDrawing();
                destGraphics.DrawLine(destRightPen, destTopRightPointF, destBottomRightPointF);

                Pen destBottomPen = sourceRectangle.BottomLineStyle.ToSystemDrawing();
                destGraphics.DrawLine(destBottomPen, destBottomRightPointF, destBottomLeftPointF);

                Pen destLeftPen = sourceRectangle.LeftLineStyle.ToSystemDrawing();
                destGraphics.DrawLine(destLeftPen, destBottomLeftPointF, destTopLeftPointF);
            }
        }

        private static void DrawLabel(Label sourceLabel, Graphics destGraphics)
        {
            ICalculatedValues calculatedValues = sourceLabel;

            if (!calculatedValues.CalculatedVisible)
            {
                return;
            }

            StringFormat destStringFormat = sourceLabel.TextStyle.ToSystemDrawingStringFormat();
            System.Drawing.Font destFont = sourceLabel.TextStyle.Font.ToSystemDrawing(destGraphics.DpiX);
            RectangleF destRectangle = new RectangleF(calculatedValues.CalculatedXInPixels, calculatedValues.CalculatedYInPixels, calculatedValues.CalculatedWidthInPixels, calculatedValues.CalculatedHeightInPixels);
            Brush destBrush = sourceLabel.TextStyle.ToSystemDrawingBrush();

            destGraphics.DrawString(sourceLabel.Text, destFont, destBrush, destRectangle, destStringFormat);
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
