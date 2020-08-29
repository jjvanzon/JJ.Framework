using System;
using JetBrains.Annotations;
using JJ.Framework.VectorGraphics.Enums;

namespace JJ.Framework.VectorGraphics.EventArg
{
	/// <summary> Would contain properties that might be passed along with keyboard events. </summary>
	public class KeyEventArgs : EventArgs
	{
		/// <inheritdoc cref="KeyCodeEnum" />
		public KeyCodeEnum KeyCode { get; }

		/// <summary>
		/// Would indicate that the Shift key may be held down, possibly along with another key.
		/// </summary>
		[PublicAPI]
		public bool Shift { get; }

		/// <summary>
		/// Would indicate that the Ctrl key may be held down, possibly along with another key.
		/// </summary>
		[PublicAPI]
		public bool Ctrl { get; }

		/// <summary>
		/// Would indicate that the Alt key may be held down, possibly along with another key.
		/// </summary>
		[PublicAPI]
		public bool Alt { get; }

		/// <inheritdoc cref="KeyEventArgs" />
		/// <param name="keyCode"> See KeyCode property. </param>
		/// <param name="shift"> See Shift property. </param>
		/// <param name="ctrl"> See Ctrl property. </param>
		/// <param name="alt"> See Alt property. </param>
		public KeyEventArgs(KeyCodeEnum keyCode, bool shift, bool ctrl, bool alt)
		{
			KeyCode = keyCode;
			Shift = shift;
			Ctrl = ctrl;
			Alt = alt;
		}
	}
}