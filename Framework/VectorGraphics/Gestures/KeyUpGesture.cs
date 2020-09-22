using System;
using JetBrains.Annotations;
using JJ.Framework.VectorGraphics.EventArg;

namespace JJ.Framework.VectorGraphics.Gestures
{
	/// <inheritdoc />
	[PublicAPI]
	public class KeyUpGesture : GestureBase
	{
		/// <summary> Would go off when a user might let go of a keyboard key. </summary>
		public event EventHandler<KeyEventArgs> KeyUp;

		/// <summary> Would raise the KeyUp event. </summary>
		protected override void HandleKeyUp(object sender, KeyEventArgs e) => KeyUp?.Invoke(sender, e);
	}
}
