using System;
using System.Drawing;
using JJ.Framework.VectorGraphics.Helpers;

namespace JJ.Framework.Drawing
{
	/// <inheritdoc />
	public class UnderlyingPictureWrapper : IUnderlyingPictureWrapper
	{
		private Bitmap _bitmap;

		public Bitmap Bitmap
		{
			get => _bitmap ?? throw new ArgumentNullException(nameof(Bitmap));
			set => _bitmap = value ?? throw new ArgumentNullException(nameof(Bitmap));
		}
	}
}