using System;
using JJ.Framework.Mathematics;
using JJ.Framework.VectorGraphics.EventArg;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.Gestures
{
	/// <inheritdoc />
	public class ClickGesture : GestureBase
	{
		/// <summary> Goes off when a user clicked an element, </summary>
		public event EventHandler<ElementEventArgs> Click;

		private Element _mouseDownElement;

		/// <inheritdoc />
		protected override bool MouseCaptureRequired => true;

		/// <summary>
		/// For the Clicked event to be triggered, the cursor should be over the same element
		/// upon both mouse down as well as mouse up.
		/// </summary>
		protected override void HandleMouseDown(object sender, MouseEventArgs e)
		{
			if (Click == null) return;

			if (sender is Element element)
			{
				_mouseDownElement = element;
			}
		}

		/// <inheritdoc cref="HandleMouseDown" />
		protected override void HandleMouseUp(object sender, MouseEventArgs e)
		{
			if (Click == null) return;

			if (_mouseDownElement != null)
			{
				bool mouseDownElementIsHit = Geometry.IsInRectangle(
					e.XInPixels, 
					e.YInPixels,
					_mouseDownElement.CalculatedValues.XInPixels,
					_mouseDownElement.CalculatedValues.YInPixels,
					_mouseDownElement.CalculatedValues.XInPixels + _mouseDownElement.CalculatedValues.WidthInPixels,
					_mouseDownElement.CalculatedValues.YInPixels + _mouseDownElement.CalculatedValues.HeightInPixels);

				if (mouseDownElementIsHit)
				{
					Click(sender, new ElementEventArgs(e.Element));
				}
			}
		}
	}
}
