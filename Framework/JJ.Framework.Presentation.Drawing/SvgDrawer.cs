using JJ.Framework.Presentation.Svg.Visitors;
using JJ.Framework.Presentation.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SvgElements = JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection;
using JJ.Framework.Presentation.Svg.Models.Styling;
using JJ.Framework.Presentation.Svg;

namespace JJ.Framework.Presentation.Drawing
{
    public static class SvgDrawer
    {
        public static void Draw(Diagram svgManager, Graphics destGraphics)
        {
            if (svgManager == null) throw new NullException(() => svgManager);
            if (destGraphics == null) throw new NullException(() => destGraphics);

            foreach (SvgElements.Element element in svgManager.EnumerateElementsByZIndex())
            {
                DrawPolymorphic(element, destGraphics);
            }
        }

        private static void DrawPolymorphic(SvgElements.Element sourceElement, Graphics destGraphics)
        {
            var sourcePoint = sourceElement as SvgElements.Point;
            if (sourcePoint != null)
            {
                DrawPoint(sourcePoint, destGraphics);
                return;
            }

            var sourceLine = sourceElement as SvgElements.Line;
            if (sourceLine != null)
            {
                DrawLine(sourceLine, destGraphics);
                return;
            }

            var sourceRectangle = sourceElement as SvgElements.Rectangle;
            if (sourceRectangle != null)
            {
                DrawRectangle(sourceRectangle, destGraphics);
                return;
            }

            var sourceLabel = sourceElement as SvgElements.Label;
            if (sourceLabel != null)
            {
                DrawLabel(sourceLabel, destGraphics);
                return;
            }

            throw new Exception(String.Format("Unexpected Element type '{0}'", sourceElement.GetType().FullName));
        }

        private static void DrawBackground(SvgElements.Rectangle sourceRectangle, Graphics destGraphics)
        {
            if (sourceRectangle.Visible && sourceRectangle.BackStyle.Visible)
            {
                Color destBackColor = sourceRectangle.BackStyle.Color.ToSystemDrawing();
                destGraphics.Clear(destBackColor);
            }
        }

        private static void DrawPoint(SvgElements.Point sourcePoint, Graphics destGraphics)
        {
            if (sourcePoint.Visible && sourcePoint.PointStyle.Visible)
            {
                RectangleF destRectangle = sourcePoint.ToSystemDrawingRectangleF();
                Brush destBrush = sourcePoint.PointStyle.ToSystemDrawingBrush();

                destGraphics.FillEllipse(destBrush, destRectangle);
            }
        }

        private static void DrawLine(SvgElements.Line sourceLine, Graphics destGraphics)
        {
            if (sourceLine.Visible && sourceLine.LineStyle.Visible)
            {
                Pen destPen = sourceLine.LineStyle.ToSystemDrawing();
                destGraphics.DrawLine(destPen, sourceLine.PointA.CalculatedX, sourceLine.PointA.CalculatedY, sourceLine.PointB.CalculatedX, sourceLine.PointB.CalculatedY);
            }
        }

        private static void DrawRectangle(SvgElements.Rectangle sourceRectangle, Graphics destGraphics)
        {
            if (!sourceRectangle.Visible)
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
            LineStyle lineStyle = sourceRectangle.TryGetLineStyle();
            if (lineStyle != null)
            {
                if (lineStyle.Visible)
                {
                    Pen destPen = lineStyle.ToSystemDrawing();
                    destGraphics.DrawRectangle(
                        destPen,
                        sourceRectangle.CalculatedX,
                        sourceRectangle.CalculatedY,
                        sourceRectangle.Width,
                        sourceRectangle.Height);
                }
            }
            else
            {
                // Draw 4 Border Lines (with different styles)

                // TODO: Consider giving Rectangle some instance helper methods for this and name X and Y differently.
                float right = sourceRectangle.CalculatedX + sourceRectangle.Width;
                float bottom = sourceRectangle.CalculatedY + sourceRectangle.Height;

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

        private static void DrawLabel(SvgElements.Label sourceLabel, Graphics destGraphics)
        {
            if (!sourceLabel.Visible)
            {
                return;
            }

            StringFormat destStringFormat = sourceLabel.TextStyle.ToSystemDrawingStringFormat();
            System.Drawing.Font destFont = sourceLabel.TextStyle.Font.ToSystemDrawing();
            RectangleF destRectangle = new RectangleF(sourceLabel.CalculatedX, sourceLabel.CalculatedY, sourceLabel.Width, sourceLabel.Height);
            Brush destBrush = sourceLabel.TextStyle.ToSystemDrawingBrush();

            destGraphics.DrawString(sourceLabel.Text, destFont, destBrush, destRectangle, destStringFormat);
        }
    }
}
