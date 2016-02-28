using JJ.Framework.Presentation.VectorGraphics.Visitors;
using System;
using System.Collections.Generic;
using System.Drawing;
using VectorGraphicsElements = JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Reflection.Exceptions;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Presentation.WinForms.TestForms.Helpers;

namespace JJ.Framework.Presentation.WinForms.TestForms.VectorGraphicsWithFlatClone
{
    internal class VectorGraphicsDrawer_WithFlatClone
    {
        public void Draw(VectorGraphicsElements.Rectangle sourceBackground, Graphics destGraphics)
        {
            if (sourceBackground == null) throw new NullException(() => sourceBackground);
            if (destGraphics == null) throw new NullException(() => destGraphics);

            var visitor_Accessor = new CalculationVisitor_Accessor();
            IList<VectorGraphicsElements.Element> elements = visitor_Accessor.Execute(sourceBackground.Diagram);

            foreach (VectorGraphicsElements.Element element in elements)
            {
                DrawPolymorphic(element, destGraphics);
            }
        }

        private void DrawPolymorphic(VectorGraphicsElements.Element sourceElement, Graphics destGraphics)
        {
            var sourcePoint = sourceElement as VectorGraphicsElements.Point;
            if (sourcePoint != null)
            {
                DrawPoint(sourcePoint, destGraphics);
                return;
            }

            var sourceLine = sourceElement as VectorGraphicsElements.Line;
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

            var sourceLabel = sourceElement as VectorGraphicsElements.Label;
            if (sourceLabel != null)
            {
                DrawLabel(sourceLabel, destGraphics);
                return;
            }

            throw new Exception(String.Format("Unexpected Element type '{0}'", sourceElement.GetType().FullName));
        }

        //private void DrawBackground(VectorGraphicsElements.Rectangle sourceRectangle, Graphics destGraphics)
        //{
        //    if (sourceRectangle.Visible && sourceRectangle.BackStyle.Visible)
        //    {
        //        Color destBackColor = sourceRectangle.BackStyle.Color.ToSystemDrawing();
        //        destGraphics.Clear(destBackColor);
        //    }
        //}

        private void DrawPoint(VectorGraphicsElements.Point sourcePoint, Graphics destGraphics)
        {
            if (sourcePoint.Visible && sourcePoint.PointStyle.Visible)
            {
                RectangleF destRectangle = sourcePoint.ToSystemDrawingRectangleF();
                Brush destBrush = sourcePoint.PointStyle.ToSystemDrawingBrush();

                destGraphics.FillEllipse(destBrush, destRectangle);
            }
        }

        private void DrawLine(VectorGraphicsElements.Line sourceLine, Graphics destGraphics)
        {
            if (sourceLine.Visible && sourceLine.LineStyle.Visible)
            {
                Pen destPen = sourceLine.LineStyle.ToSystemDrawing();
                destGraphics.DrawLine(destPen, sourceLine.PointA.X, sourceLine.PointA.Y, sourceLine.PointB.X, sourceLine.PointB.Y);
            }
        }

        private void DrawRectangle(VectorGraphicsElements.Rectangle sourceRectangle, Graphics destGraphics)
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
            LineStyle lineStyle = sourceRectangle.LineStyle;
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

        private void DrawLabel(VectorGraphicsElements.Label sourceLabel, Graphics destGraphics)
        {
            if (!sourceLabel.Visible)
            {
                return;
            }

            StringFormat destStringFormat = sourceLabel.TextStyle.ToSystemDrawingStringFormat();
            System.Drawing.Font destFont = sourceLabel.TextStyle.Font.ToSystemDrawing();
            RectangleF destRectangle = new RectangleF(sourceLabel.X, sourceLabel.Y, sourceLabel.Width, sourceLabel.Height);
            Brush destBrush = sourceLabel.TextStyle.ToSystemDrawingBrush();

            destGraphics.DrawString(sourceLabel.Text, destFont, destBrush, destRectangle, destStringFormat);
        }
    }
}
