using JJ.Framework.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Demos.Text
{
    [TestClass]
    public class StringBuilderWithIndentationDemoTests
    {
        [TestMethod]
        public void Demo_StringBuilderWithIndentation()
        {
            const string generatedClassName = "MyClass";
            const string methodBody = "// Put code here...";

            var sb = new StringBuilderWithIndentation();

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
        }
    }
}
