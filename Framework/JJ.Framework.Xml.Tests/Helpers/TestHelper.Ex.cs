using System.Text;

namespace JJ.Framework.Xml.Tests.Helpers;

internal static partial class TestHelper
{
    public static string GetComplexExampleXml()
    {
        Assembly assembly = GetExecutingAssembly();

        //string rootNameSpace = assembly.GetName().Name;

        const string rootNameSpace = "JJ.Framework.Xml.Legacy.Tests";
        const string fileName = "ComplicatedExample.xml";
        const string subNamespace = "TestResources";
        const string resourceName = $"{rootNameSpace}.{subNamespace}.{fileName}";

        Stream stream = assembly.GetManifestResourceStream(resourceName);

        if (stream == null)
        {
            throw new Exception($"Embedded resource '{resourceName}' not found.");
        }

        return StreamToString(stream, Encoding.UTF8);
    }
}
