using JJ.Framework.Presentation.Svg.Models;
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
    public partial class HelloWorldTestForm : Form
    {
        SvgElements.Container _svgContainer;

        public HelloWorldTestForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Text = this.GetType().FullName;

            _svgContainer = new SvgElements.Container
            {
                ChildLabels = new SvgElements.Label[]
                {
                    new SvgElements.Label
                    { 
                        Text = "Hello World!",
                        Rectangle = new SvgElements.Rectangle 
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
            diagramControl1.Draw(_svgContainer);
        }
    }
}
