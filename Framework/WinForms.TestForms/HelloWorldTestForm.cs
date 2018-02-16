using System.Windows.Forms;
using JJ.Framework.VectorGraphics.Models.Elements;
using Label = JJ.Framework.VectorGraphics.Models.Elements.Label;

namespace JJ.Framework.WinForms.TestForms
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

			var label = new Label(diagram.Background)
			{
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
