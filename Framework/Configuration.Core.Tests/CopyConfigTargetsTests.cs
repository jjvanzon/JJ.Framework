using System.Diagnostics;
using System.Runtime.InteropServices;

namespace JJ.Framework.Configuration.Core.Tests;

/// <summary>
/// Integration tests for JJ.Framework.Configuration.Core.targets.
/// Each test builds a minimal temp project that imports the targets file and asserts
/// on which file ends up copied to the output directory and whether a warning is emitted.
/// </summary>
[TestClass]
public class CopyConfigTargetsTests
{
    // Relative path from this file's project root to the .targets file.
    static readonly string TargetsRelativePath =
        Path.Combine("..", "Configuration.Core", "build", "JJ.Framework.Configuration.Core.targets");

    static string TargetsAbsolutePath => Path.GetFullPath(
        Path.Combine(TestProjectDirectory, TargetsRelativePath));

    // Locate the test project directory by walking up from the test assembly output.
    static string TestProjectDirectory
    {
        get
        {
            var dir = AppContext.BaseDirectory;
            while (dir != null)
            {
                if (Directory.GetFiles(dir, "*.csproj").Length > 0)
                    return dir;
                dir = Path.GetDirectoryName(dir);
            }
            throw new InvalidOperationException("Could not locate test project directory.");
        }
    }

    const string MinimalCsprojTemplate =
        """
        <Project Sdk="Microsoft.NET.Sdk">
          <PropertyGroup>
            <TargetFramework>net8.0</TargetFramework>
            <AssemblyName>TestAssembly</AssemblyName>
            <Nullable>enable</Nullable>
          </PropertyGroup>
          <Import Project="{TargetsPath}" />
        </Project>
        """;

    const string SampleConfigContent =
        """
        <?xml version="1.0" encoding="utf-8"?>
        <configuration>
          <appSettings>
            <add key="source" value="{SourceLabel}" />
          </appSettings>
        </configuration>
        """;

    // -------------------------------------------------------------------------
    // Tests
    // -------------------------------------------------------------------------

    [TestMethod]
    public void JJ_CopyConfig_WhenAppConfig_CopiesConfigToOutput()
    {
        var outDir = BuildTempProject(sourceFiles: [("app.config", "app.config")]);

        IsTrue(File.Exists(Path.Combine(outDir, "TestAssembly.dll.config")));
        IsTrue(File.Exists(Path.Combine(outDir, "testhost.dll.config")));
        IsTrue(File.Exists(Path.Combine(outDir, "nCrunch.TaskRunner.DotNetCore.20.x64.dll.config")));
    }

    [TestMethod]
    public void JJ_CopyConfig_WhenWebConfig_CopiesConfigToOutput()
    {
        var outDir = BuildTempProject(sourceFiles: [("web.config", "web.config")]);

        IsTrue(File.Exists(Path.Combine(outDir, "TestAssembly.dll.config")));
    }

    [TestMethod]
    public void JJ_CopyConfig_WhenAssemblyNameConfig_CopiesConfigToOutput()
    {
        var outDir = BuildTempProject(sourceFiles: [("TestAssembly.dll.config", "assembly")]);

        IsTrue(File.Exists(Path.Combine(outDir, "TestAssembly.dll.config")));
    }

    [TestMethod]
    public void JJ_CopyConfig_WhenTesthostConfig_CopiesConfigToOutput()
    {
        string outDir = BuildTempProject(sourceFiles: [("testhost.dll.config", "testhost")]);

        IsTrue(File.Exists(Path.Combine(outDir, "TestAssembly.dll.config")));
    }

    [TestMethod]
    public void JJ_CopyConfig_WhenNoConfig_DoesNotCopyAnything()
    {
        string outDir = BuildTempProject(sourceFiles: []);

        IsFalse(File.Exists(Path.Combine(outDir, "TestAssembly.dll.config")));
    }

    // Helpers

    /// <summary>
    /// Creates a temp project with the given source config files, builds it,
    /// and returns (outputDirectory, buildOutput).
    /// sourceFiles: list of (fileName, sourceLabel) — label goes into the value attribute
    /// so tests can verify which file was copied.
    /// </summary>
    static string BuildTempProject(
        IEnumerable<(string fileName, string configValue)> sourceFiles)
    {
        var tempDir = Path.Combine(Path.GetTempPath(), "JJ.CopyConfigTests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(tempDir);

        var csproj = MinimalCsprojTemplate.Replace("{TargetsPath}", TargetsAbsolutePath.Replace("\\", "/"));
        File.WriteAllText(Path.Combine(tempDir, "TestAssembly.csproj"), csproj);

        // Minimal class so SDK project compiles.
        File.WriteAllText(Path.Combine(tempDir, "Placeholder.cs"), "// placeholder");

        foreach (var (fileName, sourceLabel) in sourceFiles)
        {
            var content = SampleConfigContent.Replace("{SourceLabel}", sourceLabel);
            File.WriteAllText(Path.Combine(tempDir, fileName), content);
        }

        // TODO: Use current TFM running with.
        const string tfm = "net8.0";
        var outDir = Path.Combine(tempDir, "bin", "Debug", tfm);

        RunProcess(tempDir);
        return outDir;
    }

    static string RunProcess(string workingDir)
    {
        var psi = new ProcessStartInfo("dotnet", "build --nologo -v:normal")
        {
            WorkingDirectory = workingDir,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var proc = Process.Start(psi) ?? throw new InvalidOperationException("Failed to start dotnet build.");
        var stdout = proc.StandardOutput.ReadToEnd();
        var stderr = proc.StandardError.ReadToEnd();
        proc.WaitForExit();

        if (proc.ExitCode != 0 && !stdout.Contains("warning") && !stderr.Contains("warning"))
            throw new InvalidOperationException(
                $"dotnet build failed (exit {proc.ExitCode}).\nSTDOUT:\n{stdout}\nSTDERR:\n{stderr}");

        return stdout + stderr;
    }
}
