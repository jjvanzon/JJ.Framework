using System.Windows.Forms;
using JJ.Framework.VectorGraphics.Gestures;
using JJ.Framework.VectorGraphics.Helpers;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.WinForms.TestForms
{
	internal partial class EllipseTestForm : Form
	{
		public EllipseTestForm()
		{
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
			Text = GetType().FullName;

			var diagram = new Diagram();

			var element = new Ellipse
			{
				Diagram = diagram,
				Parent = diagram.Background
			};
			element.Position.X = 10;
			element.Position.Y = 20;
			element.Position.Width = 150;
			element.Position.Height = 100;

			element.Style.BackStyle.Color = ColorHelper.GetColor(180, 180, 180);
			element.Style.LineStyle.Color = ColorHelper.GetColor(50, 80, 120);
			element.Style.LineStyle.Width = 5;

			element.Gestures.Add(new MoveGesture());

			diagramControl1.Diagram = diagram;
		}
	}
}
