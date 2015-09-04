using System.Windows.Forms;
using SvgElements = JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Presentation.WinForms.Helpers;

namespace JJ.Framework.Presentation.WinForms.TestForms.SvgWithFlatClone
{
    internal partial class DiagramControl_WithFlatClone : UserControl
    {
        public SvgElements.Rectangle RootSvgRectangle { get; set; }

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
            if (RootSvgRectangle == null)
            {
                return;
            }

            RootSvgRectangle.Width = Width;
            RootSvgRectangle.Height = Height;

            var drawer = new SvgDrawer_WithFlatClone();
            drawer.Draw(RootSvgRectangle, _graphicsBuffer.Graphics);
            _graphicsBuffer.DrawBuffer();
        }
    }
}
