using System;
using JJ.Framework.Business;
using JJ.Framework.Exceptions;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;

namespace JJ.Framework.Presentation.VectorGraphics.SideEffects
{
	internal class SideEffect_AssertCannotChangeBackGroundDiagram : ISideEffect
	{
		private readonly Diagram _diagram;
		private readonly Element _element;

		/// <param name="diagram">nullable</param>
		public SideEffect_AssertCannotChangeBackGroundDiagram(Element element, Diagram diagram)
		{
			_diagram = diagram;
			_element = element ?? throw new NullException(() => element);
		}

		public void Execute()
		{
			if (_diagram == null)
			{
				return;
			}

			bool isBackGroundElement = _element == _diagram.Background;
			if (isBackGroundElement)
			{
				// Can only set background element once in the Diagram's constructor.
				throw new Exception("Cannot change Background element's Diagram.");
			}
		}
	}
}