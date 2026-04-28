using System.Diagnostics;
using static System.IO.File;

namespace JJ.Framework.Configuration.Core.Tests;

/// <summary> Integration tests for JJ.Framework.Configuration.Core.targets. </summary>
[TestClass]
public class CopyConfigTargetsTests
{
    private const string _assemblyConfigFileName = "TestAssembly.dll.config";
    private const string _testhostConfigFileName = "testhost.dll.config";
    private const string _ncrunchConfigFileName  = "nCrunch.TaskRunner.DotNetCore.20.x64.dll.config";

    private static readonly string _csprojContent         = BuildCsProjContent();
    private static readonly string _appConfigContent      = BuildConfigContent("app");
    private static readonly string _webConfigContent      = BuildConfigContent("web");
    private static readonly string _assemblyConfigContent = BuildConfigContent("assembly");
    private static readonly string _testHostConfigContent = BuildConfigContent("testhost");
    private const           string _dummyCsFileContent    = "// Dummy";


    private string _tempProjDir                  = "";
    private string _outDir                       = "";
    private string _csprojFilePath               = "";
    private string _dummyCsFilePath              = "";
    private string _appConfigFilePath            = "";
    private string _webConfigFilePath            = "";
    private string _sourceAssemblyConfigFilePath = "";
    private string _sourceTestHostConfigFilePath = "";
    private string _destAssemblyConfigFilePath   = "";
    private string _destTestHostConfigFilePath   = "";
    private string _destNCrunchConfigFilePath    = "";


    [TestInitialize]
    public void TestInitialize()
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

    // Tests

    [TestMethod]
    public void JJ_CopyConfig_WhenAppConfig_CopiesConfigToOutput()
    {
        WriteAppConfig();
        DotnetBuild();

        IsTrue(Exists(_destAssemblyConfigFilePath));
        IsTrue(Exists(_destTestHostConfigFilePath));
        IsTrue(Exists(_destNCrunchConfigFilePath));
    }

    [TestMethod]
    public void JJ_CopyConfig_WhenWebConfig_CopiesConfigToOutput()
    {
        WriteWebConfig();
        DotnetBuild();
        IsTrue(Exists(_destAssemblyConfigFilePath));
    }

    [TestMethod]
    public void JJ_CopyConfig_WhenAssemblyNameConfig_CopiesConfigToOutput()
    {
        WriteAssemblyConfig();
        DotnetBuild();
        IsTrue(Exists(_destAssemblyConfigFilePath));
    }

    [TestMethod]
    public void JJ_CopyConfig_WhenTesthostConfig_CopiesConfigToOutput()
    {
        WriteTesthostConfig();
        DotnetBuild();
        IsTrue(Exists(_destAssemblyConfigFilePath));
    }

    [TestMethod]
    public void JJ_CopyConfig_WhenNoConfig_DoesNotCopyConfig()
    {
        DotnetBuild();
        IsFalse(Exists(_destAssemblyConfigFilePath));
    }

    [TestMethod]
    public void JJ_CopyConfig_WhenAppConfigAndWebConfig_AppConfigWins()
    {
        WriteAppConfig();
        WriteWebConfig();
        DotnetBuild();
        IsTrue(ReadAllText(_destAssemblyConfigFilePath).Contains("value=\"app\""));
    }

    [TestMethod]
    public void JJ_CopyConfig_WhenAppConfigAndTesthostConfig_AppConfigWins()
    {
        WriteAppConfig();
        WriteTesthostConfig();
        DotnetBuild();
        IsTrue(ReadAllText(_destAssemblyConfigFilePath).Equals(_appConfigContent));
    }

    // Setup methods

    private void CreateTempDir()       => Directory.CreateDirectory(_tempProjDir);
    private void WriteCsproj()         => WriteAllText(_csprojFilePath,               _csprojContent        );
    private void WritePlaceholder()    => WriteAllText(_dummyCsFilePath,              _dummyCsFileContent   );
    private void WriteAppConfig()      => WriteAllText(_appConfigFilePath,            _appConfigContent     );
    private void WriteWebConfig()      => WriteAllText(_webConfigFilePath,            _webConfigContent     );
    private void WriteAssemblyConfig() => WriteAllText(_sourceAssemblyConfigFilePath, _assemblyConfigContent);
    private void WriteTesthostConfig() => WriteAllText(_sourceTestHostConfigFilePath, _testHostConfigContent);

    private void DotnetBuild()
    {
        var psi = new ProcessStartInfo("dotnet", $"build --nologo -o \"{_outDir}\"")
        {
            WorkingDirectory       = _tempProjDir,
            RedirectStandardOutput = true,
            RedirectStandardError  = true,
            UseShellExecute        = false,
            CreateNoWindow         = true
        };
        using var proc = Process.Start(psi) ?? throw new InvalidOperationException("dotnet build process failed to start.");
        proc.WaitForExit();
        if (proc.ExitCode != 0)
            throw new InvalidOperationException($"dotnet build failed (exit {proc.ExitCode}).");
    }

    // Static helpers
    
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
        string? testProjDir = AppContext.BaseDirectory;
        while (!Directory.GetFiles(testProjDir, "*.csproj").Any())
        {
            testProjDir = Path.GetDirectoryName(testProjDir) ?? throw new InvalidOperationException("Could not locate test project directory.");
        }

        string mainProjDir = Path.Combine(testProjDir, "..", "Configuration.Core");

        string buildTargetsFilePath = Path.Combine(mainProjDir, "build", "JJ.Framework.Configuration.Core.targets");
        buildTargetsFilePath = Path.GetFullPath(buildTargetsFilePath);
        buildTargetsFilePath = buildTargetsFilePath.Replace("\\", "/");

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
}
