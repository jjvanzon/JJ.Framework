using System;
using JJ.Framework.VectorGraphics.EventArg;

namespace JJ.Framework.VectorGraphics.Gestures
{
	/// <inheritdoc />
	public class MouseUpGesture : GestureBase
	{
		/// <summary> Would go off when a user might let go of a mouse button. </summary>
		public event EventHandler<MouseEventArgs> MouseUp;

		/// <summary> Would raise the MouseUp event. </summary>
		protected override void HandleMouseUp(object sender, MouseEventArgs e) => MouseUp?.Invoke(sender, e);
	}
}
