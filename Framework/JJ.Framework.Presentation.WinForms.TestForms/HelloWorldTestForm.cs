using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using System.Windows.Forms;
using VectorGraphicsElements = JJ.Framework.Presentation.VectorGraphics.Models.Elements;

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

            var label = new VectorGraphicsElements.Label
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
