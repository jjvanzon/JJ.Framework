using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Environment;

// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringBuilderWithIndentationTests
    {
        [TestMethod]
        public void Test_StringBuilderWithIndentation_PracticalExample()
        {
            // Arrange
            string generatedClassName = "MyClass";
            string methodBody = "// Put code here...";

            // Act
            var sb = new StringBuilderWithIndentation("    ");

            sb.AppendLine($"public class {generatedClassName}");
            sb.AppendLine("{");
            sb.Indent();
            {
                sb.AppendLine("public void MyMethod()");
                sb.AppendLine("{");
                sb.Indent();
                {
                    sb.AppendLine(methodBody);
                    sb.Unindent();
                }
                sb.AppendLine("}");
                sb.Unindent();
            }
            sb.AppendLine("}");

            // Assert
            string actualText = sb.ToString();
            string expectedText =
                "public class MyClass" + NewLine +
                "{" + NewLine +
                "    public void MyMethod()" + NewLine +
                "    {" + NewLine +
                "        // Put code here..." + NewLine +
                "    }" + NewLine +
                "}" + NewLine;

            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_TabString_NullOrEmpty_IsAccepted()
        {
            // Act
            var sb = new StringBuilderWithIndentation(tabString: "");
            sb = new StringBuilderWithIndentation(tabString: null);

            sb.AppendLine("Text1");
            sb.AppendLine("{");
            sb.Indent();
            {
                sb.AppendLine("Text2");
                sb.AppendLine("{");
                sb.Indent();
                {
                    sb.AppendLine("Text3");
                    sb.Unindent();
                }
                sb.AppendLine("}");
                sb.Unindent();
            }
            sb.AppendLine("}");

            // Assert
            string actualText = sb.ToString();
            string expectedText =
                "Text1" + NewLine +
                "{" + NewLine +
                "Text2" + NewLine +
                "{" + NewLine +
                "Text3" + NewLine +
                "}" + NewLine +
                "}" + NewLine;

            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_TabString_Default_IsTab()
        {
            // Act
            var sb = new StringBuilderWithIndentation();

            sb.AppendLine("Text1");
            sb.AppendLine("{");
            sb.Indent();
            {
                sb.AppendLine("Text2");
                sb.AppendLine("{");
                sb.Indent();
                {
                    sb.AppendLine("Text3");
                    sb.Unindent();
                }
                sb.AppendLine("}");
                sb.Unindent();
            }
            sb.AppendLine("}");

            // Assert
            string actualText = sb.ToString();
            string expectedText =
                "Text1" + NewLine +
                "{" + NewLine +
                "\tText2" + NewLine +
                "\t{" + NewLine +
                "\t\tText3" + NewLine +
                "\t}" + NewLine +
                "}" + NewLine;

            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_TabString_Alternative_UsingSpaces()
        {
            // Act
            var sb = new StringBuilderWithIndentation("    ");

            sb.AppendLine("Text1");
            sb.AppendLine("{");
            sb.Indent();
            {
                sb.AppendLine("Text2");
                sb.AppendLine("{");
                sb.Indent();
                {
                    sb.AppendLine("Text3");
                    sb.Unindent();
                }
                sb.AppendLine("}");
                sb.Unindent();
            }
            sb.AppendLine("}");

            // Assert
            string actualText = sb.ToString();
            string expectedText =
                "Text1" + NewLine +
                "{" + NewLine +
                "    Text2" + NewLine +
                "    {" + NewLine +
                "        Text3" + NewLine +
                "    }" + NewLine +
                "}" + NewLine;

            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        /*
        [TestMethod]
        public void Test_StringBuilderWithIndentation_ToString_ReturnsFormattedText() => throw new NotImplementedException();

        [TestMethod]
        public void Test_StringBuilderWithIndentation_Indent_Works() => throw new NotImplementedException();

        [TestMethod]
        public void Test_StringBuilderWithIndentation_Unindent_Works() => throw new NotImplementedException();

        [TestMethod]
        public void Test_StringBuilderWithIndentation_AppendLine_WithoutText_Works() => throw new NotImplementedException();

        [TestMethod]
        public void Test_StringBuilderWithIndentation_AppendLine_WithText_Works() => throw new NotImplementedException();

        [TestMethod]
        public void Test_StringBuilderWithIndentation_AppendLine_AppendsTabsBeforeLine() => throw new NotImplementedException();

        [TestMethod]
        public void Test_StringBuilderWithIndentation_Append_Works() => throw new NotImplementedException();

        [TestMethod]
        public void Test_StringBuilderWithIndentation_AppendFormat_Works() => throw new NotImplementedException();

        [TestMethod]
        public void Test_StringBuilderWithIndentation_IndentLevel_Assignment_Works() => throw new NotImplementedException();

        [TestMethod]
        public void Test_StringBuilderWithIndentation_IndentLevel_AssigningLessThan0_ThrowsException() => throw new NotImplementedException();

        [TestMethod]
        public void Test_StringBuilderWithIndentation_IndentLevel_ReturnsCorrectValue() => throw new NotImplementedException();

        [TestMethod]
        public void Test_StringBuilderWithIndentation_AppendTabs_Works() => throw new NotImplementedException();

        [TestMethod]
        public void Test_StringBuilderWithIndentation_AppendTabs_UseCase_Calling_Publicly() => throw new NotImplementedException();

        [TestMethod]
        public void Test_StringBuilderWithIndentation_GetTabs_ReturnsCorrectString() => throw new NotImplementedException();
        */
    }
}
