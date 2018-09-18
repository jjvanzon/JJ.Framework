using System;
using System.Text.RegularExpressions;

namespace JJ.Framework.Text
{
	public static class StringExtensions
	{
		public static string FromTill(this string input, int startIndex, int endIndex) => input.Substring(startIndex, endIndex - startIndex + 1);

		/// <summary>
		/// Returns the left part of a string.
		/// Throws an exception if the string has less characters than the length provided.
		/// </summary>
		public static string Left(this string input, int length) => input.Substring(0, length);

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

		public static string Replace(this string input, string oldValue, string newValue, bool ignoreCase)
		{
			RegexOptions options = default;
			if (ignoreCase)
			{
				options = RegexOptions.IgnoreCase;
			}

			var regex = new Regex(Regex.Escape(oldValue), options);
			string output = regex.Replace(input, newValue);
			return output;
		}

		/// <summary>
		/// Returns the right part of a string.
		/// Throws an exception if the string has less characters than the length provided.
		/// </summary>
		public static string Right(this string input, int length) => input.Substring(input.Length - length, length);

		/// <summary>
		/// Returns the left part of a string.
		/// Can return less characters than the length provided if string is shorter.
		/// </summary>
		public static string TakeEnd(this string input, int length)
		{
			if (length > input.Length) length = input.Length;

			return input.Right(length);
		}

		/// <summary>
		/// Takes the part of a string until the specified delimiter. Excludes the delimiter itself.
		/// </summary>
		public static string TakeEndUntil(this string input, string until)
		{
			if (until == null) throw new ArgumentNullException(nameof(until));
			int index = input.LastIndexOf(until, StringComparison.Ordinal);
			if (index == -1) return "";
			int length = input.Length - index - 1;
			string output = input.Right(length);
			return output;
		}

		/// <summary>
		/// Takes the part of a string until the specified delimiter. Excludes the delimiter itself.
		/// </summary>
		public static string TakeEndUntil(this string input, char until) => TakeEndUntil(input, until.ToString());

		[Obsolete("Use TakeStart instead.", true)]
		public static string TakeLeft(this string input, int length) => throw new NotSupportedException("Use TakeStart instead.");

		[Obsolete("Use TakeEnd instead.", true)]
		public static string TakeRight(this string input, int length) => throw new NotSupportedException("Use TakeEnd instead.");

		/// <summary>
		/// Returns the left part of a string.
		/// Can return less characters than the length provided if string is shorter.
		/// </summary>
		public static string TakeStart(this string input, int length)
		{
			if (length > input.Length) length = input.Length;

			return input.Left(length);
		}

		/// <summary>
		/// Takes the part of a string until the specified delimiter. Excludes the delimiter itself.
		/// </summary>
		public static string TakeStartUntil(this string input, string until)
		{
			if (until == null) throw new ArgumentNullException(nameof(until));
			int index = input.IndexOf(until, StringComparison.Ordinal);
			if (index == -1) return "";
			string output = input.Left(index);
			return output;
		}

		/// <summary>
		/// Takes the part of a string until the specified delimiter. Excludes the delimiter itself.
		/// </summary>
		public static string TakeStartUntil(this string input, char until) => TakeStartUntil(input, until.ToString());

		/// <summary> Will trim off repetitions of the same value from the given string. </summary>
		public static string TrimEnd(this string input, string end)
		{
			if (string.IsNullOrEmpty(end)) throw new Exception($"{nameof(end)} is null or empty.");

			string temp = input;

			while (temp.EndsWith(end))
			{
				temp = temp.TrimEnd(end.Length);
			}

			return temp;
		}

		/// <summary> Will trim off repetitions of the same value from the given string. </summary>
		public static string TrimEnd(this string input, int length) => input.Left(input.Length - length);

		/// <summary>
		/// Cuts off the part of a string until the specified delimiter and returns what remains including the delimiter itself.
		/// </summary>
		public static string TrimEndUntil(this string input, char until) => TrimEndUntil(input, until.ToString());

		/// <summary>
		/// Cuts off the part of a string until the specified delimiter and returns what remains including the delimiter itself.
		/// </summary>
		public static string TrimEndUntil(this string input, string until)
		{
			if (until == null) throw new ArgumentNullException(nameof(until));
			int index = input.LastIndexOf(until, StringComparison.Ordinal);
			if (index == -1) return input;
			string output = input.Left(index + until.Length);
			return output;
		}

		/// <summary> Will trim off at most one occurrence of a value from the given string. </summary>
		public static string TrimFirst(this string input, string start)
		{
			if (string.IsNullOrEmpty(start)) throw new Exception($"{nameof(start)} is null or empty.");

			if (input.StartsWith(start))
			{
				return input.TrimStart(start.Length);
			}

			return input;
		}

		/// <summary> Will trim off at most one occurrence of a value from the given string. </summary>
		public static string TrimLast(this string input, string end)
		{
			if (string.IsNullOrEmpty(end)) throw new Exception($"{nameof(end)} is null or empty.");

			if (input.EndsWith(end))
			{
				return input.TrimEnd(end.Length);
			}

			return input;
		}

		/// <summary> Will trim off repetitions of the same value from the given string. </summary>
		public static string TrimStart(this string input, string start)
		{
			if (string.IsNullOrEmpty(start)) throw new Exception($"{nameof(start)} is null or empty.");

			string temp = input;

			while (temp.StartsWith(start))
			{
				temp = temp.TrimStart(start.Length);
			}

			return temp;
		}

		/// <summary> Will trim off repetitions of the same value from the given string. </summary>
		public static string TrimStart(this string input, int length) => input.Right(input.Length - length);

		/// <summary>
		/// Cuts off the part of a string until the specified delimiter and returns what remains including the delimiter itself.
		/// </summary>
		public static string TrimStartUntil(this string input, char until) => TrimStartUntil(input, until.ToString());

		/// <summary>
		/// Cuts off the part of a string until the specified delimiter and returns what remains including the delimiter itself.
		/// </summary>
		public static string TrimStartUntil(this string input, string until)
		{
			if (until == null) throw new ArgumentNullException(nameof(until));
			int index = input.IndexOf(until, StringComparison.Ordinal);
			if (index == -1) return input;
			string output = input.Right(input.Length - index);
			return output;
		}
	}
}