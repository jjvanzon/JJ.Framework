﻿using System.Windows.Forms;
using VectorGraphicsElements = JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Presentation.WinForms.Helpers;

namespace JJ.Framework.Presentation.WinForms.TestForms.VectorGraphicsWithFlatClone
{
    internal partial class DiagramControl_WithFlatClone : UserControl
    {
        public VectorGraphicsElements.Rectangle RootVectorGraphicsRectangle { get; set; }

        // TODO: 
        // Warning CA2213	'DiagramControl' contains field 'DiagramControl._graphicsBuffer' that is of IDisposable type: 'ControlGraphicsBuffer'. Change the Dispose method on 'DiagramControl' to call Dispose or Close on this field.
        private ControlGraphicsBuffer _graphicsBuffer;

        public DiagramControl_WithFlatClone()
        {
            InitializeComponent();

            _graphicsBuffer = new ControlGraphicsBuffer(this);
        }

        private void DiagramControl_WithFlatClone_Paint(object sender, PaintEventArgs e)
        {
            if (RootVectorGraphicsRectangle == null)
            {
                return;
            }

            RootVectorGraphicsRectangle.Position.Width = Width;
            RootVectorGraphicsRectangle.Position.Height = Height;

            var drawer = new VectorGraphicsDrawer_WithFlatClone();
            drawer.Draw(RootVectorGraphicsRectangle, _graphicsBuffer.Graphics);
            _graphicsBuffer.DrawBuffer();
        }
    }
}
