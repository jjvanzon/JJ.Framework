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

            var svgManager = new SvgManager();
            SvgElements.Label label = svgManager.CreateLabel(svgManager.RootRectangle);
            label.Text = "Hello World!";
            label.Rectangle.X = 10;
            label.Rectangle.Y = 20;
            label.Rectangle.Width = 500;
            label.Rectangle.Height = 100;

            diagramControl1.SvgManager = svgManager;
        }
    }
}
