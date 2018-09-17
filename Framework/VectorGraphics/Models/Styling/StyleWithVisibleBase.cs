namespace JJ.Framework.VectorGraphics.Models.Styling
{
	public abstract class StyleWithVisibleBase
	{
		/// <summary>
		/// Visible = false effectively means Enabled = false.
		/// (You will not see that in the Enabled property. You will see that in the CalculatedValues.Enabled property.)
		/// If you want to receive events from an invisible element, use the Visible property of the style objects instead.
		/// </summary>
		public bool Visible { get; set; } = true;
	}
}
