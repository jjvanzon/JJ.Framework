﻿using JJ.Framework.Presentation.Svg.EventArg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Gestures
{
    public class KeyUpGesture : GestureBase
    {
        public EventHandler<KeyEventArgs> KeyUp;

        public override void HandleKeyUp(object sender, EventArg.KeyEventArgs e)
        {
            if (KeyUp != null)
            {
                KeyUp(sender, e);
            }
        }
    }
}