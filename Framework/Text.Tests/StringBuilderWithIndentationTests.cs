using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Environment;

// ReSharper disable UseObjectOrCollectionInitializer
// ReSharper disable ConvertToConstant.Local

#pragma warning disable IDE0017 // Simplify object initialization

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
        public void Test_StringBuilderWithIndentation_TabString_Tab_IsDefault()
        {
            // Act
            var sb = new StringBuilderWithIndentation();

            sb.AppendLine("Text1");
            sb.Indent();
            {
                sb.AppendLine("Text2");
                sb.Indent();
                {
                    sb.AppendLine("Text3");
                    sb.Unindent();
                }
                sb.AppendLine("Text4");
                sb.Unindent();
            }
            sb.AppendLine("Text5");

            // Assert
            string actualText = sb.ToString();
            string expectedText =
                "Text1" + NewLine +
                "\tText2" + NewLine +
                "\t\tText3" + NewLine +
                "\tText4" + NewLine +
                "Text5" + NewLine;

            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_TabString_Spaces_IsAnAlternative()
        {
            // Act
            var sb = new StringBuilderWithIndentation("    ");

            sb.AppendLine("Text1");
            sb.Indent();
            {
                sb.AppendLine("Text2");
                sb.Indent();
                {
                    sb.AppendLine("Text3");
                    sb.Unindent();
                }
                sb.AppendLine("Text4");
                sb.Unindent();
            }
            sb.AppendLine("Text5");

            // Assert
            string actualText = sb.ToString();
            string expectedText =
                "Text1" + NewLine +
                "    Text2" + NewLine +
                "        Text3" + NewLine +
                "    Text4" + NewLine +
                "Text5" + NewLine;

            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_TabString_NullOrEmpty_IsOK()
        {
            // Act
            var sb = new StringBuilderWithIndentation(tabString: "");
            sb = new StringBuilderWithIndentation(tabString: null);

            sb.AppendLine("Text1");
            sb.Indent();
            {
                sb.AppendLine("Text2");
                sb.Indent();
                {
                    sb.AppendLine("Text3");
                    sb.Unindent();
                }
                sb.AppendLine("Text4");
                sb.Unindent();
            }
            sb.AppendLine("Text5");

            // Assert
            string actualText = sb.ToString();
            string expectedText =
                "Text1" + NewLine +
                "Text2" + NewLine +
                "Text3" + NewLine +
                "Text4" + NewLine +
                "Text5" + NewLine;

            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_ToString()
        {
            // Arrange
            var sb = new StringBuilderWithIndentation("    ");

            sb.AppendLine("Text1");
            sb.Indent();
            { 
                sb.AppendLine("Text2");
            }

            // Act
            string actualText = sb.ToString();

            // Assert
            string expectedText =
                "Text1" + NewLine +
                "    Text2" + NewLine;
            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_Indent()
        {
            // Arrange
            var sb = new StringBuilderWithIndentation("    ");
            sb.AppendLine("Text1");

            // Act
            sb.Indent();

            // Assert
            sb.AppendLine("Text2");
            string actualText = sb.ToString();
            string expectedText =
                "Text1" + NewLine +
                "    Text2" + NewLine;
            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_Unindent()
        {
            // Arrange
            var sb = new StringBuilderWithIndentation("    ");
            sb.AppendLine("Text1");
            sb.Indent();
            {
                sb.AppendLine("Text2");
            }

            // Act
            sb.Unindent();

            // Assert
            sb.AppendLine("Text3");
            string actualText = sb.ToString();
            string expectedText =
                "Text1" + NewLine +
                "    Text2" + NewLine +
                "Text3" + NewLine;
            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_AppendLine_WithoutText()
        {
            // Arrange
            var sb = new StringBuilderWithIndentation();
            
            // Act
            sb.AppendLine();
            sb.AppendLine();

            // Assert.
            string actualText = sb.ToString();
            string expectedText = NewLine + NewLine;
            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_AppendLine_WithText()
        {
            // Arrange
            var sb = new StringBuilderWithIndentation();

            // Act
            sb.AppendLine("Text1");
            sb.AppendLine("Text2");

            // Assert.
            string actualText = sb.ToString();
            string expectedText =
                "Text1" + NewLine +
                "Text2" + NewLine;
            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_AppendLine_AppendsTabsBeforeLineNotAfter()
        {
            // Arrange
            var sb = new StringBuilderWithIndentation();

            // Act
            sb.Indent();
            sb.AppendLine("Text");

            // Assert.
            string actualText = sb.ToString();
            string expectedText = "\tText" + NewLine;
            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_Append()
        {
            // Arrange
            var sb = new StringBuilderWithIndentation();

            // Act
            sb.Append("Text1");
            sb.Append(" ");
            sb.Append("Text2");

            // Assert.
            string actualText = sb.ToString();
            string expectedText = "Text1 Text2";
            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_Append_RequiresManualAppendTabs()
        {
            // Arrange
            var sb = new StringBuilderWithIndentation("    ");

            // Act
            sb.Indent();
            sb.AppendTabs();
            sb.Append("Text");

            // Assert
            string actualText = sb.ToString();
            string expectedText = "    Text";
            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_Append_WithoutManualAppendTabs_AddsNoTabs()
        {
            // Arrange
            var sb = new StringBuilderWithIndentation("    ");

            // Act
            sb.Indent();
            sb.Append("Text");

            // Assert
            string actualText = sb.ToString();
            string expectedText = "Text";
            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_Append_Requires_AppendingNewLine_ToCompleteAFullLine()
        {
            // Arrange
            var sb = new StringBuilderWithIndentation();

            // Act
            sb.Append("Text");
            sb.Append(NewLine);

            // Assert
            string actualText = sb.ToString();
            string expectedText = "Text" + NewLine;
            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_AppendFormat()
        {
            // Arrange
            string generatedClassName = "MyClass";
            var sb = new StringBuilderWithIndentation();

            // Act
            sb.AppendFormat("public class {0}", generatedClassName);

            // Assert
            string actualText = sb.ToString();
            string expectedText = "public class MyClass";
            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_IndentLevel_Set()
        {
            // Arrange
            var sb = new StringBuilderWithIndentation("    ");

            // Act
            sb.IndentLevel = 0;
            sb.AppendLine("Text1");
            {
                sb.IndentLevel = 1;
                sb.AppendLine("Text2");
                {
                    sb.IndentLevel = 2;
                    sb.AppendLine("Text3");
                }
                sb.IndentLevel = 1;
                sb.AppendLine("Text4");
            }
            sb.IndentLevel = 0;
            sb.AppendLine("Text5");

            // Assert
            string actualText = sb.ToString();
            string expectedText =
                "Text1" + NewLine +
                "    Text2" + NewLine +
                "        Text3" + NewLine +
                "    Text4" + NewLine +
                "Text5" + NewLine;
            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_IndentLevel_Get()
        {
            var sb = new StringBuilderWithIndentation();

            AssertHelper.AreEqual(0, () => sb.IndentLevel);
            sb.Indent();
            {
                AssertHelper.AreEqual(1, () => sb.IndentLevel);
                sb.Indent();
                {
                    AssertHelper.AreEqual(2, () => sb.IndentLevel);
                    sb.Unindent();
                }
                AssertHelper.AreEqual(1, () => sb.IndentLevel);
                sb.Indent();
                {
                    AssertHelper.AreEqual(2, () => sb.IndentLevel);
                    sb.Unindent();
                }
                AssertHelper.AreEqual(1, () => sb.IndentLevel);
                sb.Unindent();
            }
            AssertHelper.AreEqual(0, () => sb.IndentLevel);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_IndentLevel_LessThan0_ThrowsException()
        {
            var sb = new StringBuilderWithIndentation();
            AssertHelper.ThrowsException(() => sb.IndentLevel = -1, "value cannot be less than 0.");
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_AppendTabs()
        {
            // Arrange
            var sb = new StringBuilderWithIndentation();
            sb.IndentLevel = 2;

            // Act
            sb.AppendTabs();

            // Assert
            string actualText = sb.ToString();
            string expectedText = "\t\t";
            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_StringBuilderWithIndentation_GetTabs_ReturnsRepeatedTabStrings()
        {
            // Arrange
            var sb = new StringBuilderWithIndentation("    ");
            sb.IndentLevel = 2;

            // Act
            string actualTabs = sb.GetTabs();

            // Assert
            string expectedTabs = "        ";
            AssertHelper.AreEqual(expectedTabs, () => actualTabs);
        }
    }
}
