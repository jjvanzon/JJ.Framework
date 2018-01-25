using System;
using JJ.Framework.VectorGraphics.EventArg;
using JJ.Framework.VectorGraphics.Helpers;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.Gestures
{
	public class MoveGesture : GestureBase
	{
		public event EventHandler<ElementEventArgs> Moving;
		public event EventHandler<ElementEventArgs> Moved;

		private readonly MouseMoveGesture _diagramMouseMoveGesture;

		private float _mouseDownElementX;
		private float _mouseDownElementY;
		private float _mouseDownPointerXInPixels;
		private float _mouseDownPointerYInPixels;

		private Diagram _diagram;
		private Element _elementBeingMoved;
		private bool _wasMoved;

		public MoveGesture()
		{
			_diagramMouseMoveGesture = new MouseMoveGesture();
			_diagramMouseMoveGesture.MouseMove += _diagram_MouseMove;
		}

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
				_diagramMouseMoveGesture.MouseMove -= _diagram_MouseMove;
			}
		}

		protected override bool MouseCaptureRequired => true;

		protected override void HandleMouseDown(object sender, MouseEventArgs e)
		{
			DoInitializeDiagram(e);
			DoMouseDown(e);
		}

		private void _diagram_MouseMove(object sender, MouseEventArgs e)
		{
			DoMouseMove(sender, e);
		}

		protected override void HandleMouseUp(object sender, MouseEventArgs e)
		{
			DoMouseUp(sender);
		}

		private void DoInitializeDiagram(MouseEventArgs e)
		{
			if (e.Element != null)
			{
				if (_diagram == null)
				{
					if (e.Element.Diagram != null)
					{
						_diagram = e.Element.Diagram;
						_diagram.Gestures.Add(_diagramMouseMoveGesture);
					}
				}
			}
		}

		private void DoMouseDown(MouseEventArgs e)
		{
			if (e.Element != null)
			{
				_elementBeingMoved = e.Element;

				_mouseDownElementX = _elementBeingMoved.Position.X;
				_mouseDownElementY = _elementBeingMoved.Position.Y;

				_mouseDownPointerXInPixels = e.XInPixels;
				_mouseDownPointerYInPixels = e.YInPixels;

				_wasMoved = false;
			}
		}

		private void DoMouseMove(object sender, MouseEventArgs e)
		{
			if (_elementBeingMoved != null)
			{
				float deltaXInPixels = e.XInPixels - _mouseDownPointerXInPixels;
				float deltaYInPixels = e.YInPixels - _mouseDownPointerYInPixels;

				float deltaX = ScaleHelper.PixelsToWidth(_diagram, deltaXInPixels);
				float deltaY = ScaleHelper.PixelsToHeight(_diagram, deltaYInPixels);

				_elementBeingMoved.Position.X = _mouseDownElementX + deltaX;
				_elementBeingMoved.Position.Y = _mouseDownElementY + deltaY;

				_wasMoved = true;

				Moving?.Invoke(sender, new ElementEventArgs(_elementBeingMoved));
			}
		}

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
			_wasMoved = false; // Not really required, but it seems weird not to set it to false.
		}
	}
}