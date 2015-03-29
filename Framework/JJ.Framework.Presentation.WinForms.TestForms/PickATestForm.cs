using JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Presentation.WinForms.TestForms.SvgWithFlatClone;
using JJ.Framework.Presentation.WinForms.TestForms.SvgWithoutCloning;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SvgElements = JJ.Framework.Presentation.Svg.Models.Elements;
using SvgStyling = JJ.Framework.Presentation.Svg.Models.Styling;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    public partial class PickATestForm : Form
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
    }
}
