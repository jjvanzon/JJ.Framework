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
            if (sourceRectangle.CalculatedVisible && sourceRectangle.BackStyle.Visible)
            {
                Color destBackColor = sourceRectangle.BackStyle.Color.ToSystemDrawing();
                destGraphics.Clear(destBackColor);
            }
        }

        private static void DrawPoint(VectorGraphicsElements.Point sourcePoint, Graphics destGraphics)
        {
            if (sourcePoint.CalculatedVisible && sourcePoint.PointStyle.Visible)
            {
                RectangleF destRectangle = sourcePoint.ToSystemDrawingRectangleF();
                Brush destBrush = sourcePoint.PointStyle.ToSystemDrawingBrush();

                destGraphics.FillEllipse(destBrush, destRectangle);
            }
        }

        private static void DrawLine(Line sourceLine, Graphics destGraphics)
        {
            if (sourceLine.CalculatedVisible && sourceLine.LineStyle.Visible)
            {
                Pen destPen = sourceLine.LineStyle.ToSystemDrawing();
                destGraphics.DrawLine(destPen, sourceLine.PointA.CalculatedX, sourceLine.PointA.CalculatedY, sourceLine.PointB.CalculatedX, sourceLine.PointB.CalculatedY);
            }
        }

        private static void DrawRectangle(VectorGraphicsElements.Rectangle sourceRectangle, Graphics destGraphics)
        {
            if (!sourceRectangle.CalculatedVisible)
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
                        sourceRectangle.CalculatedX,
                        sourceRectangle.CalculatedY,
                        sourceRectangle.CalculatedWidth,
                        sourceRectangle.CalculatedHeight);
                }
            }
            else
            {
                // Draw 4 Border Lines (with different styles)

                float right = sourceRectangle.CalculatedX + sourceRectangle.CalculatedWidth;
                float bottom = sourceRectangle.CalculatedY + sourceRectangle.CalculatedHeight;

                PointF destTopLeftPointF = new PointF(sourceRectangle.CalculatedX, sourceRectangle.CalculatedY);
                PointF destTopRightPointF = new PointF(right, sourceRectangle.CalculatedY);
                PointF destBottomRightPointF = new PointF(right, bottom);
                PointF destBottomLeftPointF = new PointF(sourceRectangle.CalculatedX, bottom);
                
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
            if (!sourceLabel.CalculatedVisible)
            {
                return;
            }

            StringFormat destStringFormat = sourceLabel.TextStyle.ToSystemDrawingStringFormat();
            System.Drawing.Font destFont = sourceLabel.TextStyle.Font.ToSystemDrawing();
            RectangleF destRectangle = new RectangleF(sourceLabel.CalculatedX, sourceLabel.CalculatedY, sourceLabel.CalculatedWidth, sourceLabel.CalculatedHeight);
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
