using System;
using System.Linq;
using System.Windows.Forms;
using JJ.Framework.VectorGraphics.Gestures;
using JJ.Framework.VectorGraphics.Models.Elements;
using JJ.Framework.WinForms.TestForms.Helpers;
using JJ.Framework.WinForms.TestForms.Properties;
using Label = JJ.Framework.VectorGraphics.Models.Elements.Label;

namespace JJ.Framework.WinForms.TestForms
{
	internal partial class PictureTestForm : Form
	{
		private readonly Picture _picture;
		private readonly Label _scaleButtonLabel;
		private readonly Label _makeSeeThroughButtonLabel;
		private readonly Label _clipButtonLabel;

		public PictureTestForm()
		{
			InitializeComponent();

			// ReSharper disable once VirtualMemberCallInConstructor
			Text = GetType().FullName;

			var diagram = new Diagram();

			float currentY = VectorGraphicsHelper.SPACING;

			MouseDownGesture mouseDownGesture;
			Rectangle rectangle;

			(rectangle, _scaleButtonLabel, mouseDownGesture) = CreateButton(diagram, "");
			mouseDownGesture.MouseDown += ScaleMouseDownGesture_MouseDown;
			rectangle.Position.Y = currentY;

			currentY += VectorGraphicsHelper.BLOCK_HEIGHT + VectorGraphicsHelper.SPACING;

			(rectangle, _makeSeeThroughButtonLabel, mouseDownGesture) = CreateButton(diagram, "");
			mouseDownGesture.MouseDown += MakeSeeThroughMouseDownGesture_MouseDown;
			rectangle.Position.Y = currentY;

			currentY += VectorGraphicsHelper.BLOCK_HEIGHT + VectorGraphicsHelper.SPACING;

			(rectangle, _clipButtonLabel, mouseDownGesture) = CreateButton(diagram, "");
			mouseDownGesture.MouseDown += ClipMouseDownGesture_MouseDown;
			rectangle.Position.Y = currentY;

			_picture = new Picture
			{
				Diagram = diagram,
				Parent = diagram.Background
			};
			_picture.Position.X = 10;
			_picture.Position.Y = 20;
			_picture.Position.Width = 24;
			_picture.Position.Height = 100;

			_picture.Gestures.Add(new MoveGesture());
			_picture.UnderlyingPicture = Resources.Pencil;

			SetScaleButtonText();
			SetClipButtonText();
			SetMakeSeeThroughButtonText();

			diagramControl1.Diagram = diagram;
		}

		private void ScaleMouseDownGesture_MouseDown(object sender, VectorGraphics.EventArg.MouseEventArgs e)
		{
			_picture.Style.Scale = !_picture.Style.Scale;
			SetScaleButtonText();
		}

		private void MakeSeeThroughMouseDownGesture_MouseDown(object sender, VectorGraphics.EventArg.MouseEventArgs e)
		{
			_picture.Style.Opacity = IsOpaque(_picture.Style.Opacity) ? 0.5f : 1f;
			SetMakeSeeThroughButtonText();
		}

		private void ClipMouseDownGesture_MouseDown(object sender, VectorGraphics.EventArg.MouseEventArgs e)
		{
			_picture.Style.Clip = !_picture.Style.Clip;
			SetClipButtonText();
		}

		private void SetScaleButtonText() => _scaleButtonLabel.Text = _picture.Style.Scale ? "Stop Scaling" : "Make it Scale";
		private void SetMakeSeeThroughButtonText() => _makeSeeThroughButtonLabel.Text = IsOpaque(_picture.Style.Opacity) ? "Make Seethrough" : "Make Opaque";
		private void SetClipButtonText() => _clipButtonLabel.Text = _picture.Style.Clip ? "Stop Clipping" : "Clip It";

		private (Rectangle, Label, MouseDownGesture) CreateButton(Diagram diagram, string text)
		{
			Rectangle rectangle = VectorGraphicsFactory.CreateRectangle(diagram, text);
			rectangle.ZIndex = -1;

			Label label = GetLabel(rectangle);

			var mouseDownGesture = new MouseDownGesture();
			rectangle.Gestures.Add(mouseDownGesture);

			return (rectangle, label, mouseDownGesture);
		}

		private Label GetLabel(Rectangle rectangle) => rectangle.Children.OfType<Label>().Single();
		private bool IsOpaque(float opacity) => Math.Abs(opacity - 1f) < 0.0001;
	}
}
