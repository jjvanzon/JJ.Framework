using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Mathematics
{
    public static class NumberingSystems
    {
        // The general formula for a digit value is:
        //
        //     digits[i] = number / base ^ i % base
        //
        // The formula is best explained with an example.
        // In the example an int value will be converted to a set of decimal digits.
        //
        //    Given: Value = 6437, Digit count = 4, Base = 10
        //
        //    for (int i = 3; i >= 0; i--) // Go from digit 3 to digit 0
        //    {
        //        digits[i] = value / Math.Pow(10, i) % 10; // E.g. digit 2 = 6437 / 100 % 10 = 64 Mod 10 = 4
        //    }
        //
        // Or:
        //
        //     Value = 6437, Base = 10
        //
        //     digits[i] = 6437 / (10 ^ i) % 10:
        //
        //     digit[0] = 6437 / 1 % 10 = 6437 % 10 = 7
        //     digit[1] = 6437 / 10 % 10 = 643 % 10 = 3
        //     digit[2] = 6437 / 100 % 10 = 64 % 10 = 4
        //     digit[3] = 6437 / 1000 % 10 = 6 % 10 = 6

        private static char[] _digitChars = new char[]
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 
            'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 
            'Q', 'R', 'S', 
            'T', 'U', 'V', 
            'W', 
            'X', 'Y', 'Z'
        };

        // To Base

        /// <summary>
        /// Calculates an array of digit values that represent a number in a base-b numbering system.
        /// </summary>
        private static int[] GetDigitValues(int number, int b)
        {
            if (number < 0) throw new ArgumentException("number must be larger than 0.");
            if (b < 2) throw new ArgumentException("b must be 2 or higher.");

            int digitCount = GetDigitCount(number, b);
            int[] digits = new int[digitCount];

            for (int i = digitCount - 1; i >= 0; i--)
            {
                checked
                {
                    int digit = number % b;
                    digits[i] = digit;
                    number /= b;
                }
            }

            return digits;
        }

        private static int GetDigitCount(int number, int b)
        {
            if (number == 0)
            {
                return 1;
            }

            if (number == 1)
            {
                return 1;
            }

            checked
            {
                int toTheHowManieth = Maths.Log(number, b);
                int digitCount = toTheHowManieth + 1;
                return digitCount;
            }
        }

        /// <summary>
        /// Produces a string that represents the number in a base-b numbering system.
        /// The digit characters are specified explicitly in an array.
        /// </summary>
        public static string ToBase(int number, char[] digitChars)
        {
            if (digitChars == null) throw new ArgumentNullException("digitChars");
            int b = digitChars.Length;
            string result = ToBase(number, b, digitChars);
            return result;
        }

        /// <summary>
        /// Produces a string that represents the number in a base-b numbering system.
        /// The digit characters are specified explicitly in an array.
        /// </summary>
        public static string ToBase(int number, int b, char[] digitChars)
        {
            if (digitChars == null) throw new ArgumentNullException("digitChars");
            if (digitChars.Length < b) throw new ArgumentException("digitChars.Length must have at least b elements.");

            int[] digitValues = GetDigitValues(number, b);
            char[] digits = digitValues.Select(x => DigitValueToChar(x, digitChars)).ToArray();
            string result = new String(digits);
            return result;
        }

        /// <summary>
        /// Produces a string that represents the number in a base-b numbering system.
        /// The first digit is a specific character value.
        /// That way the digits can only be a consecutive character range.
        /// </summary>
        public static string ToBase(int number, int b, char firstChar)
        {
            int[] digitValues = GetDigitValues(number, b);
            char[] digits = digitValues.Select(x => DigitValueToChar(x, firstChar)).ToArray();
            string result = new String(digits);
            return result;
        }

        /// <summary>
        /// Convers a number to its hexadecimal representation.
        /// </summary>
        public static string ToHex(int input)
        {
            return ToBase(input, 16, _digitChars);
        }

        /// <summary>
        /// Produces a string that represents the number in a base-b numbering system.
        /// The digits are 0-9 and then A-Z. Higher digits are not allowed.
        /// </summary>
        public static string ToBase(int number, int b)
        {
            return ToBase(number, b, _digitChars);
        }

        // From Base

        /// <summary>
        /// Converts a base-b number to an integer.
        /// A delegate is passed to this method that derives the digit value from the character value.
        /// </summary>
        private static int FromBase(string input, int b, Func<char, int> charToDigitValue)
        {
            if (String.IsNullOrEmpty(input)) throw new ArgumentException("input cannot be null or empty.");
            if (b < 2) throw new ArgumentException("b must be 2 or higher.");
            if (charToDigitValue == null) throw new ArgumentNullException("charToDigitValue");

            int result = 0;
            int pow = 1;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                checked
                {
                    char chr = input[i];
                    int digitValue = charToDigitValue(chr);

                    result += digitValue * pow;

                    if (i > 0) // Prevent overflow
                    {
                        pow *= b;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Coverts a string with a hexadecimal number in it to an integer.
        /// </summary>
        public static int FromHex(string hex)
        {
            return FromBase(hex, 16);
        }

        /// <summary>
        /// Converts a base-b number to an int.
        /// The digits are 0-9 and then A-Z. Higher digits are not allowed.
        /// </summary>
        public static int FromBase(string input, int b)
        {
            int result = FromBase(input, b, chr => CharToDigitValue(chr));
            return result;
        }

        /// <summary>
        /// Converts a base-b number to an integer.
        /// The digits are specified explicitly in an array of characters.
        /// </summary>
        public static int FromBase(string input, int b, char[] digitChars)
        {
            int result = FromBase(input, b, chr => CharToDigitValue(chr, digitChars));
            return result;
        }

        /// <summary>
        /// Converts a base-b number to an integer.
        /// The first digit is a specific character value.
        /// The digits can only be a consecutive character range.
        /// </summary>
        public static int FromBase(string input, int b, char firstChar)
        {
            int result = FromBase(input, b, chr => CharToDigitValue(chr, firstChar));
            return result;
        }

        /// <summary>
        /// Converts a base-b number to an integer.
        /// The first and last digit characters are specified.
        /// The digits can only be a consecutive character range.
        /// </summary>
        public static int FromBase(string input, char firstChar, char lastChar)
        {
            int b = lastChar - firstChar + 1;
            int result = FromBase(input, b, firstChar);
            return result;
        }

        // Digit Value to Char

        private static char DigitValueToChar(int digitValue, char[] digitChars)
        {
            return digitChars[digitValue];
        }

        private static char DigitValueToChar(int digitValue, char firstChar)
        {
            return (char)(firstChar + digitValue);
        }

        // Char to Digit Value

        private static int CharToDigitValue(char chr, IList<char> digitChars)
        {
            // TODO: This does not look fast.
            return digitChars.IndexOf(chr);
        }

        private static int CharToDigitValue(char chr, char firstChar)
        {
            return chr - firstChar;
        }

        private static int CharToDigitValue(char chr)
        {
            if (chr >= '0' && chr <= '9')
            {
                int digitValue = chr - '0';
                return digitValue;
            }

            if (chr >= 'A' && chr <= 'Z')
            {
                int digitValue = 10 + chr - 'A';
                return digitValue;
            }

            if (chr >= 'a' && chr <= 'z')
            {
                int digitValue = 10 + chr - 'a';
                return digitValue;
            }

            throw new Exception(String.Format("Invalid digit: '{0}'.", chr));
        }

        // Letter Sequences

        /// <summary>
        /// Returns spread-sheet-style letter sequences.
        /// This is not the same as a base-26 numbering system.
        /// After the range A-Z is depleted, the next value is 'AA',
        /// which is equivalent to 00, 
        /// so you basically start counting at 0 again,
        /// but you get 26 for free.
        /// </summary>
        /// <param name="value">0 is the first letter</param>
        public static string ToLetterSequence(int value, char firstChar = 'A', char lastChar = 'Z')
        {
            int b = lastChar - firstChar + 1;
            string result = ToLetterSequence(value, b, firstChar);
            return result;
        }

        /// <summary>
        /// Returns spread-sheet-style letter sequences.
        /// This is not the same as a base-26 numbering system.
        /// After the range A-Z is depleted, the next value is 'AA',
        /// which is equivalent to 00, 
        /// so you basically start counting at 0 again,
        /// but you get 26 for free.
        /// </summary>
        /// <param name="temp">0 is the first letter</param>
        public static string ToLetterSequence(int value, int b, char firstChar = 'A')
        {
            int ceiling = b;
            int i = 1;
            string result;
            int temp = value;

            while (true)
            {
                if (temp < ceiling)
                {
                    result = ToBase(temp, b, firstChar);
                    result = result.PadLeft(i, firstChar);
                    return result;
                }

                i++;
                temp -= ceiling;
                checked
                {
                    ceiling *= b;
                }
            }
        }
        
        /// <summary>
        /// Converts a spread-sheet-style letter sequence to a number.
        /// This is not the same as a base-26 numbering system.
        /// After the range A-Z is depleted, the next value is 'AA',
        /// which is equivalent to 00, 
        /// so you basically start counting at 0 again,
        /// but you get 26 for free.
        /// 0 is the first letter.
        /// </summary>
        public static int FromLetterSequence(string input, char firstChar = 'A', char lastChar = 'Z')
        {
            int b = lastChar - firstChar + 1;
            int result = FromLetterSequence(input, b, firstChar);
            return result;
        }

        /// <summary>
        /// Converts a spread-sheet-style letter sequence to a number.
        /// 0 is the first letter.
        /// This is not the same as a base-26 numbering system.
        /// After the range A-Z is depleted, the next value is 'AA',
        /// which is equivalent to 00, 
        /// so you basically start counting at 0 again,
        /// but you get 26 for free.
        /// </summary>
        public static int FromLetterSequence(string input, int b, char firstChar = 'A')
        {
            if (String.IsNullOrEmpty(input)) throw new ArgumentNullException("input");

            int value = FromBase(input, b, firstChar);

            // Calculate the part you get for free (see summary).
            int extra = 0;
            int pow = 1;
            for (int i = 0; i < input.Length - 1; i++)
            {
                pow *= b;
                extra += pow;
            }

            value += extra;

            return value;
        }
    }
}
