using System;
using JJ.Framework.Business;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.SideEffects
{
	internal class SideEffect_AssertCannotRemoveBackgroundFromDiagram : ISideEffect
	{
		private readonly Element _element;

		public SideEffect_AssertCannotRemoveBackgroundFromDiagram(Element element) => _element = element ?? throw new NullException(() => element);

	    public void Execute()
		{
			if (_element == _element.Diagram.Background)
			{
				throw new Exception("Cannot remove Background Element from Diagram.");
			}
		}
	}
}
