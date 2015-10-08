using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Presentation.VectorGraphics.Visitors;
using JJ.Framework.Presentation.WinForms.TestForms.Helpers;
using JJ.Framework.Reflection.Exceptions;
using System.Drawing;
using VectorGraphicsElements = JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Presentation.WinForms.TestForms.Helpers;

namespace JJ.Framework.Presentation.WinForms.TestForms.VectorGraphicsWithoutCloning
{
    internal class VectorGraphicsDrawer_WithoutCloning : ElementVisitorBase
    {
        private Graphics _destGraphic;

        public void Draw(VectorGraphicsElements.Rectangle background, Graphics destGraphics)
        {
            if (background == null) throw new NullException(() => background);
            if (destGraphics == null) throw new NullException(() => destGraphics);

            var visitor2 = new CalculationVisitor_WithoutCloning();
            visitor2.Execute(background);

            _destGraphic = destGraphics;

            VisitRectangle(background);
        }

        protected override void VisitPoint(VectorGraphicsElements.Point point)
        {
            DrawPoint(point, _destGraphic);

            base.VisitPoint(point);
        }

        protected override void VisitLine(VectorGraphicsElements.Line line)
        {
            DrawLine(line, _destGraphic);

            base.VisitLine(line);
        }

        protected override void VisitRectangle(VectorGraphicsElements.Rectangle rectangle)
        {
            DrawRectangle(rectangle, _destGraphic);

            base.VisitRectangle(rectangle);
        }

        protected override void VisitLabel(VectorGraphicsElements.Label label)
        {
            DrawLabel(label, _destGraphic);

            base.VisitLabel(label);
        }

        private static void DrawPoint(VectorGraphicsElements.Point sourcePoint, Graphics destGraphics)
        {
            if (sourcePoint.Visible &&
                sourcePoint.PointStyle.Visible)
            {
                RectangleF destRectangle = sourcePoint.ToSystemDrawingRectangleF();
                Brush destBrush = sourcePoint.PointStyle.ToSystemDrawingBrush();

                destGraphics.FillEllipse(destBrush, destRectangle);
            }
        }

        private static void DrawLine(VectorGraphicsElements.Line sourceLine, Graphics destGraphics)
        {
            var sourceLine_PointA_Accessor = new Element_Accessor(sourceLine.PointA);
            var sourceLine_PointB_Accessor = new Element_Accessor(sourceLine.PointB);

            if (sourceLine.Visible &&
                sourceLine.LineStyle.Visible)
            {
                Pen destPen = sourceLine.LineStyle.ToSystemDrawing();
                destGraphics.DrawLine(destPen, sourceLine_PointA_Accessor.CalculatedX, sourceLine_PointA_Accessor.CalculatedY, sourceLine_PointB_Accessor.CalculatedX, sourceLine_PointB_Accessor.CalculatedY);
            }
        }

        private static void DrawRectangle(VectorGraphicsElements.Rectangle sourceRectangle, Graphics destGraphics)
        {
            var sourceRectangle_Accessor = new Element_Accessor(sourceRectangle);

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
                        sourceRectangle_Accessor.CalculatedX,
                        sourceRectangle_Accessor.CalculatedY,
                        sourceRectangle.Width,
                        sourceRectangle.Height);
                }
            }
            else
            {
                // Draw 4 Border Lines (with different styles)

                float right = sourceRectangle_Accessor.CalculatedX + sourceRectangle.Width;
                float bottom = sourceRectangle_Accessor.CalculatedY + sourceRectangle.Height;

                PointF destTopLeftPointF = new PointF(sourceRectangle_Accessor.CalculatedX, sourceRectangle_Accessor.CalculatedY);
                PointF destTopRightPointF = new PointF(right, sourceRectangle_Accessor.CalculatedY);
                PointF destBottomRightPointF = new PointF(right, bottom);
                PointF destBottomLeftPointF = new PointF(sourceRectangle_Accessor.CalculatedX, bottom);

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

        private static void DrawLabel(VectorGraphicsElements.Label sourceLabel, Graphics destGraphics)
        {
            var sourceLabel_Accessor = new Element_Accessor(sourceLabel);

            if (!sourceLabel.Visible)
            {
                return;
            }

            StringFormat destStringFormat = sourceLabel.TextStyle.ToSystemDrawingStringFormat();
            System.Drawing.Font destFont = sourceLabel.TextStyle.Font.ToSystemDrawing();
            RectangleF destRectangle = new RectangleF(sourceLabel_Accessor.CalculatedX, sourceLabel_Accessor.CalculatedY, sourceLabel.Width, sourceLabel.Height);
            Brush destBrush = sourceLabel.TextStyle.ToSystemDrawingBrush();

            destGraphics.DrawString(sourceLabel.Text, destFont, destBrush, destRectangle, destStringFormat);
        }
    }
}
