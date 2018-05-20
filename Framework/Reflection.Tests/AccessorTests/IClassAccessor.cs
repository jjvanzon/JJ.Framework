// ReSharper disable UnusedMemberInSuper.Global
namespace JJ.Framework.Reflection.Tests.AccessorTests
{
	/// <summary>
	/// Gives the two accessors (using strings and using expressions)
	/// a single interface, so we can execute the same test code on them.
	/// Only works for instance members, not status ones.
	/// </summary>
	public interface IClassAccessor
	{
		// ReSharper disable once InconsistentNaming
		int _field { get; set; }
		int Property { get; set; }
		void VoidMethod();
		void VoidMethodInt(int parameter);
		void VoidMethodIntInt(int parameter1, int parameter2);
		int IntMethod();
		int IntMethodInt(int parameter);
		int IntMethodIntInt(int parameter1, int parameter2);
		int this[int index]  { get; set; }
		string this[string key] { get; set; }
	}
}
