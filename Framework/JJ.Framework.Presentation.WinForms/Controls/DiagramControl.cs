using System.Windows.Forms;
using JJ.Framework.Presentation.Drawing;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Presentation.WinForms.Helpers;
using JJ.Framework.Presentation.WinForms.Extensions;
using JJ.Framework.Presentation.VectorGraphics.Gestures;
using System;
using System.Drawing;

namespace JJ.Framework.Presentation.WinForms.Controls
{
    public partial class DiagramControl : UserControl
    {
        private readonly ControlGraphicsBuffer _graphicsBuffer;
        private Diagram _diagram;

        /// <summary> nullable </summary>
        public Diagram Diagram 
        {
            get { return _diagram; }
            set
            {
                _diagram = value;
                Refresh();
            }
        }

        public DiagramControl()
        {
            InitializeComponent();

            _graphicsBuffer = new ControlGraphicsBuffer(this);
        }

        public DoubleClickGesture CreateDoubleClickGesture()
        {
            return WinFormsVectorGraphicsHelper.CreateDoubleClickGesture();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (Diagram != null)
            {
                Diagram.HandleMouseDown(e.ToVectorGraphics());
            }

            base.OnMouseDown(e);

            Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (Diagram != null)
            {
                Diagram.HandleMouseMove(e.ToVectorGraphics());
            }

            base.OnMouseMove(e);

            Refresh();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (Diagram != null)
            {
                Diagram.HandleMouseUp(e.ToVectorGraphics());
            }

            base.OnMouseUp(e);

            Refresh();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Diagram != null)
            {
                Diagram.HandleKeyDown(e.ToVectorGraphics());
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (Diagram != null)
            {
                Diagram.HandleKeyUp(e.ToVectorGraphics());
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

            Diagram.Background.Width = Width;
            Diagram.Background.Height = Height;
            if (Diagram.Background.BackStyle.Visible)
            {
                BackColor = Color.FromArgb(Diagram.Background.BackStyle.Color);
            }

            Diagram.Recalculate();
            
            VectorGraphicsDrawer.Draw(Diagram, _graphicsBuffer.Graphics);

            _graphicsBuffer.DrawBuffer();
        }

        private void DiagramControl_Paint(object sender, PaintEventArgs e)
        {
            if (Diagram == null)
            {
                return;
            }

            Diagram.Background.Width = Width;
            Diagram.Background.Height = Height;
            if (Diagram.Background.BackStyle.Visible)
            {
                BackColor = Color.FromArgb(Diagram.Background.BackStyle.Color);
            }

            Diagram.Recalculate();

            VectorGraphicsDrawer.Draw(Diagram, _graphicsBuffer.Graphics);

            _graphicsBuffer.DrawBuffer();
        }
    }
}
