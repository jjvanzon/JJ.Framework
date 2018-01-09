using JJ.Framework.Exceptions;
using JJ.Framework.Presentation.VectorGraphics.EventArg;

namespace JJ.Framework.Presentation.VectorGraphics.Gestures
{
	/// <summary>
	/// This class is for GestureBase to hide these internal workings from the main interface,
	/// to keep the main interface clean.
	/// </summary>
	public class GestureInternals
	{
		private readonly GestureBase _gestureBase;

		internal GestureInternals(GestureBase gestureBase)
		{
			_gestureBase = gestureBase ?? throw new NullException(() => gestureBase);
		}

		public void HandleMouseDown(object sender, MouseEventArgs e) => _gestureBase.InternalHandleMouseDown(sender, e);
		public void HandleMouseMove(object sender, MouseEventArgs e) => _gestureBase.InternalHandleMouseMove(sender, e);
		public void HandleMouseUp(object sender, MouseEventArgs e) => _gestureBase.InternalHandleMouseUp(sender, e);
		public void HandleKeyDown(object sender, KeyEventArgs e) => _gestureBase.InternalHandleKeyDown(sender, e);
		public void HandleKeyUp(object sender, KeyEventArgs e) => _gestureBase.InternalHandleKeyUp(sender, e);

		/// <summary>
		/// Tells if mouse down makes the control receive all mouse events
		/// until mouse up. This prevents mouse events from
		/// reaching other elements, even when going outside the capturing element's rectangle.
		/// </summary>
		public bool MouseCaptureRequired => _gestureBase.InternalMouseCaptureRequired;
	}
}
