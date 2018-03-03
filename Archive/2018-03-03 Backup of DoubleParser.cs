//using System;
//using System.Globalization;
//using System.Runtime.CompilerServices;

//namespace JJ.Framework.Conversion
//{
//	public static class DoubleParser
//	{
//		/// <summary>
//		/// If you want to use Double.TryParse with a format provider,
//		/// then you are obliged to also pass NumberStyles.
//		/// If you ever wonder what NumberStyles to pass,
//		/// just call this method instead. It will mimic the default behavior of TryParse.
//		/// </summary>
//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		public static bool TryParse(string s, IFormatProvider provider, out double result)
//			=> double.TryParse(s, NumberStyles.Any, provider, out result);

//		public static double? ParseNullable(string input)
//		{
//			if (string.IsNullOrWhiteSpace(input))
//			{
//				return null;
//			}

//			return double.Parse(input);
//		}

//		/// <summary> Parses a nullable double. </summary>
//		public static bool TryParse(string input, IFormatProvider provider, out double? output)
//			=> TryParse(input, NumberStyles.Any, provider, out output);

//		/// <summary> Parses a nullable double. </summary>
//		public static bool TryParse(string input, out double? output)
//		{
//			output = default;

//			if (string.IsNullOrWhiteSpace(input))
//			{
//				return true;
//			}

//			bool result = double.TryParse(input, out double temp);
//			if (!result)
//			{
//				return false;
//			}

//			output = temp;

//			return true;
//		}

//		/// <summary> Parses a nullable double. </summary>
//		public static bool TryParse(string input, NumberStyles style, IFormatProvider provider, out double? output)
//		{
//			output = default;

//			if (string.IsNullOrWhiteSpace(input))
//			{
//				return true;
//			}

//			bool result = double.TryParse(input, style, provider, out double temp);
//			if (!result)
//			{
//				return false;
//			}

//			output = temp;

//			return true;
//		}
//	}
//}