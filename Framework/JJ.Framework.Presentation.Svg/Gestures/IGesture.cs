using JJ.Framework.Presentation.Svg.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Gestures
{
    public interface IGesture
    {
        void MouseDown(MouseDownInfo info);
        void MouseMove(MouseDownInfo info);
        void MouseUp(MouseDownInfo info);
    }
}
