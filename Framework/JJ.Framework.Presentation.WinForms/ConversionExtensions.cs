using JJ.Framework.Common;
using JJ.Framework.Reflection;
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

            var dest = new JJ.Framework.Presentation.Svg.EventArg.MouseEventArgs
            {
                X = source.X,
                Y = source.Y,
                MouseButtonEnum = source.Button.ToSvg()
            };

            return dest;
        }

        public static JJ.Framework.Presentation.Svg.Enums.MouseButtonEnum ToSvg(this System.Windows.Forms.MouseButtons source)
        {
            switch (source)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    return Svg.Enums.MouseButtonEnum.Left;

                case System.Windows.Forms.MouseButtons.Right:
                    return Svg.Enums.MouseButtonEnum.Right;

                case System.Windows.Forms.MouseButtons.None:
                    return Svg.Enums.MouseButtonEnum.None;

                default:
                    throw new ValueNotSupportedException(source);
            }
        }
    }
}
