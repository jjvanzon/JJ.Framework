using JJ.Framework.VectorGraphics.Positioners;

namespace JJ.Framework.WinForms.TestForms
{
	public class FlowPositionerLeftAlignedTestForm : PositionerTestFormBase
	{
		protected override IPositioner CreatePositioner() =>
			new FlowPositionerLeftAligned(diagramControl.Width, ROW_HEIGHT, _itemWidths);
	}
}