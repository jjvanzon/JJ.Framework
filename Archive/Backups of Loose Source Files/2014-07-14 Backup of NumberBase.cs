using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JJ.Framework.Maths
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

        /// <summary>
        /// Produces a string that represents the number a base-n numbering system.
        /// The digits are specified explicitly in an array of characters.
        /// </summary>
        public static string ToBaseNNumber(int number, int n, char[] digitChars)
        {
            if (number < 0) throw new ArgumentException("number must be larger than 0.");
            if (n < 1) throw new ArgumentException("n must be 1 or higher.");
            if (digitChars == null) throw new ArgumentNullException("digitChars");
            if (digitChars.Length < n) throw new ArgumentException("digitChars must contain be at least n elements.", "digitChars");

            int digitCount = GetDigitCount(number, n);
            char[] digits = new char[digitCount];

            int pow = 1;
            for (int i = digitCount - 1; i >= 0; i--)
            {
                int digitValue;

                checked
                {
                    digitValue = number / pow % n;
                }

                char chr = digitChars[digitValue];
                digits[i] = chr;

                if (i > 0) // Prevent overflow
                {
                    checked
                    {
                        pow *= n;
                    }
                }
            }

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
            if (number < 0) throw new ArgumentException("number must be larger than 0.");
            if (n < 1) throw new ArgumentException("n must be 1 or higher.");

            int digitCount = GetDigitCount(number, n);
            char[] digits = new char[digitCount];

            int pow = 1;
            for (int i = digitCount - 1; i >= 0; i--)
            {
                int digitValue;

                checked
                {
                    digitValue = number / pow % n;
                }

                char chr = (char)(firstChar + digitValue);

                digits[i] = chr;

                if (i > 0) // Prevent overflow
                {
                    checked
                    {
                        pow *= n;
                    }
                }
            }

            string result = new String(digits);
            return result;
        }

        /// <summary>
        /// Calculates an array of digit values that represent a number in a base-n numbering system.
        /// </summary>
        public static int[] ToBaseNNumber(int number, int n)
        {
            if (number < 0) throw new ArgumentException("number must be larger than 0.");
            if (n < 1) throw new ArgumentException("n must be 1 or higher.");

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

        // From Base-N Number

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
            if (String.IsNullOrEmpty(input)) throw new ArgumentException("input cannot be null or empty.");
            if (n < 1) throw new ArgumentException("n must be 1 or higher.");

            int result = 0;
            int pow = 1;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                char chr = input[i];

                int digitValue;
                if (chr >= '0' && chr <= '9')
                {
                    digitValue = chr - '0';
                }
                else if (chr >= 'A' && chr <= 'Z')
                {
                    digitValue = 10 + chr - 'A';
                }
                else if (chr >= 'a' && chr <= 'z')
                {
                    digitValue = 10 + chr - 'a';
                }
                else
                {
                    throw new Exception(String.Format("Invalid digit: '{0}'.", chr));
                }

                if (digitValue > n)
                {
                    throw new Exception(String.Format("Invalid digit: '{0}'.", chr));
                }

                checked
                {
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
        /// Converts a base-n number to an integer.
        /// The digits are specified explicitly in an array of characters.
        /// </summary>
        public static int FromBaseNNumber(string input, int n, char[] digitChars)
        {
            if (String.IsNullOrEmpty(input)) throw new ArgumentException("input cannot be null or empty.");
            if (n < 1) throw new ArgumentException("n must be 1 or higher.");
            if (digitChars == null) throw new ArgumentNullException("digitChars");
            if (digitChars.Length < n) throw new ArgumentException("digitChars must contain be at least n elements.", "digitChars");

            IList<char> digitCharIList = (IList<char>)digitChars;
            int result = 0;
            int pow = 1;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                char chr = input[i];
                int digitValue = digitCharIList.IndexOf(chr);

                checked
                {
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
        /// Converts a base-n number to an integer.
        /// The first digit is a specific character value.
        /// That way the digits can only be a consecutive character range.
        /// </summary>
        public static int FromBaseNNumber(string input, int n, char firstChar)
        {
            if (String.IsNullOrEmpty(input)) throw new ArgumentException("input cannot be null or empty.");
            if (n < 1) throw new ArgumentException("n must be 1 or higher.");

            int result = 0;
            int pow = 1;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                char chr = input[i];
                int digitValue = chr - firstChar;

                checked
                {
                    result += digitValue * pow;

                    if (i > 0) // Prevent overflow
                    {
                        pow *= n;
                    }
                }
            }
            return result;
        }

        // Helpers

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
    }
}
