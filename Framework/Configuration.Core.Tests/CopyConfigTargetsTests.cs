using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.IO.File;
using static System.String;

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
        string targetFramework = GetCurrentTargetFrameworkMoniker();
        string? localTargetsPath = TryGetLocalBuildTargetsFilePath();

        string configImport = localTargetsPath != null
            ? $"  <Import Project=\"{localTargetsPath}\" />"
            : $"  <ItemGroup><PackageReference Include=\"JJ.Framework.Configuration.Core\" Version=\"{GetInstalledPackageVersion()}\" /></ItemGroup>";

        return
            $"""
            <Project Sdk="Microsoft.NET.Sdk">
              <PropertyGroup>
                <TargetFramework>{targetFramework}</TargetFramework>
                <AssemblyName>TestAssembly</AssemblyName>
              </PropertyGroup>
              {configImport}
            </Project>
            """;
    }

    /// <summary> Returns the local .targets file path when running in source mode; null when running from a package reference. </summary>
    private static string? TryGetLocalBuildTargetsFilePath()
    {
        string dir = AppContext.BaseDirectory;
        while (true)
        {
            if (Directory.GetFiles(dir, "*.csproj").Any())
            {
                string candidate = Path.GetFullPath(
                    Path.Combine(dir, "..", "Configuration.Core", "build", "JJ.Framework.Configuration.Core.targets"));
                return File.Exists(candidate) ? candidate.Replace("\\", "/") : null;
            }
            string? parent = Path.GetDirectoryName(dir);
            if (parent == null || parent == dir) return null;
            dir = parent;
        }
    }

    /// <summary> Finds the highest installed version of JJ.Framework.Configuration.Core in the NuGet global-packages cache. </summary>
    private static string GetInstalledPackageVersion()
    {
        string globalPackages = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            ".nuget", "packages", "jj.framework.configuration.core");

        if (!Directory.Exists(globalPackages))
            throw new InvalidOperationException(
                $"NuGet package 'JJ.Framework.Configuration.Core' not found in global packages cache at: {globalPackages}");

        string[] versionDirs = Directory.GetDirectories(globalPackages);
        if (versionDirs.Length == 0)
            throw new InvalidOperationException(
                $"No versions of 'JJ.Framework.Configuration.Core' found in: {globalPackages}");

        // Pick the highest version folder (simple lexicographic ordering works for semver-like numeric segments here).
        return versionDirs
            .Select(d => Path.GetFileName(d)!)
            .OrderByDescending(v => v)
            .First();
    }

    /// <summary> Returns the TFM string matching the currently-executing runtime, e.g. "net8.0" or "net461". </summary>
    private static string GetCurrentTargetFrameworkMoniker()
    {
        if (RuntimeInformation.FrameworkDescription.StartsWith(".NET Framework", StringComparison.OrdinalIgnoreCase))
            return "net461";

        Version v = Environment.Version;
        return $"net{v.Major}.{v.Minor}";
    }
}
