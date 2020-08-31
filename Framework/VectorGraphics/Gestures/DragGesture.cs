using System;
using JJ.Framework.VectorGraphics.EventArg;
using JJ.Framework.VectorGraphics.Models.Elements;
// ReSharper disable InvertIf
// ReSharper disable UseNullPropagation

namespace JJ.Framework.VectorGraphics.Gestures
{
	/// <inheritdoc />
	public class DragGesture : GestureBase
	{
		/// <summary>
		/// Would go off while a user would be dragging an item
		/// so while user is moving his or her pointer.
		/// </summary>
		public event EventHandler<DraggingEventArgs> Dragging;

		/// <summary>
		/// Would go off if the drag action is cancelled,
		/// in cases like when dragging ends on the Diagram Background
		/// or perhaps when dragging ends over the dragged element itself.
		/// </summary>
		public event EventHandler DragCanceled;

		private readonly MouseMoveGesture _diagramMouseMoveGesture;
		private readonly MouseUpGesture _backgroundMouseUpGesture;

		/// <summary> Also accessed by the DropGesture. </summary>
		internal Element DraggedElement { get; set; }

		/// <summary>
		/// The _diagram field may be determined in a deferred way.
		/// Upon the first mouse down the Diagram of the Element would be used.
		/// Then some sub-Gestures would be hacked into the Diagram and its Background
		/// to make this DragGesture work.
		/// </summary>
		private Diagram _diagram;

		/// <inheritdoc cref="DragGesture" />
		public DragGesture()
		{
			_diagramMouseMoveGesture = new MouseMoveGesture();
			_diagramMouseMoveGesture.MouseMove += Diagram_MouseMove;

			_backgroundMouseUpGesture = new MouseUpGesture();
			_backgroundMouseUpGesture.MouseUp += Background_MouseUp;
		}

		/// <summary>
		/// Would clean up the gestures created privately,
		/// and were tied to the Diagram and the Background.
		/// </summary>
		~DragGesture()
		{
			if (_diagramMouseMoveGesture != null)
			{
				if (_diagram != null)
				{
					if (_diagram.Gestures.Contains(_diagramMouseMoveGesture))
					{
						_diagram.Gestures.Remove(_diagramMouseMoveGesture);
					}
				}

				_diagramMouseMoveGesture.MouseMove -= Diagram_MouseMove;
			}

			if (_backgroundMouseUpGesture != null)
			{
				if (_diagram != null)
				{
					if (_diagram.Background.Gestures.Contains(_backgroundMouseUpGesture))
					{
						_diagram.Background.Gestures.Remove(_backgroundMouseUpGesture);
					}
				}

				_backgroundMouseUpGesture.MouseUp -= Background_MouseUp;
			}
		}

		/// <summary> Would do initializations on the Diagram and start the drag gesture. </summary>
		protected override void HandleMouseDown(object sender, MouseEventArgs e)
		{
			DoInitializeDiagram(e);

			StartDragIfNeeded(e);
		}

		private void Diagram_MouseMove(object sender, MouseEventArgs e) => DoDraggingIfNeeded(sender, e);

		/// <summary>
		/// Would cancel the drag action if DraggedElement is not null.
		/// That would the only condition, which might work just because the DropGesture
		/// sets the DraggedElement to null on time.
		/// </summary>
		protected override void HandleMouseUp(object sender, MouseEventArgs e) => CancelDragIfNeeded(sender);

		/// <inheritdoc cref="HandleMouseUp"/>
		private void Background_MouseUp(object sender, MouseEventArgs e) => CancelDragIfNeeded(sender);

		/// <inheritdoc cref="_diagram" />
		private void DoInitializeDiagram(MouseEventArgs e)
		{
			if (_diagram != null) return;
			if (e.Element?.Diagram == null) return;

			_diagram = e.Element.Diagram;
			_diagram.Gestures.Add(_diagramMouseMoveGesture);
			_diagram.Background.Gestures.Add(_backgroundMouseUpGesture);
		}

		/// <summary> Sets the DraggedElement if e.Element is not null. </summary>
		private void StartDragIfNeeded(MouseEventArgs e)
		{
			if (e.Element == null) return;

			DraggedElement = e.Element;
		}

		/// <summary> Calls the Dragging event if DraggedElement is not null. </summary>
		private void DoDraggingIfNeeded(object sender, MouseEventArgs e)
		{
			if (DraggedElement == null) return;

			Dragging?.Invoke(sender, new DraggingEventArgs(DraggedElement, e.XInPixels, e.YInPixels));
		}

		/// <summary> Cancels the drag if DraggedElement is not null. </summary>
		private void CancelDragIfNeeded(object sender)
		{
			if (DraggedElement == null) return;

			DraggedElement = null;

			DragCanceled?.Invoke(sender, EventArgs.Empty);
		}
	}
}