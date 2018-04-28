using System.Linq;
using System.Windows.Forms;
using JJ.Framework.VectorGraphics.EventArg;
using JJ.Framework.VectorGraphics.Gestures;
using JJ.Framework.VectorGraphics.Models.Elements;
using JJ.Framework.WinForms.TestForms.Helpers;
// ReSharper disable once RedundantUsingDirective
using Label = JJ.Framework.VectorGraphics.Models.Elements.Label;
using MouseEventArgs = JJ.Framework.VectorGraphics.EventArg.MouseEventArgs;

namespace JJ.Framework.WinForms.TestForms
{
	internal partial class GesturesTestForm : Form
	{
		public GesturesTestForm()
		{
			InitializeComponent();

			// ReSharper disable once VirtualMemberCallInConstructor
			Text = GetType().FullName;

			InitializeDiagramAndElements();
		}

		private void InitializeDiagramAndElements()
		{
			var diagram = new Diagram();

			var mouseDownGesture = new MouseDownGesture();
			mouseDownGesture.MouseDown += mouseDownGesture_MouseDown;

			var mouseMoveGesture = new MouseMoveGesture();
			mouseMoveGesture.MouseMove += mouseMoveGesture_MouseMove;

			var mouseUpGesture = new MouseUpGesture();
			mouseUpGesture.MouseUp += mouseUpGesture_MouseUp;

			var mouseLeaveGesture = new MouseLeaveGesture();
			mouseLeaveGesture.MouseLeave += mouseLeaveGesture_MouseLeave;

			var clickGesture = new ClickGesture();
			clickGesture.Click += clickGesture_Click;

			var dragGesture = new DragGesture();
			dragGesture.Dragging += dragGesture_Dragging;

			var dropGesture = new DropGesture(dragGesture);
			dropGesture.Dropped += dropGesture_Dropped;

			DoubleClickGesture doubleClickGesture = diagramControl1.CreateDoubleClickGesture();
			doubleClickGesture.DoubleClick += DoubleClickGesture_DoubleClick;

			// ReSharper disable once JoinDeclarationAndInitializer
			Rectangle rectangle;

			float currentY = VectorGraphicsHelper.SPACING;

			rectangle = VectorGraphicsFactory.CreateRectangle(diagram, "Double Click Me");
			rectangle.Position.Y = currentY;
			rectangle.Gestures.Add(doubleClickGesture);

			currentY += VectorGraphicsHelper.BLOCK_HEIGHT + VectorGraphicsHelper.SPACING;

			rectangle = VectorGraphicsFactory.CreateRectangle(diagram, "Click Me");
			rectangle.Position.Y = currentY;
			rectangle.Gestures.Add(mouseDownGesture);
			rectangle.Gestures.Add(mouseMoveGesture);
			rectangle.Gestures.Add(mouseUpGesture);
			rectangle.Gestures.Add(mouseLeaveGesture);

			currentY += VectorGraphicsHelper.BLOCK_HEIGHT + VectorGraphicsHelper.SPACING;

			rectangle = VectorGraphicsFactory.CreateRectangle(diagram, "Click Me Too");
			rectangle.Position.Y = currentY;
			rectangle.Gestures.Add(clickGesture);

			currentY += VectorGraphicsHelper.BLOCK_HEIGHT + VectorGraphicsHelper.SPACING;

			rectangle = VectorGraphicsFactory.CreateRectangle(diagram, "Move Me");
			rectangle.Position.Y = currentY;
			rectangle.Gestures.Add(new MoveGesture());

			currentY += VectorGraphicsHelper.BLOCK_HEIGHT + VectorGraphicsHelper.SPACING;

			rectangle = VectorGraphicsFactory.CreateRectangle(diagram, "Drag & Drop Me");
			rectangle.Position.Y = currentY;
			rectangle.Gestures.Add(dropGesture);
			rectangle.Gestures.Add(dragGesture);

			currentY += VectorGraphicsHelper.BLOCK_HEIGHT + VectorGraphicsHelper.SPACING;

			rectangle = VectorGraphicsFactory.CreateRectangle(diagram, "Drop & Drop Me");
			rectangle.Position.Y = currentY;
			rectangle.Gestures.Add(dropGesture);
			rectangle.Gestures.Add(dragGesture);

			diagramControl1.Diagram = diagram;
		}

		private void mouseDownGesture_MouseDown(object sender, MouseEventArgs e) => TrySetElementText(e.Element, "MouseDown");
		private void mouseMoveGesture_MouseMove(object sender, MouseEventArgs e) => TrySetElementText(e.Element, "MouseMove");
		private void mouseUpGesture_MouseUp(object sender, MouseEventArgs e) => TrySetElementText(e.Element, "MouseUp");
		private void mouseLeaveGesture_MouseLeave(object sender, MouseEventArgs e) => TrySetElementText(e.Element, "MouseLeave");
		private void clickGesture_Click(object sender, ElementEventArgs e) => TrySetElementText(e.Element, "Clicked");
		private void dragGesture_Dragging(object sender, DraggingEventArgs e) => TrySetElementText(e.ElementBeingDragged, "Dragging");
		private void DoubleClickGesture_DoubleClick(object sender, ElementEventArgs e) => TrySetElementText(e.Element, "DoubleClicked");

		private void dropGesture_Dropped(object sender, DroppedEventArgs e)
		{
			TrySetElementText(e.DraggedElement, "Dragged");
			TrySetElementText(e.DroppedOnElement, "Dropped On");
		}

		private void TrySetElementText(Element element, string text)
		{
			var label = element as Label;
			if (label == null)
			{
				if (element is Rectangle rectangle)
				{
					label = rectangle.Children.OfType<Label>().FirstOrDefault();
				}
			}

			if (label != null)
			{
				label.Text = text;
			}
		}
	}
}