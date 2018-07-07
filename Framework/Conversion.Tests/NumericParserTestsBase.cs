using System;
using System.Globalization;
using JJ.Framework.Common;
using JJ.Framework.Testing;
// ReSharper disable StaticMemberInGenericType

namespace JJ.Framework.Conversion.Tests
{
	public abstract class NumericParserTestsBase<T>
		where T : struct
	{
		private const string WHITE_SPACE = " ";
		private const string INVALID_NUMBER = "qwerqwer";

		private static readonly CultureInfo _nlNLCulture = new CultureInfo("nl-NL");
		private static readonly CultureInfo _enUSCulture = new CultureInfo("en-US");

		protected abstract NumberStyles NormalNumberStyles { get; }
		protected abstract string NormalNumberStringEnUS { get; }
		protected abstract string NormalNumberStringNlNL { get; }
		protected abstract T NormalNumber { get; }

		protected abstract NumberStyles SpecialNumberStyles { get; }
		protected abstract string NumberWithSpecialNumberStylesStringEnUS { get; }
		protected abstract string NumberWithSpecialNumberStylesStringNlNL { get; }
		protected abstract T NumberWithSpecialNumberStyles { get; }

		protected abstract NumberStyles GetDefaultNumberStyles();
		protected abstract bool TryParse(string str, out T? number);
		protected abstract bool TryParse(string str, NumberStyles styles, out T? number);
		protected abstract bool TryParse(string str, IFormatProvider provider, out T number);
		protected abstract bool TryParse(string str, IFormatProvider provider, out T? number);
		protected abstract bool TryParse(string str, NumberStyles styles, IFormatProvider provider, out T? number);
		protected abstract T? ParseNullable(string str);
		protected abstract T? ParseNullable(string str, NumberStyles styles);
		protected abstract T? ParseNullable(string str, IFormatProvider provider);
		protected abstract T? ParseNullable(string str, NumberStyles styles, IFormatProvider provider);

		protected void Test_DEFAULT_NUMBER_STYLES()
		{
			AssertHelper.AreEqual(NormalNumberStyles, () => GetDefaultNumberStyles());
		}

		protected void Test_TryParse_NotNullable_HasValue_WithFormatProvider()
		{
			WithEnUSCulture(
				() =>
				{
					bool success = TryParse(NormalNumberStringNlNL, _nlNLCulture, out T number);

					AssertHelper.IsTrue(() => success);
					AssertHelper.IsNotNull(() => number);
					AssertHelper.AreEqual(NormalNumber, () => number);
				});
		}

		protected void Test_TryParse_NotNullable_IsWhiteSpace_WithFormatProvider()
		{
			WithEnUSCulture(
				() =>
				{
					bool success = TryParse(WHITE_SPACE, _nlNLCulture, out T number);

					AssertHelper.IsFalse(() => success);
					AssertHelper.AreEqual(default(T), () => number);
				});
		}

		protected void Test_TryParse_NotNullable_IsInvalidNumber_WithFormatProvider()
		{
			WithEnUSCulture(
				() =>
				{
					bool success = TryParse(INVALID_NUMBER, _nlNLCulture,  out T number);

					AssertHelper.IsFalse(() => success);
					AssertHelper.AreEqual(default(T), () => number);
				});
		}

		protected void Test_TryParse_Nullable_HasValue()
		{
			WithEnUSCulture(
				() =>
				{
					bool success = TryParse(NormalNumberStringEnUS, out T? number);

					AssertHelper.IsTrue(() => success);
					AssertHelper.IsNotNull(() => number);
					AssertHelper.AreEqual(NormalNumber, () => number);
				});
		}

		protected void Test_TryParse_Nullable_IsNull()
		{
			WithEnUSCulture(
				() =>
				{
					bool success = TryParse(WHITE_SPACE, out T? number);

					AssertHelper.IsTrue(() => success);
					AssertHelper.IsNull(() => number);
				});
		}

		protected void Test_TryParse_Nullable_IsInvalid()
		{
			WithEnUSCulture(
				() =>
				{
					bool success = TryParse(INVALID_NUMBER, out T? number);

					AssertHelper.IsFalse(() => success);
					AssertHelper.IsNull(() => number);
				});
		}

		protected void Test_TryParse_Nullable_HasValue_WithNumberStyles()
		{
			WithEnUSCulture(
				() =>
				{
					bool success = TryParse(NumberWithSpecialNumberStylesStringEnUS, SpecialNumberStyles, out T? number);

					AssertHelper.IsTrue(() => success);
					AssertHelper.IsNotNull(() => number);
					AssertHelper.AreEqual(NumberWithSpecialNumberStyles, () => number);
				});
		}

		protected void Test_TryParse_Nullable_IsNull_WithNumberStyles()
		{
			WithEnUSCulture(
				() =>
				{
					bool success = TryParse(WHITE_SPACE, SpecialNumberStyles, out T? number);

					AssertHelper.IsTrue(() => success);
					AssertHelper.IsNull(() => number);
				});
		}

		protected void Test_TryParse_Nullable_IsInvalid_WithNumberStyles()
		{
			WithEnUSCulture(
				() =>
				{
					bool success = TryParse(INVALID_NUMBER, SpecialNumberStyles, out T? number);

					AssertHelper.IsFalse(() => success);
					AssertHelper.IsNull(() => number);
				});
		}

		protected void Test_TryParse_Nullable_HasValue_WithFormatProvider()
		{
			WithEnUSCulture(
				() =>
				{
					bool success = TryParse(NormalNumberStringNlNL, _nlNLCulture, out T? number);

					AssertHelper.IsTrue(() => success);
					AssertHelper.IsNotNull(() => number);
					AssertHelper.AreEqual(NormalNumber, () => number);
				});
		}

		protected void Test_TryParse_Nullable_IsNull_WithFormatProvider()
		{
			WithEnUSCulture(
				() =>
				{
					bool success = TryParse(WHITE_SPACE, _nlNLCulture, out T? number);

					AssertHelper.IsTrue(() => success);
					AssertHelper.IsNull(() => number);
				});
		}

		protected void Test_TryParse_Nullable_IsInvalid_WithFormatProvider()
		{
			WithEnUSCulture(
				() =>
				{
					bool success = TryParse(INVALID_NUMBER, _nlNLCulture, out T? number);

					AssertHelper.IsFalse(() => success);
					AssertHelper.IsNull(() => number);
				});
		}

		protected void Test_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider()
		{
			WithEnUSCulture(
				() =>
				{
					bool success = TryParse(NumberWithSpecialNumberStylesStringNlNL, SpecialNumberStyles, _nlNLCulture, out T? number);

					AssertHelper.IsTrue(() => success);
					AssertHelper.IsNotNull(() => number);
					AssertHelper.AreEqual(NumberWithSpecialNumberStyles, () => number);
				});
		}

		protected void Test_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider()
		{
			WithEnUSCulture(
				() =>
				{
					bool success = TryParse(WHITE_SPACE, SpecialNumberStyles, _nlNLCulture, out T? number);

					AssertHelper.IsTrue(() => success);
					AssertHelper.IsNull(() => number);
				});
		}

		protected void Test_TryParse_Nullable_IsInvalid_WithNumberStyles_AndFormatProvider()
		{
			WithEnUSCulture(
				() =>
				{
					bool success = TryParse(INVALID_NUMBER, SpecialNumberStyles, _nlNLCulture, out T? number);

					AssertHelper.IsFalse(() => success);
					AssertHelper.IsNull(() => number);
				});
		}

		protected void Test_ParseNullable_HasValue()
		{
			WithEnUSCulture(
				() =>
				{
					T? number = ParseNullable(NormalNumberStringEnUS);

					AssertHelper.IsNotNull(() => number);
					AssertHelper.AreEqual(NormalNumber, () => number);
				});
		}

		protected void Test_ParseNullable_IsNull()
		{
			WithEnUSCulture(
				() =>
				{
					T? number = ParseNullable(WHITE_SPACE);

					AssertHelper.IsNull(() => number);
				});
		}

		protected void Test_ParseNullable_HasValue_WithNumberStyles()
		{
			WithEnUSCulture(
				() =>
				{
					T? number = ParseNullable(NumberWithSpecialNumberStylesStringEnUS, SpecialNumberStyles);

					AssertHelper.IsNotNull(() => number);
					AssertHelper.AreEqual(NumberWithSpecialNumberStyles, () => number);
				});
		}

		protected void Test_ParseNullable_IsNull_WithNumberStyles()
		{
			WithEnUSCulture(
				() =>
				{
					T? number = ParseNullable(WHITE_SPACE, SpecialNumberStyles);

					AssertHelper.IsNull(() => number);
				});
		}

		protected void Test_ParseNullable_HasValue_WithFormatProvider()
		{
			WithEnUSCulture(
				() =>
				{
					T? number = ParseNullable(NormalNumberStringNlNL, _nlNLCulture);

					AssertHelper.IsNotNull(() => number);
					AssertHelper.AreEqual(NormalNumber, () => number);
				});
		}

		protected void Test_ParseNullable_IsNull_WithFormatProvider()
		{
			WithEnUSCulture(
				() =>
				{
					T? number = ParseNullable(WHITE_SPACE, _nlNLCulture);

					AssertHelper.IsNull(() => number);
				});
		}

		protected void Test_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider()
		{
			WithEnUSCulture(
				() =>
				{
					T? number = ParseNullable(NumberWithSpecialNumberStylesStringNlNL, SpecialNumberStyles, _nlNLCulture);

					AssertHelper.IsNotNull(() => number);
					AssertHelper.AreEqual(NumberWithSpecialNumberStyles, () => number);
				});
		}

		protected void Test_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider()
		{
			WithEnUSCulture(
				() =>
				{
					T? number = ParseNullable(WHITE_SPACE, SpecialNumberStyles, _nlNLCulture);

					AssertHelper.IsNull(() => number);
				});
		}

		private void WithEnUSCulture(Action action)
		{
			CultureInfo originalCulture = CultureHelper.GetCurrentCulture();
			try
			{
				CultureHelper.SetCurrentCulture(_enUSCulture);

				action();
			}
			finally
			{
				CultureHelper.SetCurrentCulture(originalCulture);
			}
		}
	}
}