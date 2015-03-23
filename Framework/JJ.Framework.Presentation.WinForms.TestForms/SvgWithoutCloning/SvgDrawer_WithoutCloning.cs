using JJ.Framework.Presentation.Svg.Models.Styling;
using JJ.Framework.Presentation.Svg.Visitors;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SvgElements = JJ.Framework.Presentation.Svg.Models.Elements;

namespace JJ.Framework.Presentation.WinForms.TestForms.SvgWithoutCloning
{
    internal class SvgDrawer_WithoutCloning : ElementVisitorBase
    {
        private Graphics _destGraphic;

        public void Draw(SvgElements.Rectangle rootRectangle, Graphics destGraphics)
        {
            if (rootRectangle == null) throw new NullException(() => rootRectangle);
            if (destGraphics == null) throw new NullException(() => destGraphics);

            var visitor2 = new ToAbsoluteVisitor2();
            visitor2.Execute(rootRectangle);

            _destGraphic = destGraphics;

            VisitRectangle(rootRectangle);
        }

        protected override void VisitPoint(SvgElements.Point point)
        {
            DrawPoint(point, _destGraphic);

            base.VisitPoint(point);
        }

        protected override void VisitLine(SvgElements.Line line)
        {
            DrawLine(line, _destGraphic);

            base.VisitLine(line);
        }

        protected override void VisitRectangle(SvgElements.Rectangle rectangle)
        {
            DrawRectangle(rectangle, _destGraphic);

            base.VisitRectangle(rectangle);
        }

        protected override void VisitLabel(SvgElements.Label label)
        {
            DrawLabel(label, _destGraphic);

            base.VisitLabel(label);
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
                destGraphics.DrawLine(destPen, sourceLine.PointA.AbsoluteX, sourceLine.PointA.AbsoluteY, sourceLine.PointB.AbsoluteX, sourceLine.PointB.AbsoluteY);
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
                        sourceRectangle.AbsoluteX,
                        sourceRectangle.AbsoluteY,
                        sourceRectangle.Width,
                        sourceRectangle.Height);
                }
            }
            else
            {
                // Draw 4 Border Lines (with different styles)

                // TODO: Consider giving Rectangle some instance helper methods for this and name X and Y differently.
                float right = sourceRectangle.AbsoluteX + sourceRectangle.Width;
                float bottom = sourceRectangle.AbsoluteY + sourceRectangle.Height;

                PointF destTopLeftPointF = new PointF(sourceRectangle.AbsoluteX, sourceRectangle.AbsoluteY);
                PointF destTopRightPointF = new PointF(right, sourceRectangle.AbsoluteY);
                PointF destBottomRightPointF = new PointF(right, bottom);
                PointF destBottomLeftPointF = new PointF(sourceRectangle.AbsoluteX, bottom);

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
            RectangleF destRectangle = new RectangleF(sourceLabel.Rectangle.AbsoluteX, sourceLabel.Rectangle.AbsoluteY, sourceLabel.Rectangle.Width, sourceLabel.Rectangle.Height);
            Brush destBrush = sourceLabel.TextStyle.ToSystemDrawingBrush();

            destGraphics.DrawString(sourceLabel.Text, destFont, destBrush, destRectangle, destStringFormat);
        }
    }
}
