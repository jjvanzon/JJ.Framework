```xml
    <!--<RootNameSpace>JJ.Framework.Xml.Legacy.Tests</RootNameSpace>-->
     <!-- Then squelch warning Namespace != Folder -->
    <!--<NoWarn>$(NoWarn);IDE0130</NoWarn>-->

          <!--LogicalName="JJ.Framework.Xml.Legacy.Tests.TestResources.ComplicatedExample.xml" />-->

                <!--LogicalName="JJ.Framework.Xml.Legacy.Tests.TestResources.ComplicatedExample.xml" />-->
```

```cs

                    /// <summary>
    /// EmbeddedResourceHelper cannot be used,
    /// because it assumes the resource name is prefixed
    /// with the current assembly name.
    /// But in the TrimTests it would be prefixed
    /// with ... something else.
    /// </summary>



        Assembly assembly = GetExecutingAssembly();

        string rootNameSpace = assembly.GetName().Name;

        //const string rootNameSpace = "JJ.Framework.Xml.Legacy.Tests";
        const string fileName = "ComplicatedExample.xml";
        const string subNamespace = "TestResources";

        
        string resourceName = $"{rootNameSpace}.{subNamespace}.{fileName}";

        Stream stream = assembly.GetManifestResourceStream(resourceName);

        if (stream == null)
        {
            throw new Exception($"Embedded resource '{resourceName}' not found.");
        }

        return StreamToString(stream, Encoding.UTF8);
```