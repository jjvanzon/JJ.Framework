        //string currentAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        //string dummyProjectName    = currentAssemblyName + ".Dummy"; // By convention the dummy project is named same as test project it's executed from + ".Dummy"
        //_dummyCsprojFileName          = dummyProjectName + ".csproj"; // E.g. "JJ.Framework.Configuration.Legacy.Tests.Dummy.csproj";



    <!-- Targets file included and written to temp test dummy project, but not actually referenced by test dummy project -->
    <!--<EmbeddedResource Include="..\JJ.Framework.Configuration\build\JJ.Framework.Configuration.Legacy.targets" Link="TestResources\%(Filename)%(Extension)" />-->
