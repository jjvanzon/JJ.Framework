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

namespace JJ.Framework.Presentation.WinForms.TestForms.SvgWithFlatClone
{
    internal partial class DiagramControl_WithFlatClone : UserControl
    {
        ControlGraphicsBuffer _graphicsBuffer;

        public DiagramControl_WithFlatClone()
        {
            InitializeComponent();

            _graphicsBuffer = new ControlGraphicsBuffer(this);
        }

        public void Draw(SvgElements.Rectangle svgRectangle)
        {
            var drawer = new SvgDrawer_WithFlatClone();
            drawer.Draw(svgRectangle, _graphicsBuffer.Graphics);
            _graphicsBuffer.DrawBuffer();
        }
    }
}
