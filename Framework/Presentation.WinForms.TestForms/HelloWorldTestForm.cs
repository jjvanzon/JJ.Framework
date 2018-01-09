using System.Windows.Forms;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
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
			Text = GetType().FullName;

			var diagram = new Diagram();

			var label = new VectorGraphicsElements.Label
			{
				Diagram = diagram,
				Parent = diagram.Background,
				Text = "Hello World!",
			};
			label.Position.X = 10;
			label.Position.Y = 20;
			label.Position.Width = 500;
			label.Position.Height = 100;

			diagramControl1.Diagram = diagram;
		}
	}
}
