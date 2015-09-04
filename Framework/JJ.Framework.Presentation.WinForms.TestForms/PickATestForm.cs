using JJ.Framework.Presentation.WinForms.TestForms.SvgWithFlatClone;
using JJ.Framework.Presentation.WinForms.TestForms.SvgWithoutCloning;
using System;
using System.Windows.Forms;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    internal partial class PickATestForm : Form
    {
        public PickATestForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Text = this.GetType().FullName;
        }

        private void buttonShowHierarchyTestForm_Click(object sender, EventArgs e)
        {
            new HierarchyTestForm().Show();
        }

        private void buttonShowHelloWorldTestForm_Click(object sender, EventArgs e)
        {
            new HelloWorldTestForm().Show();
        }

        private void buttonShowSvgWithFlatClone_TestForm_Click(object sender, EventArgs e)
        {
            new SvgWithFlatClone_TestForm().Show();
        }

        private void buttonShowSvgWithoutCloning_TestForm_Click(object sender, EventArgs e)
        {
            new SvgWithoutCloning_TestForm().Show();
        }

        private void buttonShowGestureTestForm_Click(object sender, EventArgs e)
        {
            new GesturesTestForm().Show();
        }

        private void buttonShowCurveTest_Click(object sender, EventArgs e)
        {
            new CurveTestForm().Show();
        }
    }
}
