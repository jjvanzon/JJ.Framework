namespace JJ.Framework.VectorGraphics.Helpers
{
	/// <summary>
	/// JJ.Framework.VectorGraphics does not work with pictures directly,
	/// but borrows that from e.g. System.Drawing.
	/// JJ.Framework.Drawing implements an IUnderlyingPictureWrapper
	/// that can actually return the System.Drawing.Bitmap.
	/// </summary>
	public interface IUnderlyingPictureWrapper { }
}