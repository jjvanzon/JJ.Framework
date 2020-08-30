using System.Runtime.CompilerServices;
using JJ.Framework.VectorGraphics.EventArg;

namespace JJ.Framework.VectorGraphics.Gestures
{
	/// <summary>
	/// <para>
	/// A gesture might be something a user could perform,
	/// for instance with a mouse or keyboard or tapping perhaps.
	/// </para>
	/// 
	/// <para>
	/// A derived gesture might have a single event like Click for instance for simplicity.
	/// Sometimes a derived gesture might have properties to control some things
	/// or constructors to initialize some things.
	/// </para>
	/// 
	/// <para>
	/// Using a gesture for the vector graphics would happen by:
	/// 1) Instantiating a Gesture object.
	/// 2) Using its event.
	/// 3) Add it to the Element.Gestures.
	/// 4) Or add it to the Diagram.Gestures.
	/// That way gestures might be assigned specifically to (multiple) Elements
	/// or 'global' gestures might be assigned to the Diagram too.
	/// </para>
	/// 
	/// <para>
	/// The public Internals member would make it possible to not only respond to users,
	/// but trigger events programmatically, mimicking a user.
	/// Similarly, a Diagram.GestureHandling might allow mimicking the user events as well,
	/// but now sending primitive gestures to the Diagram, not specifying a specific Element.
	/// </para>
	/// 
	/// <para>
	/// GestureBase would be the common base type for the Gestures.
	/// One of its aims might be to make implementing a custom Gesture a bit easier,
	/// by offering a set of overrides like HandleMouseDown or HandleKeyUp to pick up basic events.
	/// </para>
	/// </summary>
	public abstract class GestureBase
	{
		/// <inheritdoc cref="GestureBase" />
		public GestureBase() => Internals = new GestureInternals(this);

		/// <summary> Base member does nothing. </summary>
		protected virtual void HandleMouseDown(object sender, MouseEventArgs e) { }

		/// <summary> Base member does nothing. </summary>
		protected virtual void HandleMouseMove(object sender, MouseEventArgs e) { }

		/// <summary> Base member does nothing. </summary>
		protected virtual void HandleMouseUp(object sender, MouseEventArgs e) { }

		/// <summary> Base member does nothing. </summary>
		protected virtual void HandleKeyDown(object sender, KeyEventArgs e) { }

		/// <summary> Base member does nothing. </summary>
		protected virtual void HandleKeyUp(object sender, KeyEventArgs e) { }

		/// <summary>
		/// <para>
		/// Mouse capturing might be for instance when a MouseDown event
		/// would create a certain fixation on the Element.
		/// No matter where the mouse arrow goes,
		/// no matter if it leaves the area of the captured Element,
		/// the events that follow might apply until the mouse button is let go of.
		/// </para>
		///
		/// <para>
		/// The MoveGesture might be an example where MouseCapture is true.
		/// That gesture allows allows moving an Element around on screen,
		/// </para>
		/// </summary>
		protected virtual bool MouseCaptureRequired => false;

		/// <summary>
		/// Would make it possible to not only respond to users,
		/// but trigger events programmatically, mimicking a user.
		/// Similarly, a Diagram.GestureHandling might allow mimicking the user events as well,
		/// but now sending primitive gestures to the Diagram, not specifying a specific Element).
		/// </summary>
		public GestureInternals Internals { get; }

		// These are here for GestureInternals to delegate to, all to make the interface look clean.
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void InternalHandleMouseDown(object sender, MouseEventArgs e) => HandleMouseDown(sender, e);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void InternalHandleMouseMove(object sender, MouseEventArgs e) => HandleMouseMove(sender, e);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void InternalHandleMouseUp(object sender, MouseEventArgs e) => HandleMouseUp(sender, e);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void InternalHandleKeyDown(object sender, KeyEventArgs e) => HandleKeyDown(sender, e);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void InternalHandleKeyUp(object sender, KeyEventArgs e) => HandleKeyUp(sender, e);

		internal bool InternalMouseCaptureRequired
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => MouseCaptureRequired;
		}
	}
}