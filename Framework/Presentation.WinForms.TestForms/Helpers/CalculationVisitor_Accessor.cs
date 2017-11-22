using System.Collections.Generic;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Reflection;

namespace JJ.Framework.Presentation.WinForms.TestForms.Helpers
{
	internal class CalculationVisitor_Accessor
	{
		private readonly Accessor _accessor;

		public CalculationVisitor_Accessor()
		{
			_accessor = new Accessor("JJ.Framework.Presentation.VectorGraphics.Visitors.CalculationVisitor, JJ.Framework.Presentation.VectorGraphics");
		}

		public IList<Element> Execute(Diagram diagram)
		{
			return (IList<Element>)_accessor.InvokeMethod("Execute", diagram);
		}
	}
}
