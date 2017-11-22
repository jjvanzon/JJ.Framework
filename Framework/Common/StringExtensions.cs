using System;
using System.Text.RegularExpressions;

namespace JJ.Framework.Common
{
	public static class StringExtensions
	{
		/// <summary> Returns the left part of a string. </summary>
		public static string Left(this string input, int length)
		{
			return input.Substring(0, length);
		}

		/// <summary> Returns the right part of a string. </summary>
		public static string Right(this string input, int length)
		{
			return input.Substring(input.Length - length, length);
		}

		public static string TrimEnd(this string input, char chr)
		{
			return TrimEnd(input, chr.ToString());
		}

		public static string TrimEnd(this string input, string end)
		{
			return input.EndsWith(end) ? input.TrimEnd(end.Length) : input;
		}

		public static string TrimEnd(this string input, int length)
		{
			return input.Left(input.Length - length);
		}

		public static string TrimStart(this string input, char chr)
		{
			return TrimStart(input, chr.ToString());
		}

		public static string TrimStart(this string input, string start)
		{
			return input.StartsWith(start) ? input.TrimStart(start.Length) : input;
		}

		public static string TrimStart(this string input, int length)
		{
			return input.Right(input.Length - length);
		}

		public static string FromTill(this string input, int startIndex, int endIndex)
		{
			return input.Substring(startIndex, endIndex - startIndex + 1);
		}

		/// <summary>
		/// Cuts off the right part of a string until the specified delimiter and returns what remains with a portion cut off still including the delimiter itself.
		/// </summary>
		public static string TrimEndUntil(this string input, string until)
		{
			if (until == null) throw new ArgumentNullException(nameof(until));
			int index = input.LastIndexOf(until, StringComparison.Ordinal);
			if (index == -1) return input;
			string output = input.Left(index + until.Length);
			return output;
		}

		/// <summary>
		/// Cuts off the right part of a string until the specified delimiter and returns what remains with a portion cut off still including the delimiter itself.
		/// </summary>
		public static string TrimStartUntil(this string input, string until)
		{
			if (until == null) throw new ArgumentNullException(nameof(until));
			int index = input.IndexOf(until, StringComparison.Ordinal);
			if (index == -1) return input;
			string output = input.Right(input.Length - index);
			return output;
		}

		/// <summary>
		/// Trims and replaces sequences of two or more white space characters by a single space.
		/// </summary>
		public static string RemoveExcessiveWhiteSpace(this string text)
		{
			text = text.Trim();

			// Replace two or more white space characters by a single space.
			var regex = new Regex(@"(\s{2,})");
			text = regex.Replace(text, " ");

			return text;
		}

		public static string Replace(this string input, string oldValue, string newValue, bool ignoreCase)
		{
			RegexOptions options = default(RegexOptions);
			if (ignoreCase)
			{
				options = RegexOptions.IgnoreCase;
			}

			var regex = new Regex(Regex.Escape(oldValue), options);
			string output = regex.Replace(input, newValue);
			return output;
		}

		public static string Repeat(this string stringToRepeat, int repeatCount)
		{
			if (stringToRepeat == null) throw new ArgumentNullException(nameof(stringToRepeat));

			char[] sourceChars = stringToRepeat.ToCharArray();
			int sourceLength = sourceChars.Length;

			int destLength = sourceLength * repeatCount;
			var destChars = new char[destLength];

			for (int i = 0; i < destLength; i += sourceLength)
			{
				Array.Copy(sourceChars, 0, destChars, i, sourceLength);
			}

			string destString = new string(destChars);
			return destString;
		}
	}
}
