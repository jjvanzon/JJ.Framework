using System.Windows.Forms;

namespace JJ.Framework.Presentation.WinForms.TestForms.SvgWithFlatClone
{
    internal partial class SvgWithFlatClone_TestForm : Form
    {
        public SvgWithFlatClone_TestForm()
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
