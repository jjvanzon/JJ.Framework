using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SvgModels = JJ.Framework.Presentation.Svg.Models;
using System.Drawing;
using JJ.Framework.Presentation.Svg.Models;

namespace JJ.Framework.Presentation.WinForms
{
    public partial class DiagramControl : UserControl
    {
        private static readonly Pen _defaultPen = new Pen(Color.Black);
        private static readonly System.Drawing.Font _defaultFont = new System.Drawing.Font("Verdana", 12);
        private static readonly Brush _defaultBrush = Brushes.Black;

        ControlGraphicsBuffer _graphicsBuffer;

        public DiagramControl()
        {
            InitializeComponent();

            _graphicsBuffer = new ControlGraphicsBuffer(this);
        }

        public void Draw(SvgModel svgModel)
        {
            _graphicsBuffer.Graphics.Clear(Color.White);

            foreach (Line line in svgModel.Lines)
            {
                _graphicsBuffer.Graphics.DrawLine(_defaultPen, line.PointA.X, line.PointA.Y, line.PointB.X, line.PointB.Y);
            }

            foreach (SvgModels.Rectangle rectangle in svgModel.Rectangles)
            {
                _graphicsBuffer.Graphics.DrawRectangle(_defaultPen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            }

            foreach (SvgModels.Label label in svgModel.Labels)
            {
                var rectangle = new RectangleF(label.Rectangle.X, label.Rectangle.Y, label.Rectangle.Width, label.Rectangle.Height);
                _graphicsBuffer.Graphics.DrawString(label.Text, _defaultFont, _defaultBrush, rectangle);
            }

            _graphicsBuffer.DrawBuffer();   
        }
    }
}