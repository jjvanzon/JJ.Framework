namespace JJ.Framework.VectorGraphics.Models.Styling
{
	public class PictureStyle
	{
		/// <summary>
		/// If false, will draw remaining picture content outside if the rectangle, without cutting it off.
		/// If true, will cut off pieces of the picture that do not fit inside the rectangle.
		/// </summary>
		public bool Clip { get; set; }
	}
}
