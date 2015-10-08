using System.Windows.Forms;
using JJ.Framework.Presentation.WinForms.TestForms.Helpers;

namespace JJ.Framework.Presentation.WinForms.TestForms.VectorGraphicsWithoutCloning
{
    internal partial class VectorGraphicsWithoutCloning_TestForm : Form
    {
        public VectorGraphicsWithoutCloning_TestForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Text = this.GetType().FullName;

            diagramControl1.RootVectorGraphicsRectangle = VectorGraphicsFactory.CreateTestVectorGraphicsModel().Background;
        }
    }
}
