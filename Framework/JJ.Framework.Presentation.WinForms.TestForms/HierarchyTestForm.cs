using System.Windows.Forms;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    internal partial class HierarchyTestForm : Form
    {
        public HierarchyTestForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Text = this.GetType().FullName;

            diagramControl1.Diagram = SvgFactory.CreateTestSvgModel();
        }
    }
}
