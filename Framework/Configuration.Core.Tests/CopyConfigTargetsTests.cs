using JJ.Framework.Compilation.Core;

namespace JJ.Framework.Configuration.Core.Tests;

/// <summary> Integration tests for JJ.Framework.Configuration.Core.targets. </summary>
[TestClass]
[DoNotParallelize]
public class CopyConfigTargetsTests : IDisposable
{
    private const int BuildTimeOutSec = 240;

    private const string _dummyCsprojFileName    = "JJ.Framework.Configuration.Core.Tests.Dummy.csproj";
    private const string _assemblyConfigFileName = "JJ.Framework.Configuration.Core.Tests.Dummy.dll.config";
    private const string _targetsFileName        = "JJ.Framework.Configuration.Core.targets";
    private const string _dummyCsFileName        = "DummyTests.cs";
    private const string _testhostConfigFileName = "testhost.dll.config";
    private const string _ncrunchConfigFileName  = "nCrunch.TaskRunner.DotNetCore.20.x64.dll.config";

    private readonly string _csprojContent         = GetResource(_dummyCsprojFileName);
    private static readonly string _dummyCsFileContent    = GetResource(_dummyCsFileName);
    private static readonly string _targetsFileContent    = GetResource(_targetsFileName);
    private static readonly string _assemblyConfigContent = GetResource(_assemblyConfigFileName);
    private static readonly string _appConfigContent      = GetResource("app.config");
    private static readonly string _webConfigContent      = GetResource("web.config");
    private static readonly string _testHostConfigContent = GetResource("testhost.dll.config");

    private readonly DotNetOptions _options;
    private readonly string _tempSolutionDir;
    private readonly string _tempProjDir;
    private readonly string _targetsDir;
    private readonly string _targetsFilePath;
    private readonly string _csprojFilePath;
    private readonly string _dummyCsFilePath;
    private readonly string _appConfigFilePath;
    private readonly string _webConfigFilePath;
    private readonly string _sourceAssemblyConfigFilePath;
    private readonly string _sourceTestHostConfigFilePath;
    private readonly string _destAssemblyConfigFilePath;
    private readonly string _outDir;
    private readonly string _destTestHostConfigFilePath;
    private readonly string _destNCrunchConfigFilePath;

    public CopyConfigTargetsTests()
    {
        _tempSolutionDir              = Path.Combine(Path.GetTempPath(), "JJ.Framework.Configuration.Core.TestRuns", Path.GetRandomFileName().Replace(".", ""));
        _tempProjDir                  = Path.Combine(_tempSolutionDir, "Configuration.Core.Tests.Dummy");
        _targetsDir                   = Path.GetFullPath(Path.Combine(_tempProjDir, "..", "Configuration.Core", "build"));
        _csprojFilePath               = Path.Combine(_tempProjDir, _dummyCsprojFileName);
        _targetsFilePath              = Path.Combine(_targetsDir, _targetsFileName);
        _dummyCsFilePath              = Path.Combine(_tempProjDir, _dummyCsFileName);
        _appConfigFilePath            = Path.Combine(_tempProjDir, "app.config");
        _webConfigFilePath            = Path.Combine(_tempProjDir, "web.config");
        _sourceAssemblyConfigFilePath = Path.Combine(_tempProjDir, _assemblyConfigFileName);
        _sourceTestHostConfigFilePath = Path.Combine(_tempProjDir, _testhostConfigFileName);
        _outDir                       = Path.Combine(_tempProjDir, "bin", "Release", DotNet.RunningTargetFramework);
        _destAssemblyConfigFilePath   = Path.Combine(_outDir, _assemblyConfigFileName);
        _destTestHostConfigFilePath   = Path.Combine(_outDir, _testhostConfigFileName);
        _destNCrunchConfigFilePath    = Path.Combine(_outDir, _ncrunchConfigFileName);

        // This seems to cause time-outs.
        //_csprojContent = PatchTargetFramework(_csprojContent);

        _options = new DotNetOptions { Dir = _tempProjDir, TimeOutSec = BuildTimeOutSec, Conf = "Release" };

        CreateTempDir();
        CreateTargetsDir();
        WriteCsproj();
        WriteDummyCsFile();
        WriteTargetsFile();
    }

    private static string GetResource(string fileName) 
        => GetEmbeddedResourceText(GetExecutingAssembly(), "TestResources", fileName);
    
    /// <summary>
    /// Deletes the isolated temp folder and all its contents.
    /// </summary>
    internal void Cleanup()
    {
        try
        {
            if (Directory.Exists(_tempSolutionDir))
            {
                Directory.Delete(_tempSolutionDir, recursive: true);
            }
        }
        catch
        {
            // Ignore
        }
    }

    void IDisposable.Dispose()
    {
        Cleanup();
        GC.SuppressFinalize(this);
    }

    ~CopyConfigTargetsTests() => Cleanup(); // ncrunch: no coverage

    // Tests

    [TestMethod]
    public void JJ_CopyConfig_WhenAppConfig_CopiesConfigToOutput()
    {
        WriteAppConfig();
        DotNetBuild();
        IsTrue(Exists(_destAssemblyConfigFilePath));
        IsTrue(Exists(_destTestHostConfigFilePath));
        IsTrue(Exists(_destNCrunchConfigFilePath));
        AreEqual(_appConfigContent, ReadAllText(_destAssemblyConfigFilePath));
        AreEqual(_appConfigContent, ReadAllText(_destTestHostConfigFilePath));
        AreEqual(_appConfigContent, ReadAllText(_destNCrunchConfigFilePath));
    }

    [TestMethod]
    public void JJ_CopyConfig_WhenWebConfig_CopiesConfigToOutput()
    {
        WriteWebConfig();
        DotNetBuild();
        IsTrue(Exists(_destAssemblyConfigFilePath));
        IsTrue(Exists(_destTestHostConfigFilePath));
        IsTrue(Exists(_destNCrunchConfigFilePath));
        AreEqual(_webConfigContent, ReadAllText(_destAssemblyConfigFilePath));
        AreEqual(_webConfigContent, ReadAllText(_destTestHostConfigFilePath));
        AreEqual(_webConfigContent, ReadAllText(_destNCrunchConfigFilePath));
    }

    [TestMethod]
    public void JJ_CopyConfig_WhenAssemblyNameConfig_CopiesConfigToOutput()
    {
        WriteAssemblyConfig();
        DotNetBuild();
        IsTrue(Exists(_destAssemblyConfigFilePath));
        IsTrue(Exists(_destTestHostConfigFilePath));
        IsTrue(Exists(_destNCrunchConfigFilePath));
        AreEqual(_assemblyConfigContent, ReadAllText(_destAssemblyConfigFilePath));
        AreEqual(_assemblyConfigContent, ReadAllText(_destTestHostConfigFilePath));
        AreEqual(_assemblyConfigContent, ReadAllText(_destNCrunchConfigFilePath));
    }

    [TestMethod]
    public void JJ_CopyConfig_WhenTestHostConfig_CopiesConfigToOutput()
    {
        WriteTesthostConfig();
        DotNetBuild();
        IsTrue(Exists(_destAssemblyConfigFilePath));
        IsTrue(Exists(_destTestHostConfigFilePath));
        IsTrue(Exists(_destNCrunchConfigFilePath));
        AreEqual(_testHostConfigContent, ReadAllText(_destAssemblyConfigFilePath));
        AreEqual(_testHostConfigContent, ReadAllText(_destTestHostConfigFilePath));
        AreEqual(_testHostConfigContent, ReadAllText(_destNCrunchConfigFilePath));
    }

    [TestMethod]
    public void JJ_CopyConfig_WhenNoConfig_DoesNotCopyConfig()
    {
        DotNetBuild();
        IsFalse(Exists(_destAssemblyConfigFilePath));
        IsFalse(Exists(_destTestHostConfigFilePath));
        IsFalse(Exists(_destNCrunchConfigFilePath));
    }

    [TestMethod]
    public void JJ_CopyConfig_WhenAppConfigAndWebConfig_AppConfigWins()
    {
        WriteAppConfig();
        WriteWebConfig();
        DotNetBuild();
        IsTrue(Exists(_destAssemblyConfigFilePath));
        IsTrue(Exists(_destTestHostConfigFilePath));
        IsTrue(Exists(_destNCrunchConfigFilePath));
        AreEqual(_appConfigContent, ReadAllText(_destAssemblyConfigFilePath));
        AreEqual(_appConfigContent, ReadAllText(_destTestHostConfigFilePath));
        AreEqual(_appConfigContent, ReadAllText(_destNCrunchConfigFilePath));
    }

    [TestMethod]
    public void JJ_CopyConfig_WhenAppConfigAndTesthostConfig_AppConfigWins()
    {
        WriteAppConfig();
        WriteTesthostConfig();
        DotNetBuild();
        IsTrue(Exists(_destAssemblyConfigFilePath));
        IsTrue(Exists(_destTestHostConfigFilePath));
        IsTrue(Exists(_destNCrunchConfigFilePath));
        AreEqual(_appConfigContent, ReadAllText(_destAssemblyConfigFilePath));
        AreEqual(_appConfigContent, ReadAllText(_destTestHostConfigFilePath));
        AreEqual(_appConfigContent, ReadAllText(_destNCrunchConfigFilePath));
    }

    // Helpers

    private void CreateTempDir()       => Directory.CreateDirectory(_tempProjDir);
    private void CreateTargetsDir()    => Directory.CreateDirectory(_targetsDir);
    private void WriteCsproj()         => WriteAllText(_csprojFilePath,               _csprojContent        );
    private void WriteTargetsFile()    => WriteAllText(_targetsFilePath,              _targetsFileContent   );
    private void WriteDummyCsFile()    => WriteAllText(_dummyCsFilePath,              _dummyCsFileContent   );
    private void WriteAppConfig()      => WriteAllText(_appConfigFilePath,            _appConfigContent     );
    private void WriteWebConfig()      => WriteAllText(_webConfigFilePath,            _webConfigContent     );
    private void WriteAssemblyConfig() => WriteAllText(_sourceAssemblyConfigFilePath, _assemblyConfigContent);
    private void WriteTesthostConfig() => WriteAllText(_sourceTestHostConfigFilePath, _testHostConfigContent);

    /// <summary>
    /// Replacing TargetFramework(s) in the content avoids tooling issues with -p:TargetFrameworks= overrides.
    /// </summary>
    private static string PatchTargetFramework(string csprojContent)
    {
        csprojContent = Regex.Replace(csprojContent, "<TargetFrameworks>[^<]*</TargetFrameworks>", $"<TargetFrameworks>{DotNet.RunningTargetFramework}</TargetFrameworks>");
        csprojContent = Regex.Replace(csprojContent, "<TargetFramework>[^<]*</TargetFramework>",  $"<TargetFramework>{DotNet.RunningTargetFramework}</TargetFramework>");
        return csprojContent;
    }

    private void DotNetBuild()
    {
        DotNet.Restore(_options);
        DotNet.Build(_options);
    }
}
