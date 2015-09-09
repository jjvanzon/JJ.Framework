using JJ.Framework.Presentation.VectorGraphics.Enums;
using JJ.Framework.Reflection.Exceptions;

namespace JJ.Framework.Presentation.WinForms.Extensions
{
    public static class ConversionExtensions
    {
        public static JJ.Framework.Presentation.VectorGraphics.EventArg.KeyEventArgs ToVectorGraphics(this System.Windows.Forms.KeyEventArgs sourceEventArgs)
        {
            if (sourceEventArgs == null) throw new NullException(() => sourceEventArgs);

            var destEventArgs = new JJ.Framework.Presentation.VectorGraphics.EventArg.KeyEventArgs(
                (KeyCodeEnum)sourceEventArgs.KeyValue, 
                sourceEventArgs.Shift,
                sourceEventArgs.Control,
                sourceEventArgs.Alt);

            return destEventArgs;
        }

        public static JJ.Framework.Presentation.VectorGraphics.EventArg.MouseEventArgs ToVectorGraphics(this System.Windows.Forms.MouseEventArgs sourceEventArgs)
        {
            if (sourceEventArgs == null) throw new NullException(() => sourceEventArgs);

            var destEventArgs = new JJ.Framework.Presentation.VectorGraphics.EventArg.MouseEventArgs(
                null, 
                sourceEventArgs.X, 
                sourceEventArgs.Y, 
                sourceEventArgs.Button.ToVectorGraphics());

            return destEventArgs;
        }

        public static JJ.Framework.Presentation.VectorGraphics.Enums.MouseButtonEnum ToVectorGraphics(this System.Windows.Forms.MouseButtons source)
        {
            // Apparently WinForms can pass both the left and right button flags at the same time,
            // but we are not going to handle those situations separately.
            bool isRightButton = source.HasFlag(System.Windows.Forms.MouseButtons.Right);
            if (isRightButton)
            {
                return VectorGraphics.Enums.MouseButtonEnum.Right;
            }

            bool isLeftButton = source.HasFlag(System.Windows.Forms.MouseButtons.Left);
            if (isLeftButton)
            {
                return VectorGraphics.Enums.MouseButtonEnum.Left;
            }

            // Do not make anything crash on any other value than WinForms gives us.
            return VectorGraphics.Enums.MouseButtonEnum.None;
        }
    }
}
