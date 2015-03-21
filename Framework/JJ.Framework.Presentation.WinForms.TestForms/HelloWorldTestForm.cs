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
    public partial class HelloWorldTestForm : Form
    {
        ElementBase _svgModel;

        public HelloWorldTestForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Text = this.GetType().FullName;

            _svgModel = new SvgModels.Container
            {
                ChildLabels = new SvgModels.Label[]
                {
                    new SvgModels.Label
                    { 
                        Text = "Hello World!",
                        Rectangle = new Rectangle 
                        { 
                            X = 10,
                            Y = 20,
                            Width = 500,
                            Height = 100
                        }
                    }
                }
            };
        }

        private void HelloWorldTestForm_Paint(object sender, PaintEventArgs e)
        {
            diagramControl1.Draw(_svgModel);
        }
    }
}
