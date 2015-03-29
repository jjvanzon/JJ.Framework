using JJ.Framework.Presentation.Svg;
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
        public HelloWorldTestForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Text = this.GetType().FullName;

            var diagram = new Diagram();

            var label = new SvgElements.Label
            {
                Diagram = diagram,
                Text = "Hello World!",
                X = 10,
                Y = 20,
                Width = 500,
                Height = 100
            };

            diagramControl1.Diagram = diagram;
        }
    }
}
