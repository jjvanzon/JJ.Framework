namespace JJ.Framework.VectorGraphics.Models.PictureOperators
{
	public abstract class PictureOperator
	{
		public PictureOperator Input { get; set; }

		public object Output => GetOutput();

		public abstract object GetOutput(bool useCache = true);

	}
}
