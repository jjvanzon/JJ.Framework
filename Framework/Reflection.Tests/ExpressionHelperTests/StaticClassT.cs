// ReSharper disable UnusedMember.Global
// ReSharper disable StaticMemberInGenericType
// ReSharper disable UnusedTypeParameter
// ReSharper disable UnusedParameter.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global

namespace JJ.Framework.Reflection.Tests.ExpressionHelperTests
{
	internal static class StaticClass<T>
	{
		public static string Name { get; set; }
		public static int Index { get; set; }
		public static Item Parent { get; set; }
		public static ComplexItem ComplexItem => new ComplexItem();
		public static string _field = "FieldResult";
		public static string Property => "PropertyResult";
		public static int[] Array { get; } = { 10, 11, 12 };
		public static string MethodWithoutParameter() => "MethodWithoutParameterResult";
		public static string MethodWithParameter(int parameter) => "MethodWithParameterResult";
		public static string MethodWithParams(params int[] array) => "MethodWithParamsResult";
	}
}