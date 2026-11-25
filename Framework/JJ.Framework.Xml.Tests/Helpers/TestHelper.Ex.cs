namespace JJ.Framework.Xml.Tests.Helpers;

internal static partial class TestHelper
{
    public static string GetComplexExampleXml()
    {
        Assembly assembly = GetExecutingAssembly();
        //string rootNameSpace = assembly.GetName().Name;
        const string rootNameSpace = "JJ.Framework.Xml.Tests";
        const string fileName = "ComplicatedExample.xml";
        const string subNamespace = "TestResources";

        string resourceName = String.Format("{0}.{1}.{2}", rootNameSpace, subNamespace, fileName);

        Stream stream = assembly.GetManifestResourceStream(resourceName);

        if (stream == null)
        {
            throw new Exception(String.Format("Embedded resource '{0}' not found.", GetEmbeddedResourceName(assembly, "TestResources", "ComplicatedExample.xml")));
        }

        using (stream)
        {
            return new StreamReader(stream).ReadToEnd();
        }
    }
}
