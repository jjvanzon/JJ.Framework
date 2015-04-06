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
using JJ.Framework.Presentation.Svg;
using JJ.Framework.Presentation.Svg.Models.Elements;

namespace JJ.Framework.Presentation.WinForms
{
    public partial class DiagramControl : UserControl
    {
        private Diagram _diagram;
        /// <summary> nullable </summary>
        public Diagram Diagram 
        {
            get { return _diagram; }
            set
            {
                if (_diagram == value) return;
                _diagram = value;
                Refresh();
            }
        }

        private ControlGraphicsBuffer _graphicsBuffer;

        public DiagramControl()
        {
            InitializeComponent();

            _graphicsBuffer = new ControlGraphicsBuffer(this);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (Diagram != null)
            {
                Diagram.MouseDown(e.ToSvg());
            }

            base.OnMouseDown(e);

            Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (Diagram != null)
            {
                Diagram.MouseMove(e.ToSvg());
            }

            base.OnMouseMove(e);

            if (e.Button != MouseButtons.None)
            {
                Refresh();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (Diagram != null)
            {
                Diagram.MouseUp(e.ToSvg());
            }

            base.OnMouseUp(e);

            Refresh();
        }

        public override void Refresh()
        {
            if (Diagram == null)
            {
                _graphicsBuffer.Graphics.Clear(BackColor);
                _graphicsBuffer.DrawBuffer();
                return;
            }

            Diagram.Canvas.Width = Width;
            Diagram.Canvas.Height = Height;

            Diagram.Recalculate();
            
            SvgDrawer.Draw(Diagram, _graphicsBuffer.Graphics);

            _graphicsBuffer.DrawBuffer();
        }

        private void DiagramControl_Paint(object sender, PaintEventArgs e)
        {
            if (Diagram == null)
            {
                return;
            }

            Diagram.Canvas.Width = Width;
            Diagram.Canvas.Height = Height;

            Diagram.Recalculate();

            SvgDrawer.Draw(Diagram, _graphicsBuffer.Graphics);

            _graphicsBuffer.DrawBuffer();
        }
    }
}
