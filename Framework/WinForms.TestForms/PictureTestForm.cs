using System.Windows.Forms;
using JJ.Framework.Drawing;
using JJ.Framework.VectorGraphics.Gestures;
using JJ.Framework.VectorGraphics.Models.Elements;
using JJ.Framework.WinForms.TestForms.Helpers;
using JJ.Framework.WinForms.TestForms.Properties;

namespace JJ.Framework.WinForms.TestForms
{
	internal partial class PictureTestForm : Form
	{
		public PictureTestForm()
		{
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
			Text = GetType().FullName;

			var diagram = new Diagram();

			Rectangle rectangle = VectorGraphicsFactory.CreateRectangle(diagram, text: "");
			rectangle.ZIndex = -1;

			var picture = new Picture
			{
				Diagram = diagram,
				Parent = diagram.Background
			};
			picture.Position.X = 10;
			picture.Position.Y = 20;
			picture.Position.Width = 150;
			picture.Position.Height = 100;

			picture.Gestures.Add(new MoveGesture());

			var wrapper = new UnderlyingPictureWrapper { Bitmap = Resources.Pencil };
			picture.SetUnderlyingPictureWrapper(wrapper);

			diagramControl1.Diagram = diagram;
		}
	}
}
