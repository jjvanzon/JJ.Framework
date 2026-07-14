#pragma warning disable IDE0048
// 
// ReSharper disable ForCanBeConvertedToForeach
// ReSharper disable InvokeAsExtensionMemberFromSameClass
// ReSharper disable UseRawString
// ReSharper disable MergeIntoPattern

namespace JJ.Framework.Text.Core
{
    public static class StringHelperCore
    {
        public static int CountLines(this string? str)
        {
            // Less efficient:
            //int count = str.Trim().Split(NewLine).Length;
            //int count = 1 + str.Count(c => c == '\n');
            
            if (str == null) return 0;
            
            int count = 1; // Start with 1 to account for the first line
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '\n') // Platform safe for '\n' or "\r\n".
                {
                    count++;
                }
            }
            
            if (str.EndsWith(Environment.NewLine))
            {
                count--;
            }
            
            return count;
        }
        
        public static bool Contains(this string str, string substring, bool ignoreCase = false)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));
            return str.IndexOf(substring, ToStringComparison(ignoreCase)) >= 0;
        }
        
        // TODO: Distinction between ContainsAny and ContainsAll might be welcome.

        public static bool Contains(this string str, string[] words, bool ignoreCase = false)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));
            return words.Any(x => str.IndexOf(x, ToStringComparison(ignoreCase)) >= 0);
        }
        
        public static bool Contains(this string str, char[] chars)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));
            return chars.Any(str.Contains);
        }
        
        public static StringComparison ToStringComparison(this bool ignoreCase)
            => ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

        /// <inheritdoc cref="_prettyduration" />
        public static string PrettyDuration(double? sec)
        {
            if (!sec.HasValue) return "";
            return PrettyDuration(sec.Value);
        }
        
        /// <inheritdoc cref="_prettyduration" />
        public static string PrettyDuration(double sec) => PrettyTimeSpan(TimeSpan.FromSeconds(sec));
        
        public static string PrettyTimeSpan(this TimeSpan timeSpan)
        {
            
            if (timeSpan.TotalDays >= 1) 
                return $"{timeSpan.TotalDays:0.00} d";

            if (timeSpan.TotalHours >= 1) 
                return $"{timeSpan.TotalHours:0.00} h";

            if (timeSpan.TotalMinutes >= 1) 
                return $"{timeSpan.TotalMinutes:0.00} min";

            if (timeSpan.TotalSeconds >= 1) 
                return $"{timeSpan.TotalSeconds:0.00} s";

            if (timeSpan.TotalMilliseconds >= 1) 
                return $"{timeSpan.TotalMilliseconds:0.00} ms";
            
            double totalMicroSec = timeSpan.TotalMilliseconds * 1000;
            return $"{totalMicroSec:0.00} μs";
        }
        
        public static string PrettyByteCount(byte[]? bytes)
        {
            int coalescedLength = bytes?.Length ?? 0;
            return PrettyByteCount(coalescedLength);
        }
        
        public static string PrettyByteCount(long byteCount)
        {
            int sign = Sign(byteCount);
            long bytesAbs = Abs(byteCount);

            const double kBSize = 1024;
            const double MBSize = kBSize * 1024;
            const double GBSize = MBSize * 1024;
            
            if (bytesAbs <= 5 * kBSize) 
                return $"{sign * bytesAbs} bytes";

            if (bytesAbs <= 5 * MBSize) 
                return $"{sign * bytesAbs / kBSize:0} kB";

            if (bytesAbs <= 5 * GBSize)
                return $"{sign * bytesAbs / MBSize:0} MB";
            
            return $"{sign * bytesAbs / GBSize:0} GB";
        }
        
        // Match GUID-like sequences with or without dashes, with or without braces.
        private static readonly Regex _guidyRegex = new (@"(""?)(\{|\b)([a-fA-F0-9]{4,32}(-?[a-fA-F0-9]{4,32}){0,7})(\}|\b)(""?)", ExplicitCapture | Compiled);

        public static string WithShortGuids(this string? input, int length)
        {
            if (length < 1) throw new Exception("length < 1");
            input ??= "";

            string output = _guidyRegex.Replace(input, match =>
            {
                if (MayBeAWord(match.Value)) return match.Value;
                return ToShortGuid(match.Value, length);
            });
            
            return output;
        }

        private static string ToShortGuid(this string? input, int length)
        {
            if (length < 1) throw new Exception("length < 1");
            input ??= "";

            var outChars = new char[length];

            int j = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char chr = input[i];

                bool charAllowed = 
                    chr >= '0' && chr <= '9' || 
                    chr >= 'a' && chr <= 'f' ||
                    chr >= 'A' && chr <= 'F';

                if (!charAllowed)
                    continue;

                outChars[j] = chr;
                j++;
                if (j >= length) break;
            }

            return new string(outChars);
        }

        public static string ToShortGuid(this Guid? input, int length)
        {
            string str = input?.ToString() ?? "";
            return ToShortGuid(str, length);
        }

        private static bool MayBeAWord(string? guid)
        {
            if (guid == null) return false;
            if (guid.Length == 0) return false;

            bool hasDecimals = guid.Any(x => x >= '0' && x <= '9');
            if (hasDecimals)
            {
                return false;
            }

            char[] hexVowels = [ 'a', 'e', 'A', 'E' ];

            bool hasVowels = guid.Contains(hexVowels);
            if (!hasVowels)
            {
                return false;
            }

            const int maxHexLetters = 10;
            bool tooManyHexLetters = guid.Length > maxHexLetters;
            if (tooManyHexLetters)
            {
                return false;
            }

            double vowelPercentage = 100.0 * guid.Count(hexVowels.Contains) / guid.Length;
            bool hasEnoughVowels = vowelPercentage > 25;
            if (!hasEnoughVowels)
            {
                return false;
            }

            // TODO: Has both upper and lower case letters = probably a word?

            // No digit, has vowel, has enough vowels, not a long string of hex = probably a word.
            return true;
        }

        public static string PrettyTime() => PrettyTime(DateTime.Now);
        
        public static string PrettyTime(DateTime dateTime) => $"{dateTime:HH:mm:ss.fff}";
        
        public static string Trim(this string text, string trim)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            return text.TrimStart(trim).TrimEnd(trim);
        }

        /// <inheritdoc cref="_endswithpunctuation" />
        public static bool EndsWithPunctuation(this string text, bool ignoreWhiteSpace = true)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                // Start of string is good enough for punctuation.
                return true;
            }

            if (ignoreWhiteSpace) text = text.TrimEnd();
            
            // ReSharper disable once PossibleNullReferenceException
            return char.IsPunctuation(text[text.Length - 1]);
        }
        
        public static bool StartsWithBlankLine(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return true;
            
            for (int i = 0; i < text.Length; i++)
            {
                char chr = text[i];
                
                bool isWhiteSpace = char.IsWhiteSpace(chr);
                if (!isWhiteSpace) return false;
                
                bool isNewLine = chr == '\n';
                if (isNewLine) return true;
                
                bool isLastChar = i == text.Length - 1;
                if (isLastChar) return false;
            }
            
            return false;
        }
        
        public static bool EndsWithBlankLine(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return true;
            
            for (int i = text.Length - 1; i >= 0; i--)
            {
                char chr = text[i];
                
                bool isWhiteSpace = char.IsWhiteSpace(chr);
                if (!isWhiteSpace) return false;
                
                bool isNewLine = chr == '\n';
                if (isNewLine) return true;
                
                bool isFirstChar = i == 0;
                if (isFirstChar) return false;
            }
            
            return false;
        }

        /// <inheritdoc cref="_replace" />
        public static string Replace(string text, string oldValue, char newValue)
        {
            ThrowIfNull(text);
            return text.Replace(oldValue, newValue.ToString()); 
        }

        /// <inheritdoc cref="_replace" />
        public static string Replace(string text, char oldValue, string newValue)
        {
            ThrowIfNull(text);
            return text.Replace(oldValue.ToString(), newValue);
        }

        // TODO: Expland with other overloads that .NET supports. Our overloads mix char and string parameters for old and new values for syntax sugar.
    }
}