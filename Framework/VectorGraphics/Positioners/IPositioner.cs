using System.Collections.Generic;

namespace JJ.Framework.VectorGraphics.Positioners
{
	public interface IPositioner
	{
		IList<(float x, float y, float width, float height)> Calculate();
	}
}