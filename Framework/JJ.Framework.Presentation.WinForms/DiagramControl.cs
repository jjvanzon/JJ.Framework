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
using JJ.Framework.Presentation.Drawing.Extensions;
using SvgModels = JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Presentation.Drawing;

namespace JJ.Framework.Presentation.WinForms
{
    public partial class DiagramControl : UserControl
    {

        ControlGraphicsBuffer _graphicsBuffer;

        public DiagramControl()
        {
            InitializeComponent();

            _graphicsBuffer = new ControlGraphicsBuffer(this);
        }

        public void Draw(SvgModels.ElementBase element)
        {
            SvgDrawer.Draw(element, _graphicsBuffer.Graphics);
            _graphicsBuffer.DrawBuffer();   
        }
    }
}