using JJ.Framework.Exceptions;

namespace JJ.Framework.Presentation.WinForms.Extensions
{
	public static class ConversionExtensions
	{
		public static VectorGraphics.EventArg.KeyEventArgs ToVectorGraphics(
				 this System.Windows.Forms.KeyEventArgs sourceEventArgs)
		{
			if (sourceEventArgs == null) throw new NullException(() => sourceEventArgs);

			var destEventArgs = new VectorGraphics.EventArg.KeyEventArgs(
				(VectorGraphics.Enums.KeyCodeEnum)sourceEventArgs.KeyValue, 
				sourceEventArgs.Shift,
				sourceEventArgs.Control,
				sourceEventArgs.Alt);

			return destEventArgs;
		}

		public static VectorGraphics.EventArg.MouseEventArgs ToVectorGraphics(
				 this System.Windows.Forms.MouseEventArgs sourceEventArgsInPixels)
		{
			if (sourceEventArgsInPixels == null) throw new NullException(() => sourceEventArgsInPixels);

			var destEventArgs = new VectorGraphics.EventArg.MouseEventArgs(
				null,
				sourceEventArgsInPixels.X, 
				sourceEventArgsInPixels.Y, 
				sourceEventArgsInPixels.Button.ToVectorGraphics());

			return destEventArgs;
		}

		public static VectorGraphics.Enums.MouseButtonEnum ToVectorGraphics(this System.Windows.Forms.MouseButtons source)
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
