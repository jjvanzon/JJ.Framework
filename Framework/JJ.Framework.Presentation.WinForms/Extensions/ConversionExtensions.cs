using JJ.Framework.Presentation.Svg.Enums;
using JJ.Framework.Reflection.Exceptions;

namespace JJ.Framework.Presentation.WinForms.Extensions
{
    public static class ConversionExtensions
    {
        public static JJ.Framework.Presentation.Svg.EventArg.KeyEventArgs ToSvg(this System.Windows.Forms.KeyEventArgs sourceEventArgs)
        {
            if (sourceEventArgs == null) throw new NullException(() => sourceEventArgs);

            var destEventArgs = new JJ.Framework.Presentation.Svg.EventArg.KeyEventArgs(
                (KeyCodeEnum)sourceEventArgs.KeyValue, 
                sourceEventArgs.Shift,
                sourceEventArgs.Control,
                sourceEventArgs.Alt);

            return destEventArgs;
        }

        public static JJ.Framework.Presentation.Svg.EventArg.MouseEventArgs ToSvg(this System.Windows.Forms.MouseEventArgs sourceEventArgs)
        {
            if (sourceEventArgs == null) throw new NullException(() => sourceEventArgs);

            var destEventArgs = new JJ.Framework.Presentation.Svg.EventArg.MouseEventArgs(
                null, 
                sourceEventArgs.X, 
                sourceEventArgs.Y, 
                sourceEventArgs.Button.ToSvg());

            return destEventArgs;
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
