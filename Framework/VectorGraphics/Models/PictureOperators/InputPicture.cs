using System;

namespace JJ.Framework.VectorGraphics.Models.PictureOperators
{
	public class InputPicture : PictureOperator
	{
		public object UnderlyingPicture { get; set; }

		public override object GetOutput(bool useCache = true)
		{
			if (UnderlyingPicture == null) throw new ArgumentNullException(nameof(UnderlyingPicture));
			return UnderlyingPicture;
		}
	}
}
