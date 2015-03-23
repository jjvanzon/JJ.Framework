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

namespace JJ.Framework.Presentation.WinForms.TestForms.SvgWithoutCloning
{
    public partial class SvgWithoutCloning_TestForm : Form
    {
        SvgElements.Rectangle _rootSvgRectangle;

        public SvgWithoutCloning_TestForm()
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
            rectangle1.Children.Add(point1);

            var point2 = new SvgElements.Point 
            {
                X = 150,
                Y = 30,
                PointStyle = SvgHelper.InvisiblePointStyle
            };
            rectangle2.Children.Add(point2);

            var line = new SvgElements.Line 
            {
                PointA = point1, 
                PointB = point2,
                LineStyle = SvgHelper.DefaultLineStyle
            };

            _rootSvgRectangle.Children.Add(line);
            _rootSvgRectangle.Children.Add(rectangle1);
            _rootSvgRectangle.Children.Add(rectangle2);
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
                Children = new List<SvgElements.ElementBase>
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
