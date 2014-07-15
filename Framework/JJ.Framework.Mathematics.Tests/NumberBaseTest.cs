using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Mathematics.Tests
{
    [TestClass]
    public class NumberBaseTest
    {
        // To Base-N Number

        [TestMethod]
        public void Test_NumberBase_ToBaseNNumber_Base26_RandomNumber()
        {
            int number = Randomizer.GetInt32(Int32.MaxValue - 1);
            string output = NumberBase.ToBaseNNumber(number, 26, 'a');
        }

        [TestMethod]
        public void Test_NumberBase_ToBaseNNumber_DecimalSystem_1234()
        {
            string output = NumberBase.ToBaseNNumber(1234, 10);
            Assert.AreEqual("1234", output);
        }

        [TestMethod]
        public void Test_NumberBase_ToBaseNNumber_DecimalSystem_0To100()
        {
            for (int i = 0; i <= 100; i++)
            {
                string output = NumberBase.ToBaseNNumber(i, 10);
                Assert.AreEqual(i.ToString(), output);
            }
        }

        [TestMethod]
        public void Test_NumberBase_ToHex_1234()
        {
            int number = 1234;
            string output = NumberBase.ToHex(number);
        }

        [TestMethod]
        public void Test_NumberBase_ToHex_0To9()
        {
            for (int i = 0; i <= 9; i++)
            {
                string expected = i.ToString();
                string actual = NumberBase.ToHex(i);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void Test_NumberBase_ToHex_10To15()
        {
            for (int i = 10; i <= 15; i++)
            {
                char expectedChar = (char)(i - 10 + 'A');
                string expected = Convert.ToString(expectedChar);
                string actual = NumberBase.ToHex(i);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void Test_NumberBase_ToHex_16To25()
        {
            for (int i = 16; i <= 25; i++)
            {
                char expectedSecondChar = (char)(i - 16 + '0');
                char[] expectedChars = new char[] { '1', expectedSecondChar };
                string expected = new String(expectedChars);
                string actual = NumberBase.ToHex(i);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void Test_NumberBase_ToHex_26To31()
        {
            for (int i = 26; i <= 31; i++)
            {
                char expectedSecondChar = (char)(i - 26 + 'A');
                char[] expectedChars = new char[] { '1', expectedSecondChar };
                string expected = new String(expectedChars);
                string actual = NumberBase.ToHex(i);
                Assert.AreEqual(expected, actual);
            }
        }

        // From Base-N Number

        [TestMethod]
        public void Test_NumberBase_FromBaseNNumber_Base26_0To51()
        {
            for (int i = 0; i < 25; i++)
            {
                char expectedChar = (char)('a' + i);
                string expected = expectedChar.ToString();
                string actual = NumberBase.ToBaseNNumber(i, 26, 'a');
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
                string actual = NumberBase.ToBaseNNumber(i, 26, 'a');
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void Test_NumberBase_FromBaseNNumber_DecimalSystem_1234()
        {
            string input = "1234";
            int output = NumberBase.FromBaseNNumber(input, 10);
            Assert.AreEqual(1234, output);
        }

        [TestMethod]
        public void Test_NumberBase_FromHex()
        {
            string hex = "E124B";
            int number = NumberBase.FromHex(hex);
        }
    }
}
