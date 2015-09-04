using System.Windows.Forms;
using JJ.Framework.Presentation.Drawing;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Presentation.WinForms.Helpers;
using JJ.Framework.Presentation.WinForms.Extensions;

namespace JJ.Framework.Presentation.WinForms.Controls
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

        // TODO: 
        // Warning CA2213	'DiagramControl' contains field 'DiagramControl._graphicsBuffer' that is of IDisposable type: 'ControlGraphicsBuffer'. Change the Dispose method on 'DiagramControl' to call Dispose or Close on this field.
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
                Diagram.HandleMouseDown(e.ToSvg());
            }

            base.OnMouseDown(e);

            Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (Diagram != null)
            {
                Diagram.HandleMouseMove(e.ToSvg());
            }

            base.OnMouseMove(e);

            Refresh();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (Diagram != null)
            {
                Diagram.HandleMouseUp(e.ToSvg());
            }

            base.OnMouseUp(e);

            Refresh();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Diagram != null)
            {
                Diagram.HandleKeyDown(e.ToSvg());
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (Diagram != null)
            {
                Diagram.HandleKeyUp(e.ToSvg());
            }

            base.OnKeyUp(e);
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
