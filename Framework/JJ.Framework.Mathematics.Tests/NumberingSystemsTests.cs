using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Mathematics.Tests
{
    [TestClass]
    public class NumberingSystemsTests
    {
        // To Base-N Number

        [TestMethod]
        public void Test_NumberingSystems_ToBaseNNumber_Base26_RandomNumber()
        {
            int number = Randomizer.GetInt32(Int32.MaxValue - 1);
            string output = NumberingSystems.ToBaseNNumber(number, 26, 'a');
        }

        [TestMethod]
        public void Test_NumberingSystems_ToBaseNNumber_DecimalSystem_1234()
        {
            string output = NumberingSystems.ToBaseNNumber(1234, 10);
            Assert.AreEqual("1234", output);
        }

        [TestMethod]
        public void Test_NumberingSystems_ToBaseNNumber_DecimalSystem_0To100()
        {
            for (int i = 0; i <= 100; i++)
            {
                string output = NumberingSystems.ToBaseNNumber(i, 10);
                Assert.AreEqual(i.ToString(), output);
            }
        }

        [TestMethod]
        public void Test_NumberingSystems_ToHex_1234()
        {
            int number = 1234;
            string output = NumberingSystems.ToHex(number);
        }

        [TestMethod]
        public void Test_NumberingSystems_ToHex_0To9()
        {
            for (int i = 0; i <= 9; i++)
            {
                string expected = i.ToString();
                string actual = NumberingSystems.ToHex(i);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void Test_NumberingSystems_ToHex_10To15()
        {
            for (int i = 10; i <= 15; i++)
            {
                char expectedChar = (char)(i - 10 + 'A');
                string expected = Convert.ToString(expectedChar);
                string actual = NumberingSystems.ToHex(i);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void Test_NumberingSystems_ToHex_16To25()
        {
            for (int i = 16; i <= 25; i++)
            {
                char expectedSecondChar = (char)(i - 16 + '0');
                char[] expectedChars = new char[] { '1', expectedSecondChar };
                string expected = new String(expectedChars);
                string actual = NumberingSystems.ToHex(i);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void Test_NumberingSystems_ToHex_26To31()
        {
            for (int i = 26; i <= 31; i++)
            {
                char expectedSecondChar = (char)(i - 26 + 'A');
                char[] expectedChars = new char[] { '1', expectedSecondChar };
                string expected = new String(expectedChars);
                string actual = NumberingSystems.ToHex(i);
                Assert.AreEqual(expected, actual);
            }
        }

        // From Base-N Number

        [TestMethod]
        public void Test_NumberingSystems_FromBaseNNumber_Base26_0To51()
        {
            for (int i = 0; i < 25; i++)
            {
                char expectedChar = (char)('a' + i);
                string expected = expectedChar.ToString();
                string actual = NumberingSystems.ToBaseNNumber(i, 26, 'a');
                Assert.AreEqual(expected, actual);
            }

            for (int i = 26; i < 51; i++)
            {
                char expectedSecondChar = (char)('a' + i - 26);

                // It turns out this does not result in spreadsheet-style column 'numerals',
                // A is the 0.
                // A would be the same as AA
                // and after Z comes BA, not AA.
                // So Excel column numerals do not map nicely to a base-n numbering system after all.
                
                string expected = new String(new char[] { 'b', expectedSecondChar });
                string actual = NumberingSystems.ToBaseNNumber(i, 26, 'a');
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void Test_NumberingSystems_FromBaseNNumber_DecimalSystem_1234()
        {
            string input = "1234";
            int output = NumberingSystems.FromBaseNNumber(input, 10);
            Assert.AreEqual(1234, output);
        }

        [TestMethod]
        public void Test_NumberingSystems_FromHex()
        {
            string hex = "E124B";
            int number = NumberingSystems.FromHex(hex);
        }

        // Letter Sequences

        [TestMethod]
        public void Test_NumberingSystems_ToLetterSequence()
        {
            int count = 26 +
                        26 * 26 +
                        26 * 26 * 26;

            string[] results = new string[count];

            for (int i = 0; i < count; i++)
            {
                string letters = NumberingSystems.ToLetterSequence(i, '0', '9');

                results[i] = i.ToString().PadLeft(5) + " - " + letters;
            }

            string resultsConcat = String.Join(Environment.NewLine, results);
        }

        [TestMethod]
        public void Test_NumberingSystems_FromLetterSequence()
        {
            // This test depends on that ToLetterSequence works correctly.
            int count = 100000;

            string[] results = new string[count];

            for (int i = 0; i < count; i++)
            {
                string letters = NumberingSystems.ToLetterSequence(i, '0', '9'); 
                int value = NumberingSystems.FromLetterSequence(letters, '0', '9');

                Assert.AreEqual(i, value);
            }
        }
    }
}
