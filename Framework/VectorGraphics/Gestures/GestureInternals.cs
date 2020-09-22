using JetBrains.Annotations;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.VectorGraphics.EventArg;

namespace JJ.Framework.VectorGraphics.Gestures
{
	/// <summary>
	/// <para>
	/// This class is for GestureBase to try and hide these internal workings from the main interface,
	/// in an attempt to keep the main interface clean. This may happen in a bit of an elaborated way.
	/// </para>
	/// <para> GestureHandler may call: </para>
	/// <para> * GestureBase.GestureInternals, which are internal as a trick to try and isolate these members, </para>
	/// <para> which delegates back to: </para>
	/// <para> * GestureBase.InternalHandle... methods that are internal. </para>
	/// <para> which delegate to: </para>
	/// <para> * GestureBase.Handle... that are protected, which are implemented inside a derived Gesture class. </para>
	/// </summary>
	public class GestureInternals
	{
		private readonly GestureBase _gestureBase;

		/// <inheritdoc cref="GestureInternals" />
		internal GestureInternals(GestureBase gestureBase) => _gestureBase = gestureBase ?? throw new NullException(() => gestureBase);

		/// <summary> Would emulate a user's using the mouse or keyboard. </summary>
		/// <param name="sender"></param>
		/// <param name="e">
		/// May specify coordinates, buttons, keys and an involved element if applicable.
		/// </param>
		public void HandleMouseDown(object sender, MouseEventArgs e) => _gestureBase.InternalHandleMouseDown(sender, e);

		/// <inheritdoc cref="HandleMouseDown" />
		public void HandleMouseMove(object sender, MouseEventArgs e) => _gestureBase.InternalHandleMouseMove(sender, e);

		/// <inheritdoc cref="HandleMouseDown" />
		public void HandleMouseUp(object sender, MouseEventArgs e) => _gestureBase.InternalHandleMouseUp(sender, e);

		/// <inheritdoc cref="HandleMouseDown" />
		[PublicAPI]
		public void HandleKeyDown(object sender, KeyEventArgs e) => _gestureBase.InternalHandleKeyDown(sender, e);

		/// <inheritdoc cref="HandleMouseDown" />
		[PublicAPI]
		public void HandleKeyUp(object sender, KeyEventArgs e) => _gestureBase.InternalHandleKeyUp(sender, e);

		/// <summary>
		/// Tells if mouse down makes the control receive all mouse events
		/// until mouse up. This prevents mouse events from
		/// reaching other elements, even when going outside the capturing element's rectangle.
		/// </summary>
		[PublicAPI]
		public bool MouseCaptureRequired => _gestureBase.InternalMouseCaptureRequired;
	}
}
