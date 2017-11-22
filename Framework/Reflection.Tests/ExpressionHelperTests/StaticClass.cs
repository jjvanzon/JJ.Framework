namespace JJ.Framework.Reflection.Tests.ExpressionHelperTests
{
	internal static class StaticClass
	{
		public static string Name { get; set; }
		public static int Index { get; set; }

		public static Item Parent { get; set; }

		public static ComplexItem ComplexItem
		{
			get { return new ComplexItem(); }
		}

		public static string _field = "FieldResult";

		public static string Property
		{
			get { return "PropertyResult"; }
		}

		private static readonly int[] _array = { 10, 11, 12 };
		public static int[] Array
		{
			get { return _array; }
		}

		public static string MethodWithoutParameter()
		{
			return "MethodWithoutParameterResult";
		}

		public static string MethodWithParameter(int parameter)
		{
			return "MethodWithParameterResult";
		}

		public static string MethodWithParams(params int[] array)
		{
			return "MethodWithParamsResult";
		}
	}
}
