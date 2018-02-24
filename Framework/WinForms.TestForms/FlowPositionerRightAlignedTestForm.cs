using JJ.Framework.VectorGraphics.Positioners;

namespace JJ.Framework.WinForms.TestForms
{
	public class FlowPositionerRightAlignedTestForm : PositionerTestFormBase
	{
		protected override IPositioner CreatePositioner() =>
			new FlowPositionerRightAligned(diagramControl.Width, ROW_HEIGHT, _itemWidths);
	}
}