//using System.Windows.Forms;
//using VectorGraphicsElements = JJ.Framework.Presentation.VectorGraphics.Models.Elements;
//using JJ.Framework.Presentation.WinForms.Helpers;

//namespace JJ.Framework.Presentation.WinForms.TestForms.VectorGraphicsWithoutCloning
//{
//    internal partial class DiagramControl_WithoutCloning : UserControl
//    {
//        // TODO: 
//        // Warning CA2213	'DiagramControl' contains field 'DiagramControl._graphicsBuffer' that is of IDisposable type: 'ControlGraphicsBuffer'. Change the Dispose method on 'DiagramControl' to call Dispose or Close on this field.
//        private ControlGraphicsBuffer _graphicsBuffer;

//        public VectorGraphicsElements.Rectangle RootVectorGraphicsRectangle { get; set; }

//        public DiagramControl_WithoutCloning()
//        {
//            InitializeComponent();

//            _graphicsBuffer = new ControlGraphicsBuffer(this);
//        }

//        private void DiagramControl_WithoutCloning_Paint(object sender, PaintEventArgs e)
//        {
//            if (RootVectorGraphicsRectangle == null)
//            {
//                return;
//            }

//            RootVectorGraphicsRectangle.Width = Width;
//            RootVectorGraphicsRectangle.Height = Height;

//            var drawer = new VectorGraphicsDrawer_WithoutCloning();
//            drawer.Draw(RootVectorGraphicsRectangle, _graphicsBuffer.Graphics);
//            _graphicsBuffer.DrawBuffer();
//        }
//    }
//}
