using System.Collections.Generic;
using JJ.Framework.VectorGraphics.Positioners;

namespace JJ.Framework.WinForms.TestForms
{
	public class FlowPositionerRightAlignedTestForm : PositionerTestFormBase
	{
		protected override IPositioner CreatePositioner(float rowWidth, float rowHeight, float spacing, IList<float> itemWidths) =>
			new FlowPositionerRightAligned(rowWidth, rowHeight, spacing, spacing, itemWidths);
	}
}