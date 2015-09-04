using System.Windows.Forms;

namespace JJ.Framework.Presentation.WinForms.TestForms.SvgWithoutCloning
{
    internal partial class SvgWithoutCloning_TestForm : Form
    {
        public SvgWithoutCloning_TestForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Text = this.GetType().FullName;

            diagramControl1.RootSvgRectangle = SvgFactory.CreateTestSvgModel().Canvas;
        }
    }
}
