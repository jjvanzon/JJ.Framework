using JJ.Framework.Presentation.Svg.Visitors;
using JJ.Framework.Presentation.Drawing.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SvgModels = JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Reflection;

namespace JJ.Framework.Presentation.Drawing
{
    public static class SvgDrawer
    {
        private static readonly Pen _defaultPen = new Pen(Color.Black);
        private static readonly System.Drawing.Font _defaultFont = new System.Drawing.Font("Verdana", 12);
        private static readonly Brush _defaultBrush = Brushes.Black;

        public static void Draw(SvgModels.ElementBase sourceElement, Graphics destGraphics)
        {
            if (sourceElement == null) throw new NullException(() => sourceElement);
            if (destGraphics == null) throw new NullException(() => destGraphics);


            var visitor = new ToAbsoluteVisitor();
            var destContainer = visitor.Execute(sourceElement);

            destGraphics.Clear(Color.White);

            foreach (SvgModels.Line line in destContainer.ChildLines)
            {
                destGraphics.DrawLine(_defaultPen, line.PointA.X, line.PointA.Y, line.PointB.X, line.PointB.Y);
            }

            foreach (SvgModels.Rectangle rectangle in destContainer.ChildRectangles)
            {
                destGraphics.DrawRectangle(_defaultPen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            }

            foreach (SvgModels.Label label in destContainer.ChildLabels)
            {
                var destRectangle = new RectangleF(label.Rectangle.X, label.Rectangle.Y, label.Rectangle.Width, label.Rectangle.Height);
                StringFormat destStringFormat = label.ToSystemDrawingStringFormat();
                destGraphics.DrawString(label.Text, _defaultFont, _defaultBrush, destRectangle, destStringFormat);
            }
        }
    }
}
