using System;
using JJ.Framework.VectorGraphics.EventArg;
using JJ.Framework.VectorGraphics.Helpers;
using JJ.Framework.VectorGraphics.Models.Elements;

// ReSharper disable InvertIf

namespace JJ.Framework.VectorGraphics.Gestures
{
	/// <summary>
	/// A gesture that might be used so that a user may drag elements around on screen.
	/// See GestureBase for more information on using gestures within this vector graphics API.
	/// </summary>
	public class MoveGesture : GestureBase
	{
		/// <summary> Might go off while a user would be moving an element around on screen. </summary>
		public event EventHandler<ElementEventArgs> Moving;

		/// <summary> Might go off right after a user would have been moving an element around on screen. </summary>
		public event EventHandler<ElementEventArgs> Moved;

		private readonly MouseMoveGesture _diagramMouseMoveGesture;

		private float _mouseDownElementRelativeX;
		private float _mouseDownElementRelativeY;
		private float _mouseDownPointerXInPixels;
		private float _mouseDownPointerYInPixels;

		private Diagram _diagram;
		private Element _elementBeingMoved;
		private bool _wasMoved;

		/// <inheritdoc cref="MoveGesture" />
		public MoveGesture()
		{
			_diagramMouseMoveGesture = new MouseMoveGesture();
			_diagramMouseMoveGesture.MouseMove += Diagram_MouseMove;
		}

		/// <summary> Aims to clean up an on-the-fly created diagram-bound mouse move gesture. </summary>
		~MoveGesture()
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
		}

		/// <inheritdoc />
		protected override bool MouseCaptureRequired => true;

		/// <summary>
		/// Might record the diagram of the associated element.
		/// Might set some variables to track an element being moved.
		/// </summary>
		protected override void HandleMouseDown(object sender, MouseEventArgs e)
		{
			DoInitializeDiagram(e);
			DoMouseDown(e);
		}

		/// <inheritdoc cref="DoMouseMove" />
		private void Diagram_MouseMove(object sender, MouseEventArgs e) => DoMouseMove(sender, e);

		/// <inheritdoc cref="DoMouseUp" />
		protected override void HandleMouseUp(object sender, MouseEventArgs e) => DoMouseUp(sender);

		/// <summary>
		/// In case of a mouse event, this method may record the diagram of the associated element.
		/// This may unburden a programmer from passing it along as a parameter.
		/// </summary>
		private void DoInitializeDiagram(MouseEventArgs e)
		{
			if (_diagram != null) return;
			if (e.Element?.Diagram == null) return;

			_diagram = e.Element.Diagram;
			_diagram.Gestures.Add(_diagramMouseMoveGesture);
		}

		/// <summary> Might track some coordinates related to the mouse down and set a Boolean 'was moved'. </summary>
		private void DoMouseDown(MouseEventArgs e)
		{
			if (e.Element == null) return;

			_elementBeingMoved = e.Element;

			_mouseDownElementRelativeX = _elementBeingMoved.Position.X;
			_mouseDownElementRelativeY = _elementBeingMoved.Position.Y;

			_mouseDownPointerXInPixels = e.XInPixels;
			_mouseDownPointerYInPixels = e.YInPixels;

			_wasMoved = false;
		}

		/// <summary>
		/// Would calculate changing (mouse) pointer coordinates and assign a changed position to an element.
		/// This might invoke the Moving event. Also would set a 'was moved' Boolean.
		/// </summary>
		private void DoMouseMove(object sender, MouseEventArgs e)
		{
			if (_elementBeingMoved == null) return;

			float deltaXInPixels = e.XInPixels - _mouseDownPointerXInPixels;
			float deltaYInPixels = e.YInPixels - _mouseDownPointerYInPixels;

			float deltaX = ScaleHelper.PixelsToWidth(_diagram, deltaXInPixels);
			float deltaY = ScaleHelper.PixelsToHeight(_diagram, deltaYInPixels);

			_elementBeingMoved.Position.X = _mouseDownElementRelativeX + deltaX;
			_elementBeingMoved.Position.Y = _mouseDownElementRelativeY + deltaY;

			_wasMoved = true;

			Moving?.Invoke(sender, new ElementEventArgs(_elementBeingMoved));
		}

		/// <summary>
		/// A mouse up event could trigger a moved event. This depends if an element was currently being moved.
		/// Also, some variables would be reset.
		/// </summary>
		private void DoMouseUp(object sender)
		{
			// TODO: I don't know for sure why _element could be null, but it was at one point. 
			// I suspect this happens when you are clicking around very fast and get a race condition,
			// since it is one gesture object for multiple elements.
			if (_elementBeingMoved != null)
			{
				if (_wasMoved)
				{
					Moved?.Invoke(sender, new ElementEventArgs(_elementBeingMoved));
				}
			}

			_elementBeingMoved = null;
			_wasMoved = false; // Not really required, but it seems strange not to set it to false.
		}
	}
}