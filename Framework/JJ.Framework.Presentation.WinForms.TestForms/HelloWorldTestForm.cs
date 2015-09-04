using JJ.Framework.Presentation.Svg.Models.Elements;
using System.Windows.Forms;
using SvgElements = JJ.Framework.Presentation.Svg.Models.Elements;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    internal partial class HelloWorldTestForm : Form
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
                Parent = diagram.Canvas,
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
