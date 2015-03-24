using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Presentation.Svg.Visitors;
using SvgElements = JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Presentation.Drawing;

namespace JJ.Framework.Presentation.WinForms.TestForms.SvgWithoutCloning
{
    internal partial class DiagramControl_WithoutCloning : UserControl
    {
        private ControlGraphicsBuffer _graphicsBuffer;

        public SvgElements.Rectangle RootSvgRectangle { get; set; }

        public DiagramControl_WithoutCloning()
        {
            InitializeComponent();

            _graphicsBuffer = new ControlGraphicsBuffer(this);
        }

        private void DiagramControl_WithoutCloning_Paint(object sender, PaintEventArgs e)
        {
            if (RootSvgRectangle == null)
            {
                return;
            }

            RootSvgRectangle.Width = Width;
            RootSvgRectangle.Height = Height;

            var drawer = new SvgDrawer_WithoutCloning();
            drawer.Draw(RootSvgRectangle, _graphicsBuffer.Graphics);
            _graphicsBuffer.DrawBuffer();
        }
    }
}
