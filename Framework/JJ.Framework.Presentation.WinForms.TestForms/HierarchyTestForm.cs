using JJ.Framework.Presentation.Svg.Enums;
using JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Presentation.Svg.Models.Styling;
using JJ.Framework.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SvgElements = JJ.Framework.Presentation.Svg.Models.Elements;

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
