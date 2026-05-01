namespace JJ.Framework.Configuration.Core.Tests;

/// <summary> Integration tests for JJ.Framework.Configuration.Core.targets. </summary>
[TestClass]
public class CopyConfigTargetsTests
{
    private const string _assemblyConfigFileName = "TestAssembly.dll.config";
    private const string _testhostConfigFileName = "testhost.dll.config";
    private const string _ncrunchConfigFileName  = "nCrunch.TaskRunner.DotNetCore.20.x64.dll.config";

    //private static readonly string _csprojContent         = GetResource("JJ.Framework.Configuration.Core.Tests.csproj");
    private static readonly string _csprojContent         = BuildCsProjContent();
    private static readonly string _appConfigContent      = GetResource("app.config");
    private static readonly string _webConfigContent      = GetResource("web.config");
    private static readonly string _assemblyConfigContent = BuildConfigContent("assembly");
    private static readonly string _testHostConfigContent = GetResource("testhost.dll.config");
    private const           string _dummyCsFileContent    = "// Dummy Code";

    private readonly string _tempProjDir;
    private readonly string _outDir;
    private readonly string _csprojFilePath;
    private readonly string _dummyCsFilePath;
    private readonly string _appConfigFilePath;
    private readonly string _webConfigFilePath;
    private readonly string _sourceAssemblyConfigFilePath;
    private readonly string _sourceTestHostConfigFilePath;
    private readonly string _destAssemblyConfigFilePath;
    private readonly string _destTestHostConfigFilePath;
    private readonly string _destNCrunchConfigFilePath;

    public CopyConfigTargetsTests()
    {
        _tempProjDir                  = Path.Combine(Path.GetTempPath(), "JJ.CopyConfigTests", Guid.NewGuid().ToString("N"));
        _outDir                       = Path.Combine(_tempProjDir, "out");
        _csprojFilePath               = Path.Combine(_tempProjDir, "TestAssembly.csproj");
        _dummyCsFilePath              = Path.Combine(_tempProjDir, "Placeholder.cs");
        _appConfigFilePath            = Path.Combine(_tempProjDir, "app.config");
        _webConfigFilePath            = Path.Combine(_tempProjDir, "web.config");
        _sourceAssemblyConfigFilePath = Path.Combine(_tempProjDir, "TestAssembly.dll.config");
        _sourceTestHostConfigFilePath = Path.Combine(_tempProjDir, "testhost.dll.config");
        _destAssemblyConfigFilePath   = Path.Combine(_outDir, _assemblyConfigFileName);
        _destTestHostConfigFilePath   = Path.Combine(_outDir, _testhostConfigFileName);
        _destNCrunchConfigFilePath    = Path.Combine(_outDir, _ncrunchConfigFileName);
        CreateTempDir();
        WriteCsproj();
        WritePlaceholder();
    }
    
    private static string GetResource(string fileName) 
        => GetEmbeddedResourceText(GetExecutingAssembly(), "TestResources", fileName);

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
    private void WriteCsproj()         => WriteAllText(_csprojFilePath,               _csprojContent        );
    private void WritePlaceholder()    => WriteAllText(_dummyCsFilePath,              _dummyCsFileContent   );
    private void WriteAppConfig()      => WriteAllText(_appConfigFilePath,            _appConfigContent     );
    private void WriteWebConfig()      => WriteAllText(_webConfigFilePath,            _webConfigContent     );
    private void WriteAssemblyConfig() => WriteAllText(_sourceAssemblyConfigFilePath, _assemblyConfigContent);
    private void WriteTesthostConfig() => WriteAllText(_sourceTestHostConfigFilePath, _testHostConfigContent);

    private void DotNetBuild()
    {
        const string fileName = "dotnet";
        string arguments = $"build --nologo -o \"{_outDir}\"";
        using var process = Process.Start(new ProcessStartInfo
        {
            FileName               = fileName,
            Arguments              = arguments,
            WorkingDirectory       = _tempProjDir,
            RedirectStandardOutput = true,
            RedirectStandardError  = true,
            UseShellExecute        = false,
            CreateNoWindow         = true
        })!;

        process.WaitForExit();

        bool hasExitCode = process.ExitCode != 0;
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        bool hasErrorText = !IsNullOrWhiteSpace(error);
        bool hasErrorInOutput = output.Contains("[error]");
        bool hasError = hasExitCode || hasErrorInOutput; // Don't consider error text, which has welcome messages and such in it these days.

        if (hasError)
        {
            throw new Exception(
                $"{fileName} {arguments} failed " +
                $"{new { hasExitCode, hasErrorText, hasErrorInOutput }}: " +
                $"Exit code {process.ExitCode} {error} {output}");
        }
    }
    
    private static string BuildConfigContent(string configValue) =>
        $"""
        <?xml version="1.0" encoding="utf-8"?>
        <configuration>
          <appSettings>
            <add key="source" value="{configValue}" />
          </appSettings>
        </configuration>
        """;

    private static string BuildCsProjContent()
    {
        var buildTargetsFilePath = GetBuildTargetsFilePath();

        // TODO: TargetFramework should be the current one.
        string content =
            $"""
            <Project Sdk="Microsoft.NET.Sdk">
              <PropertyGroup>
                <TargetFramework>net8.0</TargetFramework>
                <AssemblyName>TestAssembly</AssemblyName>
              </PropertyGroup>
              <Import Project="{buildTargetsFilePath}" />
            </Project>
            """;

        return content;
    }

    private static string GetBuildTargetsFilePath()
    {
        string? testProjDir = AppContext.BaseDirectory;
        while (!Directory.GetFiles(testProjDir, "*.csproj").Any())
        {
            testProjDir = Path.GetDirectoryName(testProjDir) ?? throw new InvalidOperationException("Could not locate test project directory.");
        }

        string mainProjDir = Path.Combine(testProjDir, "..", "Configuration.Core");

        string filePath = Path.Combine(mainProjDir, "build", "JJ.Framework.Configuration.Core.targets");
        filePath = Path.GetFullPath(filePath);
        filePath = filePath.Replace("\\", "/");
        return filePath;
    }
}
