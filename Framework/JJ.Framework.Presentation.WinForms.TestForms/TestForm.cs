using JJ.Framework.Presentation.Svg.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SvgModels = JJ.Framework.Presentation.Svg.Models;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    public partial class TestForm : Form
    {
        SvgModel _svgModel;

        public TestForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            _svgModel = new SvgModel();
            _svgModel.Labels.Add(new SvgModels.Label
            { 
                Text = "Hello World!",
                Rectangle = new Rectangle 
                { 
                    X = 10, 
                    Y = 20, 
                    Width = 500, 
                    Height = 100
                }
            });
        }

        private void TestForm_Resize(object sender, EventArgs e)
        {
            diagramControl1.Draw(_svgModel);
        }

        private void TestForm_Shown(object sender, EventArgs e)
        {
            diagramControl1.Draw(_svgModel);
        }
    }
}
