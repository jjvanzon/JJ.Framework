using System.Windows.Forms;

namespace JJ.Framework.Presentation.WinForms.TestForms.VectorGraphicsWithFlatClone
{
    internal partial class VectorGraphicsWithFlatClone_TestForm : Form
    {
        public VectorGraphicsWithFlatClone_TestForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Text = this.GetType().FullName;

            diagramControl1.RootVectorGraphicsRectangle = VectorGraphicsFactory.CreateTestVectorGraphicsModel().Canvas;
        }
    }
}
