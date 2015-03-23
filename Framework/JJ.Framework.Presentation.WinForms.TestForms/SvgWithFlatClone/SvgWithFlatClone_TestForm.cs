using JJ.Framework.Presentation.Svg.Enums;
using JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Presentation.Svg.Models.Styling;
using JJ.Framework.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SvgElements = JJ.Framework.Presentation.Svg.Models.Elements;

namespace JJ.Framework.Presentation.WinForms.TestForms.SvgWithFlatClone
{
    public partial class SvgWithFlatClone_TestForm : Form
    {
        SvgElements.Rectangle _rootSvgRectangle;

        public SvgWithFlatClone_TestForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Text = this.GetType().FullName;

            _rootSvgRectangle = new SvgElements.Rectangle();

            SvgElements.Rectangle rectangle1 = CreateRectangle(200, 10, "Block 1");

            SvgElements.Rectangle rectangle2 = CreateRectangle(10, 200, "Block 2");

            var point1 = new SvgElements.Point
            { 
                X = 150, 
                Y = 30,
                PointStyle = SvgHelper.InvisiblePointStyle
            };
            rectangle1.ChildPoints.Add(point1);

            var point2 = new SvgElements.Point 
            {
                X = 150,
                Y = 30,
                PointStyle = SvgHelper.InvisiblePointStyle
            };
            rectangle2.ChildPoints.Add(point2);

            var line = new SvgElements.Line 
            {
                PointA = point1, 
                PointB = point2,
                LineStyle = SvgHelper.DefaultLineStyle
            };

            _rootSvgRectangle.ChildLines.Add(line);
            _rootSvgRectangle.ChildRectangles.Add(rectangle1);
            _rootSvgRectangle.ChildRectangles.Add(rectangle2);
        }

        private void HierarchyTestForm_Paint(object sender, PaintEventArgs e)
        {
            _rootSvgRectangle.Width = this.ClientSize.Width;
            _rootSvgRectangle.Height = this.ClientSize.Height;

            diagramControl1.Draw(_rootSvgRectangle);
        }

        private SvgElements.Rectangle CreateRectangle(float x, float y, string text)
        {
            var rectangle = new SvgElements.Rectangle
            {
                X = x,
                Y = y,
                Width = 300,
                Height = 60,
                ChildLabels = new SvgElements.Label[]
                {
                    new SvgElements.Label
                    {
                        Rectangle = new SvgElements.Rectangle { Width = 300, Height = 60 },
                        Text = text,
                        TextStyle = SvgHelper.DefaultTextStyle
                    }
                }
            };

            rectangle.SetLineStyle(SvgHelper.DefaultLineStyle);

            return rectangle;
        }
    }
}
