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

namespace JJ.Framework.Presentation.Drawing
{
    public static class SvgDrawer
    {
        public static void Draw(SvgElements.Container sourceContainer, Graphics destGraphics)
        {
            if (sourceContainer == null) throw new NullException(() => sourceContainer);
            if (destGraphics == null) throw new NullException(() => destGraphics);

            var visitor = new ToAbsoluteVisitor();
            var destContainer = visitor.Execute(sourceContainer);

            DrawBackground(sourceContainer, destGraphics);

            foreach (SvgElements.Point sourcePoint in destContainer.ChildPoints)
            {
                DrawPoint(sourcePoint, destGraphics);
            }

            foreach (SvgElements.Line sourceLine in destContainer.ChildLines)
            {
                DrawLine(sourceLine, destGraphics);
            }

            foreach (SvgElements.Rectangle sourceRectangle in destContainer.ChildRectangles)
            {
                DrawRectangle(sourceRectangle, destGraphics);
            }

            foreach (SvgElements.Label sourceLabel in destContainer.ChildLabels)
            {
                DrawLabel(sourceLabel, destGraphics);
            }
        }

        private static void DrawBackground(SvgElements.Container sourceContainer, Graphics destGraphics)
        {
            if (sourceContainer.Visible &&
                sourceContainer.BackStyle.Visible)
            {
                Color destBackColor = sourceContainer.BackStyle.Color.ToSystemDrawing();
                destGraphics.Clear(destBackColor);
            }
        }

        private static void DrawPoint(SvgElements.Point sourcePoint, Graphics destGraphics)
        {
            if (sourcePoint.Visible &&
                sourcePoint.PointStyle.Visible)
            {
                RectangleF destRectangle = sourcePoint.ToSystemDrawingRectangleF();
                Brush destBrush = sourcePoint.PointStyle.ToSystemDrawingBrush();

                destGraphics.FillEllipse(destBrush, destRectangle);
            }
        }

        private static void DrawLine(SvgElements.Line sourceLine, Graphics destGraphics)
        {
            if (sourceLine.Visible &&
                sourceLine.LineStyle.Visible)
            {
                Pen destPen = sourceLine.LineStyle.ToSystemDrawing();
                destGraphics.DrawLine(destPen, sourceLine.PointA.X, sourceLine.PointA.Y, sourceLine.PointB.X, sourceLine.PointB.Y);
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
                        sourceRectangle.X,
                        sourceRectangle.Y,
                        sourceRectangle.Width,
                        sourceRectangle.Height);
                }
            }
            else
            {
                // Draw 4 Border Lines (with different styles)

                // TODO: Consider giving Rectangle some instance helper methods for this and name X and Y differently.
                float right = sourceRectangle.X + sourceRectangle.Width;
                float bottom = sourceRectangle.Y + sourceRectangle.Height;

                PointF destTopLeftPointF = new PointF(sourceRectangle.X, sourceRectangle.Y);
                PointF destTopRightPointF = new PointF(right, sourceRectangle.Y);
                PointF destBottomRightPointF = new PointF(right, bottom);
                PointF destBottomLeftPointF = new PointF(sourceRectangle.X, bottom);
                
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
            RectangleF destRectangle = new RectangleF(sourceLabel.Rectangle.X, sourceLabel.Rectangle.Y, sourceLabel.Rectangle.Width, sourceLabel.Rectangle.Height);
            Brush destBrush = sourceLabel.TextStyle.ToSystemDrawingBrush();

            destGraphics.DrawString(sourceLabel.Text, destFont, destBrush, destRectangle, destStringFormat);
        }
    }
}
