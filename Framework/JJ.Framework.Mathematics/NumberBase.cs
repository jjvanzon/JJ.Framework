using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Mathematics
{
    public static class NumberBase
    {
        // The general formula for a digit value is:
        //
        //     digits[i] = number / pow(base, i) % base
        //
        // The formula is best explained with an example.
        // In the example an int value will be converted to a set of decimal digits.
        //
        //    Given: Value = 6437, Digit count = 4, Base = 10
        //
        //    for (int i = 3; i >= 0; i--) // Go from digit 3 to digit 0
        //    {
        //        digits[i] = value / (10 ^ i) % 10; // E.g. digit 2 = 6437 / 100 % 10 = 64 Mod 10 = 4
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

        // To Base-N Number

        /// <summary>
        /// Calculates an array of digit values that represent a number in a base-n numbering system.
        /// </summary>
        private static int[] GetDigitValues(int number, int n)
        {
            if (number < 0) throw new ArgumentException("number must be larger than 0.");
            if (n < 2) throw new ArgumentException("n must be 2 or higher.");

            int digitCount = GetDigitCount(number, n);
            int[] digits = new int[digitCount];

            int pow = 1;
            for (int i = digitCount - 1; i >= 0; i--)
            {
                checked
                {
                    int digitValue = number / pow % n;
                    digits[i] = digitValue;

                    if (i > 0) // Prevent overflow
                    {
                        pow *= n;
                    }
                }
            }

            return digits;
        }

        private static int GetDigitCount(int number, int n)
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
                double toTheHowManieth = Math.Log(number, n);
                int digitCount = (int)toTheHowManieth + 1;
                return digitCount;
            }
        }

        /// <summary>
        /// Produces a string that represents the number in a base-n numbering system.
        /// The digit characters are specified explicitly in an array.
        /// </summary>
        public static string ToBaseNNumber(int number, int n, char[] digitChars)
        {
            if (digitChars == null) throw new ArgumentNullException("digitChars");
            if (digitChars.Length < n) throw new ArgumentException("digitChars.Length must have at least n elements.");

            int[] digitValues = GetDigitValues(number, n);
            char[] digits = digitValues.Select(x => DigitValueToChar(x, digitChars)).ToArray();
            string result = new String(digits);
            return result;
        }

        /// <summary>
        /// Produces a string that represents the number in a base-n numbering system.
        /// The first digit is a specific character value.
        /// That way the digits can only be a consecutive character range.
        /// </summary>
        public static string ToBaseNNumber(int number, int n, char firstChar)
        {
            int[] digitValues = GetDigitValues(number, n);
            char[] digits = digitValues.Select(x => DigitValueToChar(x, firstChar)).ToArray();
            string result = new String(digits);
            return result;
        }

        /// <summary>
        /// Convers a number to its hexadecimal representation.
        /// </summary>
        public static string ToHex(int input)
        {
            return ToBaseNNumber(input, 16, _digitChars);
        }

        /// <summary>
        /// Produces a string that represents the number in a base-n numbering system.
        /// The digits are 0-9 and then A-Z. Higher digits are not allowed.
        /// </summary>
        public static string ToBaseNNumber(int number, int n)
        {
            return ToBaseNNumber(number, n, _digitChars);
        }

        // From Base-N Number

        /// <summary>
        /// Converts a base-n number to an integer.
        /// A delegate is passed to this method that derives the digit value from the character value.
        /// </summary>
        private static int FromBaseNNumber(string input, int n, Func<char, int> charToDigitValue)
        {
            if (String.IsNullOrEmpty(input)) throw new ArgumentException("input cannot be null or empty.");
            if (n < 2) throw new ArgumentException("n must be 2 or higher.");
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
                        pow *= n;
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
            return FromBaseNNumber(hex, 16);
        }

        /// <summary>
        /// Converts a base-n number to an int.
        /// The digits are 0-9 and then A-Z. Higher digits are not allowed.
        /// </summary>
        public static int FromBaseNNumber(string input, int n)
        {
            int result = FromBaseNNumber(input, n, x => CharToDigitValue(x));
            return result;
        }

        /// <summary>
        /// Converts a base-n number to an integer.
        /// The digits are specified explicitly in an array of characters.
        /// </summary>
        public static int FromBaseNNumber(string input, int n, char[] digitChars)
        {
            int result = FromBaseNNumber(input, n, x => CharToDigitValue(x, digitChars));
            return result;
        }

        /// <summary>
        /// Converts a base-n number to an integer.
        /// The first digit is a specific character value.
        /// That way the digits can only be a consecutive character range.
        /// </summary>
        public static int FromBaseNNumber(string input, int n, char firstChar)
        {
            int result = FromBaseNNumber(input, n, x => CharToDigitValue(x, firstChar));
            return result;
        }

        public static int FromSpreadSheetStyleColumnNames(string input)
        {
            if (String.IsNullOrEmpty(input)) throw new ArgumentNullException("input");

            if (input.Length == 1)
            {
                return FromBaseNNumber(input, 26);
            }
            if (input.Length == 2)
            {
                
            }

            throw new NotImplementedException();
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
    }
}
