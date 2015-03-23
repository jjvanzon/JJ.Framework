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
    public class SvgDrawer
    {
        public void Draw(SvgElements.Rectangle sourceRootRectangle, Graphics destGraphics)
        {
            if (sourceRootRectangle == null) throw new NullException(() => sourceRootRectangle);
            if (destGraphics == null) throw new NullException(() => destGraphics);

            var visitor = new ToAbsoluteVisitor();
            IList<SvgElements.ElementBase> elements = visitor.Execute(sourceRootRectangle);

            foreach (SvgElements.ElementBase element in elements)
            {
                DrawPolymorphic(element, destGraphics);
            }
        }
        
        private void DrawPolymorphic(SvgElements.ElementBase sourceElement, Graphics destGraphics)
        {
            var destPoint = sourceElement as SvgElements.Point;
            if (destPoint != null)
            {
                DrawPoint(destPoint, destGraphics);
                return;
            }

            var destLine = sourceElement as SvgElements.Line;
            if (destLine != null)
            {
                DrawLine(destLine, destGraphics);
                return;
            }

            var destRectangle = sourceElement as SvgElements.Rectangle;
            if (destRectangle != null)
            {
                DrawRectangle(destRectangle, destGraphics);
                return;
            }

            var destLabel = sourceElement as SvgElements.Label;
            if (destLabel != null)
            {
                DrawLabel(destLabel, destGraphics);
                return;
            }

            throw new Exception(String.Format("Unexpected ElementBase type '{0}'", sourceElement.GetType().FullName));
        }

        private void DrawBackground(SvgElements.Rectangle sourceRectangle, Graphics destGraphics)
        {
            if (sourceRectangle.Visible &&
                sourceRectangle.BackStyle.Visible)
            {
                Color destBackColor = sourceRectangle.BackStyle.Color.ToSystemDrawing();
                destGraphics.Clear(destBackColor);
            }
        }

        private void DrawPoint(SvgElements.Point sourcePoint, Graphics destGraphics)
        {
            if (sourcePoint.Visible &&
                sourcePoint.PointStyle.Visible)
            {
                RectangleF destRectangle = sourcePoint.ToSystemDrawingRectangleF();
                Brush destBrush = sourcePoint.PointStyle.ToSystemDrawingBrush();

                destGraphics.FillEllipse(destBrush, destRectangle);
            }
        }

        private void DrawLine(SvgElements.Line sourceLine, Graphics destGraphics)
        {
            if (sourceLine.Visible &&
                sourceLine.LineStyle.Visible)
            {
                Pen destPen = sourceLine.LineStyle.ToSystemDrawing();
                destGraphics.DrawLine(destPen, sourceLine.PointA.X, sourceLine.PointA.Y, sourceLine.PointB.X, sourceLine.PointB.Y);
            }
        }
        
        private void DrawRectangle(SvgElements.Rectangle sourceRectangle, Graphics destGraphics)
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

        private void DrawLabel(SvgElements.Label sourceLabel, Graphics destGraphics)
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
