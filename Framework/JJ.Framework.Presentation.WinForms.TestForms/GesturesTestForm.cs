using JJ.Framework.Presentation.Svg;
using JJ.Framework.Presentation.Svg.Elements;
using JJ.Framework.Presentation.Svg.Gestures;
using JJ.Framework.Presentation.Svg.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SvgElements = JJ.Framework.Presentation.Svg.Models.Elements;
using SvgStyling = JJ.Framework.Presentation.Svg.Models.Styling;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    public partial class GesturesTestForm : Form
    {
        private SvgElements.Label _label1;
        private SvgElements.Label _label2;

        public GesturesTestForm()
        {
            InitializeComponent();

            Text = GetType().FullName;

            InitializeDiagramAndElements();

            _label1.OnMouseDown += _label1_OnMouseDown;
            _label1.OnMouseMove += _label1_OnMouseMove;
            _label1.OnMouseUp += _label1_OnMouseUp;

            _label2.OnMouseDown += _label2_OnMouseDown;
            _label2.OnMouseMove += _label2_OnMouseMove;
            _label2.OnMouseUp += _label2_OnMouseUp;
        }

        private void InitializeDiagramAndElements()
        {
            var diagram = new Diagram(new MoveGesture());

            float spacing = 10;
            float blockWidth = 200;
            float blockHeight = 60;

            var rectangle1 = new SvgElements.Rectangle
            {
                X = spacing,
                Y = spacing,
                Width = blockWidth,
                Height = blockHeight,
                BackStyle = SvgHelper.BlueBackStyle,
                Diagram = diagram
            };
            rectangle1.SetLineStyle(SvgHelper.DefaultLineStyle);

            _label1 = new SvgElements.Label
            {
                Text = "Label 1",
                X = 0,
                Y = 0,
                Width = blockWidth,
                Height = blockHeight,
                TextStyle = SvgHelper.DefaultTextStyle,
                Parent = rectangle1
            };

            var rectangle2 = new SvgElements.Rectangle
            {
                X = rectangle1.X + blockWidth + spacing,
                Y = spacing,
                Width = blockWidth,
                Height = blockHeight,
                BackStyle = SvgHelper.BlueBackStyle,
                Diagram = diagram
            };
            rectangle2.SetLineStyle(SvgHelper.DefaultLineStyle);

            _label2 = new SvgElements.Label
            {
                Text = "Label 2",
                X = 0,
                Y = 0,
                Width = blockWidth,
                Height = blockHeight,
                TextStyle = SvgHelper.DefaultTextStyle,
                Parent = rectangle2
            };

            diagramControl1.Diagram = diagram;
        }

        void _label1_OnMouseDown(object sender, Svg.EventArg.MouseEventArgs e)
        {
            _label1.Text = "MouseDown";
        }

        void _label1_OnMouseMove(object sender, Svg.EventArg.MouseEventArgs e)
        {
            _label1.Text = "MouseMove";
        }

        private void _label1_OnMouseUp(object sender, Svg.EventArg.MouseEventArgs e)
        {
            _label1.Text = "MouseUp";
        }

        void _label2_OnMouseDown(object sender, Svg.EventArg.MouseEventArgs e)
        {
            _label2.Text = "MouseDown";
        }

        void _label2_OnMouseMove(object sender, Svg.EventArg.MouseEventArgs e)
        {
            _label2.Text = "MouseMove";
        }

        private void _label2_OnMouseUp(object sender, Svg.EventArg.MouseEventArgs e)
        {
            _label2.Text = "MouseUp";
        }
    }
}
