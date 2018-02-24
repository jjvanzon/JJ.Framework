using System.Collections.Generic;
using JJ.Framework.VectorGraphics.Positioners;

namespace JJ.Framework.WinForms.TestForms
{
	public class FlowPositionerLeftAlignedTestForm : PositionerTestFormBase
	{
		protected override IPositioner CreatePositioner(float rowWidth, float rowHeight, float spacing, IList<float> itemWidths) =>
			new FlowPositionerLeftAligned(rowWidth, rowHeight, spacing, spacing, itemWidths);
	}
}