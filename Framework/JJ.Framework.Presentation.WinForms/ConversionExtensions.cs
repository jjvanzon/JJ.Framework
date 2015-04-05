using JJ.Framework.Common;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.WinForms
{
    public static class ConversionExtensions
    {
        public static JJ.Framework.Presentation.Svg.EventArg.MouseEventArgs ToSvg(this System.Windows.Forms.MouseEventArgs source)
        {
            if (source == null) throw new NullException(() => source);

            var dest = new JJ.Framework.Presentation.Svg.EventArg.MouseEventArgs(null, source.X, source.Y, source.Button.ToSvg());

            return dest;
        }

        public static JJ.Framework.Presentation.Svg.Enums.MouseButtonEnum ToSvg(this System.Windows.Forms.MouseButtons source)
        {
            // Apparently WinForms can pass both the left and right button flags at the same time,
            // but we are not going to handle those situations separately.
            bool isRightButton = source.HasFlag(System.Windows.Forms.MouseButtons.Right);
            if (isRightButton)
            {
                return Svg.Enums.MouseButtonEnum.Right;
            }

            bool isLeftButton = source.HasFlag(System.Windows.Forms.MouseButtons.Left);
            if (isLeftButton)
            {
                return Svg.Enums.MouseButtonEnum.Left;
            }

            // Do not make anything crash on any other value than WinForms gives us.
            return Svg.Enums.MouseButtonEnum.None;
        }
    }
}
