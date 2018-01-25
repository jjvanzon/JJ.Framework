using System;
using JJ.Framework.VectorGraphics.Enums;

namespace JJ.Framework.VectorGraphics.EventArg
{
	public class KeyEventArgs : EventArgs
	{
		public KeyEventArgs(KeyCodeEnum keyCode, bool shift, bool ctrl, bool alt)
		{
			KeyCode = keyCode;
			Shift = shift;
			Ctrl = ctrl;
			Alt = alt;
		}

		public KeyCodeEnum KeyCode { get; }
		public bool Shift { get; }
		public bool Ctrl { get; }
		public bool Alt { get; }
	}
}
