﻿using System.Windows.Forms;
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
                Diagram.GestureHandling.HandleMouseDown(e.ToVectorGraphics());
            }

            base.OnMouseDown(e);

            Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (Diagram != null)
            {
                Diagram.GestureHandling.HandleMouseMove(e.ToVectorGraphics());
            }

            base.OnMouseMove(e);

            Refresh();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (Diagram != null)
            {
                Diagram.GestureHandling.HandleMouseUp(e.ToVectorGraphics());
            }

            base.OnMouseUp(e);

            Refresh();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Diagram != null)
            {
                 Diagram.GestureHandling.HandleKeyDown(e.ToVectorGraphics());
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (Diagram != null)
            {
                Diagram.GestureHandling.HandleKeyUp(e.ToVectorGraphics());
            }

            base.OnKeyUp(e);
        }

        public override void Refresh()
        {
            Draw();
        }

        // Unfortunatly Draw might go off twice when making the control bigger,
        // and once when making the control smaller,
        // because making it bigger will trigger a Paint event,
        // while making it smaller does not.
        // Responding to Resize is important if the diagram scales.

        private void DiagramControl_Resize(object sender, EventArgs e)
        {
            Draw();
        }

        private void DiagramControl_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            // TODO: On my laptop it could be null, while on my large desktop PC this does not happen. Strange.
            if (_graphicsBuffer == null)
            {
                return;
            }

            if (Diagram == null)
            {
                _graphicsBuffer.Graphics.Clear(BackColor);
                _graphicsBuffer.DrawBuffer();
                return;
            }

            Diagram.Position.HeightInPixels = Height;
            Diagram.Position.WidthInPixels = Width;

            if (Diagram.Background.Style.BackStyle.Visible)
            {
                BackColor = Color.FromArgb(Diagram.Background.Style.BackStyle.Color);
            }

            Diagram.Recalculate();

            VectorGraphicsDrawer.Draw(Diagram, _graphicsBuffer.Graphics);

            _graphicsBuffer.DrawBuffer();
        }
    }
}
