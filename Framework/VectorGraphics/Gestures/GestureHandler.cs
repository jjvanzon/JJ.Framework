using System.Collections.Generic;
using System.Linq;
using JJ.Framework.Exceptions;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Mathematics;
using JJ.Framework.VectorGraphics.EventArg;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.Gestures
{
	internal class GestureHandler
	{
		private readonly Diagram _diagram;
		private Element _mouseCapturingElement;

		public GestureHandler(Diagram diagram)
		{
			_diagram = diagram ?? throw new NullException(() => diagram);

			InitializeMouseMoveGesture();
		}

		~GestureHandler()
		{
			FinalizeMouseMoveGesture();
		}

		// MouseDown

		public void HandleMouseDown(MouseEventArgs e)
		{
			_mouseMoveGesture.Internals.HandleMouseDown(this, e);

			IEnumerable<Element> zOrdereredElements = _diagram.ElementsOrderedByZIndex;

			Element hitElement = TryGetHitElement(zOrdereredElements, e.XInPixels, e.YInPixels);

			if (hitElement != null)
			{
				var e2 = new MouseEventArgs(hitElement, e.XInPixels, e.YInPixels, e.MouseButtonEnum);

				foreach (GestureBase diagramGesture in _diagram.Gestures.ToArray())
				{
					diagramGesture.Internals.HandleMouseDown(hitElement, e);
				}

				foreach (GestureBase gesture in hitElement.Gestures.ToArray()) // The ToArray is a safety measure in case delegates modify the gesture collection.
				{
					gesture.Internals.HandleMouseDown(hitElement, e2);
				}

				TryBubbleMouseDown(hitElement, hitElement, e);

				if (hitElement.Gestures.Any(x => x.Internals.MouseCaptureRequired))
				{
					_mouseCapturingElement = hitElement;
				}
			}
		}

		private void TryBubbleMouseDown(Element sender, Element child, MouseEventArgs e)
		{
			Element parent = child.Parent;

			if (parent == null)
			{
				return;
			}

			if (!parent.CalculatedValues.Enabled)
			{
				return;
			}

			if (!child.MustBubble)
			{
				return;
			}

			var e2 = new MouseEventArgs(parent, e.XInPixels, e.YInPixels, e.MouseButtonEnum);

			foreach (GestureBase gesture in parent.Gestures.ToArray()) // The ToArray is a safety measure in case delegates modify the gesture collection.
			{
				gesture.Internals.HandleMouseDown(sender, e2);
			}

			TryBubbleMouseDown(sender, parent, e);

			if (parent.Gestures.Any(x => x.Internals.MouseCaptureRequired))
			{
				_mouseCapturingElement = child;
			}
		}

		// MouseMove

		/// <summary>
		/// In WinForms a mouse move will go off upon mouse down, even though you did not even move the mouse at all
		/// All gestures have trouble with this if you do not solve it at this level.
		/// </summary>
		private GestureBase _mouseMoveGesture;

		private void InitializeMouseMoveGesture()
		{
			var mouseMoveGesture = new MouseMoveGesture();
			mouseMoveGesture.MouseMove += mouseMoveGesture_MouseMove;
			_mouseMoveGesture = mouseMoveGesture;
		}

		private void FinalizeMouseMoveGesture()
		{
			if (_mouseMoveGesture != null)
			{
				var mouseMoveGesture = (MouseMoveGesture)_mouseMoveGesture;
				mouseMoveGesture.MouseMove -= mouseMoveGesture_MouseMove;
			}
		}

		public void HandleMouseMove(MouseEventArgs e)
		{
			_mouseMoveGesture.Internals.HandleMouseMove(this, e);
		}

		private void mouseMoveGesture_MouseMove(object sender, MouseEventArgs e)
		{
			IEnumerable<Element> zOrdereredElements = _diagram.ElementsOrderedByZIndex;
		
			Element hitElement = _mouseCapturingElement ?? TryGetHitElement(zOrdereredElements, e.XInPixels, e.YInPixels);

			if (hitElement != null)
			{
				var e2 = new MouseEventArgs(hitElement, e.XInPixels, e.YInPixels, e.MouseButtonEnum);

				foreach (GestureBase diagramGesture in _diagram.Gestures.ToArray())
				{
					diagramGesture.Internals.HandleMouseMove(hitElement, e2);
				}

				foreach (GestureBase gesture in hitElement.Gestures.ToArray()) // The ToArray is a safety measure in case delegates modify the gesture collection.
				{
					gesture.Internals.HandleMouseMove(hitElement, e2);
				}

				TryBubbleMouseMove(hitElement, hitElement, e);
			}
		}

		private void TryBubbleMouseMove(object sender, Element child, MouseEventArgs e)
		{
			if (!child.MustBubble)
			{
				return;
			}

			Element parent = child.Parent;

			if (child.Parent == null)
			{
				return;
			}

			if (!child.Parent.CalculatedValues.Enabled)
			{
				return;
			}

			var e2 = new MouseEventArgs(parent, e.XInPixels, e.YInPixels, e.MouseButtonEnum);

			foreach (GestureBase gesture in parent.Gestures.ToArray()) // The ToArray is a safety measure in case delegates modify the gesture collection.
			{
				gesture.Internals.HandleMouseMove(sender, e2);
			}

			TryBubbleMouseMove(sender, parent, e);
		}

		// MouseUp

		public void HandleMouseUp(MouseEventArgs e)
		{
			_mouseMoveGesture.Internals.HandleMouseUp(this, e);

			IEnumerable<Element> zOrdereredElements = _diagram.ElementsOrderedByZIndex;

			Element hitElement = _mouseCapturingElement ?? TryGetHitElement(zOrdereredElements, e.XInPixels, e.YInPixels);

			if (hitElement != null)
			{
				var e2 = new MouseEventArgs(hitElement, e.XInPixels, e.YInPixels, e.MouseButtonEnum);

				foreach (GestureBase diagramGesture in _diagram.Gestures.ToArray())
				{
					diagramGesture.Internals.HandleMouseUp(hitElement, e2);
				}

				foreach (GestureBase gesture in hitElement.Gestures.ToArray()) // The ToArray is a safety measure in case delegates modify the gesture collection.
				{
					gesture.Internals.HandleMouseUp(hitElement, e2);
				}

				TryBubbleMouseUp(hitElement, hitElement, e);
			}

			_mouseCapturingElement = null;
		}

		private void TryBubbleMouseUp(Element sender, Element child, MouseEventArgs e)
		{
			if (!child.MustBubble)
			{
				return;
			}

			Element parent = child.Parent;

			if (parent == null)
			{
				return;
			}

			if (!parent.CalculatedValues.Enabled)
			{
				return;
			}

			var e2 = new MouseEventArgs(parent, e.XInPixels, e.YInPixels, e.MouseButtonEnum);

			foreach (GestureBase gesture in parent.Gestures.ToArray()) // The ToArray is a safety measure in case delegates modify the gesture collection.
			{
				gesture.Internals.HandleMouseUp(sender, e2);
			}

			TryBubbleMouseUp(sender, parent, e);
		}

		// Key Events

		public void HandleKeyDown(KeyEventArgs e)
		{
			foreach (GestureBase gesture in _diagram.Gestures.ToArray())
			{
				gesture.Internals.HandleKeyDown(_diagram, e);
			}

			foreach (GestureBase gesture in _diagram.Background.Gestures.ToArray()) // The ToArray is a safety measure in case delegates modify the gesture collection.
			{
				gesture.Internals.HandleKeyDown(_diagram.Background, e);
			}
		}

		public void HandleKeyUp(KeyEventArgs e)
		{
			foreach (GestureBase gesture in _diagram.Gestures.ToArray())
			{
				gesture.Internals.HandleKeyUp(_diagram, e);
			}

			foreach (GestureBase gesture in _diagram.Background.Gestures.ToArray()) // The ToArray is a safety measure in case delegates modify the gesture collection.
			{
				gesture.Internals.HandleKeyUp(_diagram.Background, e);
			}
		}

		// Hit Testing

		private Element TryGetHitElement(IEnumerable<Element> zOrderedElements, float pointerXInPixels, float pointerYInPixels)
		{
			foreach (Element element in zOrderedElements.Reverse())
			{
				if (!element.CalculatedValues.Enabled)
				{
					continue;
				}

				bool isInRectangle = Geometry.IsInRectangle(
					pointerXInPixels, 
					pointerYInPixels,
					element.CalculatedValues.XInPixels, 
					element.CalculatedValues.YInPixels,
					element.CalculatedValues.XInPixels + element.CalculatedValues.WidthInPixels, 
					element.CalculatedValues.YInPixels + element.CalculatedValues.HeightInPixels);

				if (isInRectangle)
				{
					return element;
				}
			}

			return null;
		}
	}
}
