using System.Text;

namespace JJ.Framework.Xml.Tests.Helpers;

internal static partial class TestHelper
{
    /// <summary>
    /// EmbeddedResourceHelper cannot be used,
    /// because it assumes the resource name is prefixed
    /// with the current assembly name.
    /// But in the TrimTests it would be prefixed
    /// with ... something else.
    /// </summary>
    public static string GetComplexExampleXml()
    {

        Assembly assembly = GetExecutingAssembly();

        string rootNameSpace = assembly.GetName().Name;

        //const string rootNameSpace = "JJ.Framework.Xml.Legacy.Tests";
        const string fileName = "ComplicatedExample.xml";
        const string subNamespace = "TestResources";

        return GetEmbeddedResourceText(GetExecutingAssembly(), subNamespace, fileName);


        string resourceName = $"{rootNameSpace}.{subNamespace}.{fileName}";

        Stream stream = assembly.GetManifestResourceStream(resourceName);

        if (stream == null)
        {
            throw new Exception($"Embedded resource '{resourceName}' not found.");
        }

        return StreamToString(stream, Encoding.UTF8);
    }
}
