using JJ.Framework.Presentation.Svg.Enums;
using System;

namespace JJ.Framework.Presentation.Svg.EventArg
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

        public KeyCodeEnum KeyCode { get; set; }
        public bool Shift { get; set; }
        public bool Ctrl { get; set; }
        public bool Alt { get; set; }
    }
}
