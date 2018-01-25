using System;
using System.Drawing;
using System.Windows.Forms;
using JJ.Framework.Drawing;
using JJ.Framework.VectorGraphics.Gestures;
using JJ.Framework.VectorGraphics.Models.Elements;
using JJ.Framework.WinForms.Extensions;
using JJ.Framework.WinForms.Helpers;

namespace JJ.Framework.WinForms.Controls
{
	public partial class DiagramControl : UserControl
	{
		private readonly ControlGraphicsBuffer _graphicsBuffer;
		private Diagram _diagram;

		/// <summary> nullable </summary>
		public Diagram Diagram 
		{
			get => _diagram;
			set
			{
				_diagram = value;
				Refresh();
			}
		}

		public DiagramControl()
		{
			InitializeComponent();

			_graphicsBuffer = new ControlGraphicsBuffer(this);
		}

		public DoubleClickGesture CreateDoubleClickGesture() => WinFormsVectorGraphicsHelper.CreateDoubleClickGesture();

		protected override void OnMouseDown(MouseEventArgs e)
		{
			Diagram?.GestureHandling.HandleMouseDown(e.ToVectorGraphics());

			base.OnMouseDown(e);

			Refresh();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			Diagram?.GestureHandling.HandleMouseMove(e.ToVectorGraphics());

			base.OnMouseMove(e);

			Refresh();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			Diagram?.GestureHandling.HandleMouseUp(e.ToVectorGraphics());

			base.OnMouseUp(e);

			Refresh();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			Diagram?.GestureHandling.HandleKeyDown(e.ToVectorGraphics());

			base.OnKeyDown(e);
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			Diagram?.GestureHandling.HandleKeyUp(e.ToVectorGraphics());

			base.OnKeyUp(e);
		}

		public override void Refresh() => Draw();

		// Unfortunatly Draw might go off twice when making the control bigger,
		// and once when making the control smaller,
		// because making it bigger will trigger a Paint event,
		// while making it smaller does not.
		// Responding to Resize is important if the diagram scales.

		private void DiagramControl_Resize(object sender, EventArgs e) => Draw();

		private void DiagramControl_Paint(object sender, PaintEventArgs e) => Draw();

		private void Draw()
		{
			// TODO: On my laptop it could be null, while on my large desktop PC this does not happen. Strange.
			if (_graphicsBuffer == null)
			{
				return;
			}

			if (Diagram == null)
			{
				_graphicsBuffer.Graphics.Clear(BackColor);
				_graphicsBuffer.DrawBuffer();
				return;
			}

			{
				int heightInPixels = Height;
				if (heightInPixels <= 0) heightInPixels = 1;
				Diagram.Position.HeightInPixels = heightInPixels;
			}

			{
				int widthInPixels = Width;
				if (widthInPixels <= 0) widthInPixels = 1;
				Diagram.Position.WidthInPixels = widthInPixels;
			}

			if (Diagram.Background.Style.BackStyle.Visible)
			{
				BackColor = Color.FromArgb(Diagram.Background.Style.BackStyle.Color);
			}

			Diagram.Recalculate();

			VectorGraphicsDrawer.Draw(Diagram, _graphicsBuffer.Graphics);

			_graphicsBuffer.DrawBuffer();
		}
	}
}
