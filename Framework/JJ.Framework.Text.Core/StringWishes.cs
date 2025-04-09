using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JJ.Framework.Text.Core
{
    public static class StringWishes
    {
        public static int CountLines(this string str)
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
        
        public static string PrettyDuration(double? durationInSeconds)
        {
            if (!durationInSeconds.HasValue) return default;
            return PrettyDuration(durationInSeconds.Value);
        }
        
        public static string PrettyDuration(double durationInSeconds) => PrettyTimeSpan(TimeSpan.FromSeconds(durationInSeconds));
        
        public static string PrettyTimeSpan(this TimeSpan timeSpan)
        {
            double totalNanoseconds = timeSpan.TotalMilliseconds * 1000;
            
            if (timeSpan.TotalDays         >= 1) return $"{timeSpan.TotalDays:0.00} d";
            if (timeSpan.TotalHours        >= 1) return $"{timeSpan.TotalHours:0.00} h";
            if (timeSpan.TotalMinutes      >= 1) return $"{timeSpan.TotalMinutes:0.00} min";
            if (timeSpan.TotalSeconds      >= 1) return $"{timeSpan.TotalSeconds:0.00} s";
            if (timeSpan.TotalMilliseconds >= 1) return $"{timeSpan.TotalMilliseconds:0.00} ms";
            
            return $"{totalNanoseconds:0.00} ns";
        }
        
        public static string PrettyByteCount(byte[] bytes)
        {
            int coalescedLength = bytes?.Length ?? 0;
            return PrettyByteCount(coalescedLength);
        }
        
        public static string PrettyByteCount(long byteCount)
        {
            const double kB = 1024;
            const double MB = kB * 1024;
            const double GB = MB * 1024;
            
            if (byteCount <= 5 * kB) return $"{byteCount} bytes";
            if (byteCount <= 5 * MB) return $"{byteCount / kB:0} kB";
            if (byteCount <= 5 * GB) return $"{byteCount / MB:0} MB";
            
            return $"{byteCount / GB:0} GB";
        }
        
        public static string WithShortGuids(this string input, int length)
        {
            // Regular expression to match GUID-like sequences with or without dashes
            var guidPattern = new Regex(@"\b[a-fA-F0-9]{4,32}\b(-?[a-fA-F0-9]{4,32})*\b", RegexOptions.IgnoreCase);
            
            // Replace each matched GUID-like sequence with a truncated version
            string output = guidPattern.Replace(input, match =>
            {
                // Remove dashes from the matched sequence
                string guid = match.Value.Replace("-", "");
                
                // Shorten the GUID to the desired length, ensuring it doesn't exceed the original length
                return guid.Substring(0, Math.Min(length, guid.Length));
            });
            
            return output;
        }
        
        public static string PrettyTime() => PrettyTime(DateTime.Now);
        
        public static string PrettyTime(DateTime dateTime) => $"{dateTime:HH:mm:ss.fff}";
        
        public static string Trim(this string text, string trim)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            return text.TrimStart(trim).TrimEnd(trim);
        }
        
        /// <summary>
        /// Determines whether the given string ends with a punctuation character,
        /// optionally ignoring trailing whitespace.
        /// This method is helpful when building strings with multiple optional elements,
        /// ensuring proper punctuation is applied only when necessary.
        /// 
        /// If the string is <c>null</c> or empty, it is treated as the beginning of a line,
        /// where no punctuation is required. In this case, the method returns <c>true</c>,
        /// indicating no additional punctuation is needed.
        /// </summary>
        /// <param name="text">
        /// The string to evaluate. This parameter can be <c>null</c> or empty.
        /// </param>
        /// <param name="ignoreWhiteSpace">
        /// If set to <c>true</c>, trailing whitespace in the string is ignored before evaluating for punctuation.
        /// Defaults to <c>true</c>.
        /// </param>
        /// <returns>
        /// <c>true</c> if the string ends with a punctuation character,
        /// or if the string is <c>null</c> or empty (considered as starting a new line).<br/>
        /// <c>false</c> if the string does not end with a punctuation character
        /// after accounting for <paramref name="ignoreWhiteSpace"/>.
        /// </returns>
        public static bool EndsWithPunctuation(this string text, bool ignoreWhiteSpace = true)
        {
            if (ignoreWhiteSpace) text = text?.TrimEnd();
            
            if (string.IsNullOrWhiteSpace(text))
            {
                // Start of string is good enough for punctuation.
                return true;
            }
            
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
    }
}