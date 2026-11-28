namespace JJ.Framework.Configuration.Core.Tests;

[TestClass]
public class CustomConfigManagerCoreTests
{
    private const int REPEATS = 3; // Subsequent loops hit cache
    private const string SECTION_NAME = "jj.framework.configuration.core.tests";
    private static readonly Assembly _assembly = typeof(MyConfig).Assembly;
    private static readonly Lock _noParallel = new();

    // GetSection
    
    [TestMethod]
    public void Test_CustomConfigManagerCore_GetSection()
    {
        LoopInIsolation(() =>
        {
            var config = GetSection<MyConfig>();
            AssertSection(config);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_GetSection_ByName()
    {
        LoopInIsolation(() =>
        {
            var config = GetSection<MyConfig>(SECTION_NAME);
            AssertSection(config);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_GetSection_WithAssemblyName()
    {
        LoopInIsolation(() =>
        {
            
            var config = GetSection<MyConfig>(_assembly);
            AssertSection(config);
        });
    }
    
    // GetSection => NotFound => Exception

    [TestMethod]
    public void Test_CustomConfigManagerCore_GetSection_NotFound_ReturnsNull()
    {
        LoopInIsolation(() =>
        {
            Throws(() => GetSection<object>(), "not found");
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_GetSection_ByName_NotFound_ReturnsNull()
    {
        LoopInIsolation(() =>
        {
            Throws(() => GetSection<MyConfig>("oops"), "not found");
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_GetSection_WithAssemblyName_NotFound_ReturnsNull()
    {
        LoopInIsolation(() =>
        {
            Assembly assembly = typeof(string).Assembly;
            Throws(() => GetSection<MyConfig>(assembly), "not found");
        });
    }

    // TryGetSection

    [TestMethod]
    public void Test_CustomConfigManagerCore_TryGetSection()
    {
        LoopInIsolation(() =>
        {
            var config = TryGetSection<MyConfig>();
            AssertSection(config);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_TryGetSection_ByName()
    {
        LoopInIsolation(() =>
        {
            var config = TryGetSection<MyConfig>(SECTION_NAME);
            AssertSection(config);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_TryGetSection_WithAssemblyName()
    {
        LoopInIsolation(() =>
        {
            var config = TryGetSection<MyConfig>(_assembly);
            AssertSection(config);
        });
    }

    // TryGetSection => NotFound => Null
    
    [TestMethod]
    public void Test_CustomConfigManagerCore_TryGetSection_NotFound_ReturnsNull()
    {
        LoopInIsolation(() =>
        {
            var config = TryGetSection<object>();
            IsNull(config);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_TryGetSection_ByName_NotFound_ReturnsNull()
    {
        LoopInIsolation(() =>
        {
            var config = TryGetSection<MyConfig>("oops");
            IsNull(config);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_TryGetSection_WithAssemblyName_NotFound_ReturnsNull()
    {
        LoopInIsolation(() =>
        {
            Assembly assembly = typeof(string).Assembly;
            var config = TryGetSection<MyConfig>(assembly);
            IsNull(config);
        });
    }

    // SetSection / RefreshSection

    [TestMethod]
    public void Test_CustomConfigManagerCore_SetSection_RefreshSection()
    {
        LoopInIsolation(() =>
        {
            // Get auto-resolved config
            var config = GetSection<MyConfig>();
            NotEqual(100, config.NoteLength);

            // Set a custom section
            SetSection(new MyConfig { NoteLength = 100 });
            config = GetSection<MyConfig>();
            AreEqual(100, config.NoteLength);

            // Clear to get auto-resolved section next loop.
            RefreshSection<MyConfig>();
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_SetSection_RefreshSection_ByName()
    {
        LoopInIsolation(() =>
        {
            // Get auto-resolved config
            var config = TryGetSection<MyConfig>("theconfig");
            IsNull(config);

            // Set a custom section
            SetSection("theconfig", new MyConfig { NoteLength = 100 });
            config = GetSection<MyConfig>("theconfig");
            AreEqual(100, config.NoteLength);

            // Clear to get auto-resolved section next loop.
            RefreshSection("theconfig");
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_SetSection_RefreshSection_WithAssemblyName()
    {
        LoopInIsolation(() =>
        {
            // Get auto-resolved config
            var config = GetSection<MyConfig>(_assembly);
            NotEqual(100, config.NoteLength);

            // Set a custom section
            SetSection(_assembly, new MyConfig { NoteLength = 100 });
            config = GetSection<MyConfig>(_assembly);
            AreEqual(100, config.NoteLength);

            // Clear to get auto-resolved section next loop.
            RefreshSection(_assembly);
        });
    }

    // From Text
        
    [TestMethod]
    public void Test_CustomConfigManagerCore_FromText()
    {
        InIsolation(() =>
        { 
            SetSection<MyConfig>(xml:
              $"""
              <config>
                <{SECTION_NAME} noteLength="1.23" />
              </config>
              """);

            var config = GetSection<MyConfig>();

            AreEqual(1.23, config.NoteLength);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_FromText_WithSectionName()
    {
        InIsolation(() =>
        { 
            SetSection<MyConfig>("theconfig", xml:
              """
              <config>
                <theconfig noteLength="2.34" />
              </config>
              """);

            var config = GetSection<MyConfig>("theconfig");

            AreEqual(2.34, config.NoteLength);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_SetSection_WithAssembly()
    {
        InIsolation(() =>
        { 
            SetSection<MyConfig>(_assembly, xml:
              $"""
              <config>
                <{SECTION_NAME} noteLength="3.45" />
              </config>
              """);

            var config = GetSection<MyConfig>(_assembly);

            AreEqual(3.45, config.NoteLength);
        });
    }

    // From Bytes
        
    [TestMethod]
    public void Test_CustomConfigManagerCore_FromBytes()
    {
        InIsolation(() =>
        {
            byte[] bytes = StringToBytes(
              $"""
              <config>
                <{SECTION_NAME} noteLength="4.56" />
              </config>
              """);

            SetSection<MyConfig>(bytes);

            var config = GetSection<MyConfig>();

            AreEqual(4.56, config.NoteLength);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_FromBytes_WithSectionName()
    {
        InIsolation(() =>
        {
            byte[] bytes = StringToBytes(
              """
              <config>
                <theconfig noteLength="5.67" />
              </config>
              """);

            SetSection<MyConfig>("theconfig", bytes);

            var config = GetSection<MyConfig>("theconfig");

            AreEqual(5.67, config.NoteLength);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_FromBytes_WithAssembly()
    {
        InIsolation(() =>
        {
            byte[] bytes = StringToBytes(
              $"""
              <config>
                <{SECTION_NAME} noteLength="6.78" />
              </config>
              """);

            SetSection<MyConfig>(_assembly, bytes);

            var config = GetSection<MyConfig>(_assembly);

            AreEqual(6.78, config.NoteLength);
        });
    }

    // From Stream
        
    [TestMethod]
    public void Test_CustomConfigManagerCore_FromStream()
    {
        InIsolation(() =>
        {
            Stream stream = StringToStream(
              $"""
              <config>
                <{SECTION_NAME} noteLength="7.89" />
              </config>
              """);

            SetSection<MyConfig>(stream);

            var config = GetSection<MyConfig>();

            AreEqual(7.89, config.NoteLength);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_FromStream_WithSectionName()
    {
        InIsolation(() =>
        {
            Stream stream = StringToStream(
              """
              <config>
                <theconfig noteLength="8.90" />
              </config>
              """);

            SetSection<MyConfig>("theconfig", stream);

            var config = GetSection<MyConfig>("theconfig");

            AreEqual(8.90, config.NoteLength);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_FromStream_WithAssembly()
    {
        InIsolation(() =>
        {
            Stream stream = StringToStream(
              $"""
              <config>
                <{SECTION_NAME} noteLength="9.01" />
              </config>
              """);

            SetSection<MyConfig>(_assembly, stream);

            var config = GetSection<MyConfig>(_assembly);

            AreEqual(9.01, config.NoteLength);
        });
    }

    // From File Path

    [TestMethod]
    public void Test_CustomConfigManagerCore_FromFilePath()
    {
        InIsolation(filePath =>
        {
            WriteAllText(
                filePath,
                $"""
                <config>
                  <{SECTION_NAME} noteLength="0.12" />
                </config>
                """);

            SetSection<MyConfig>(filePath: filePath);

            var config = GetSection<MyConfig>();

            AreEqual(0.12, config.NoteLength);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_FromFilePath_WithSectionName()
    {
        InIsolation(filePath =>
        {
            WriteAllText(
                filePath,
                """
                <config>
                  <theconfig noteLength="9.87" />
                </config>
                """);

            SetSection<MyConfig>("theconfig", filePath: filePath);

            var config = GetSection<MyConfig>("theconfig");

            AreEqual(9.87, config.NoteLength);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_FromFilePath_WithAssembly()
    {
        InIsolation(filePath =>
        {
            WriteAllText(
                filePath,
                $"""
                <config>
                  <{SECTION_NAME} noteLength="8.76" />
                </config>
                """);

            SetSection<MyConfig>(_assembly, filePath: filePath);

            var config = GetSection<MyConfig>(_assembly);

            AreEqual(8.76, config.NoteLength);
        });
    }

    // Empty Cases

    [TestMethod]
    public void Test_CustomConfigManagerCore_Nullies()
    {
        Throws(() => GetSection   <MyConfig>(sectionName: ""), "no sectionName");
        Throws(() => TryGetSection<MyConfig>(sectionName: ""), "no sectionName");
        Throws(() => SetSection   <MyConfig>(xml:      null!), "no xml"        );
        Throws(() => SetSection   <MyConfig>(xml:      ""   ), "no xml"        );
        Throws(() => SetSection   <MyConfig>(xml:      " "  ), "no xml"        );
        Throws(() => SetSection   <MyConfig>(bytes:    null!), "no bytes"      );
        Throws(() => SetSection   <MyConfig>(bytes:    [ ]  ), "no bytes"      );
        Throws(() => SetSection   <MyConfig>(filePath: null!), "no filePath"   );
        Throws(() => SetSection   <MyConfig>(filePath: ""   ), "no filePath"   );
        Throws(() => SetSection   <MyConfig>(filePath: " "  ), "no filePath"   );
        Throws(() => SetSection   <MyConfig>(filePath: GetTempFilePath()), "file not found");
    }

    // Config File Locations

    [TestMethod]
    public void Test_CustomConfigManagerCore_ConfigFileLocations()
    {
        InIsolation(() =>
        {
            // Remember current config
            var orgFilePath = TryGetConfigFileName();
            NotNullOrWhiteSpace(orgFilePath);
            IsTrue(File.Exists(orgFilePath));
            var orgContent = ReadAllText(orgFilePath);
            NotNullOrWhiteSpace(orgContent);

            try
            {
                // No config file
                {
                    Delete(orgFilePath);
                    Delete("app.config");
                    Delete("web.config");
                    Delete("testhost.dll.config");
                    Delete("nCrunch.TaskRunner.DotNetCore.20.x64.dll.config");
                    RefreshSection<MyConfig>();
                    var config = TryGetSection<MyConfig>();
                    IsNull(config);
                    Throws(() => GetSection<MyConfig>(), "no config file found");
                }

                // app.config
                {
                    // Create File
                    const string fileName = "app.config";
                    const string content = $"""
                      <config>
                        <{SECTION_NAME} audioLength="3.14" />
                      </config>
                      """;
                    WriteAllText(fileName, content);
                    AreEqual(fileName, GetConfigFileName());

                    // Assert
                    var config = GetSection<MyConfig>();
                    NotNull(config);
                    AreEqual(3.14, config.AudioLength);

                    // Delete file
                    Delete(fileName);
                    IsNullOrWhiteSpace(TryGetConfigFileName());
                }

                // web.config
                {
                    // Create File
                    const string fileName = "web.config";
                    const string content = $"""
                      <config>
                        <{SECTION_NAME} audioLength="4.14" />
                      </config>
                      """;
                    WriteAllText(fileName, content);
                    AreEqual(fileName, GetConfigFileName());

                    // State cached
                    var config = GetSection<MyConfig>();
                    AreEqual(3.14, config.AudioLength);

                    // Until RefreshSection
                    RefreshSection<MyConfig>();
                    config = GetSection<MyConfig>();
                    NotNull(config);
                    AreEqual(4.14, config.AudioLength);

                    // Delete File
                    Delete(fileName);
                    IsNullOrWhiteSpace(TryGetConfigFileName());
                }

                // testhost.dll.config
                {
                    // Create File
                    const string fileName = "testhost.dll.config";
                    const string content = $"""
                      <config>
                        <{SECTION_NAME} audioLength="5.14" />
                      </config>
                      """;
                    WriteAllText(fileName, content);
                    AreEqual(fileName, GetConfigFileName());

                    // Assert
                    RefreshSection<MyConfig>();
                    var config = GetSection<MyConfig>();
                    NotNull(config);
                    AreEqual(5.14, config.AudioLength);

                    // Delete File
                    Delete(fileName);
                    IsNullOrWhiteSpace(TryGetConfigFileName());
                }

                // nCrunch.TaskRunner.DotNetCore.20.x64.dll.config
                {
                    // Create File
                    const string fileName = "nCrunch.TaskRunner.DotNetCore.20.x64.dll.config";
                    const string content = $"""
                      <config>
                        <{SECTION_NAME} audioLength="6.14" />
                      </config>
                      """;
                    WriteAllText(fileName, content);
                    AreEqual(fileName, GetConfigFileName());

                    // Assert
                    RefreshSection<MyConfig>();
                    var config = GetSection<MyConfig>();
                    NotNull(config);
                    AreEqual(6.14, config.AudioLength);

                    // Delete File
                    Delete(fileName);
                    IsNullOrWhiteSpace(TryGetConfigFileName());
                }

                // TODO: This case fails. EntryAssembly is null.
                return;

                // {YourProjectName}.dll.config
                {
                    // Create File
                    string entryAssemblyName = GetEntryAssembly()?.GetName().Name ?? "";
                    NotNullOrWhiteSpace(entryAssemblyName);
                    string fileName = GetEntryAssembly()?.GetName().Name + ".dll.config";
                    const string content = $"""
                      <config>
                        <{SECTION_NAME} audioLength="6.14" />
                      </config>
                      """;
                    WriteAllText(fileName, content);
                    AreEqual(fileName, GetConfigFileName());

                    // Assert
                    RefreshSection<MyConfig>();
                    var config = GetSection<MyConfig>();
                    NotNull(config);
                    AreEqual(6.14, config.AudioLength);

                    // Delete File
                    Delete(fileName);
                    IsNullOrWhiteSpace(TryGetConfigFileName());
                }
            }
            finally
            {
                // Restore original config
                try
                {
                    WriteAllText(orgFilePath, orgContent);
                }
                catch
                {
                    // Ignore
                }
            }

            
        });
    }

    // Helpers

    private void LoopInIsolation(Action action)
    {
        lock (_noParallel)
        {
            try
            {
                for (int i = 0; i < REPEATS; i++)
                {
                    action();
                }
            }
            finally
            {
                RefreshAllSections();
            }
        }
    }

    private void InIsolation(Action action)
    {
        lock (_noParallel)
        {
            try
            {
                action();
            }
            finally
            {
                RefreshAllSections();
            }
        }
    }

    private void InIsolation(Action<string> actionWithFilePath, [Caller] string testName = "")
    {
        lock (_noParallel)
        {
            string filePath = GetTempFilePath(testName);
            try
            {
                actionWithFilePath(filePath);
            }
            finally
            {
                RefreshAllSections();
                try
                {
                    if (File.Exists(filePath)) 
                    {
                        Delete(filePath);
                    }
                }
                catch
                { 
                    // ignore
                }
            }
        }
    }

    private static string GetTempFilePath([Caller] string testName = "")
    {
        string subFolderName = typeof(CustomConfigManagerCore).Namespace + ".TestRuns";
        string subSubFolderName = testName; //nameof(CustomConfigManagerCoreTests);
        string folderPath = Combine(GetTempPath(), subFolderName, subSubFolderName);

        if (!Directory.Exists(folderPath)) 
        {
            Directory.CreateDirectory(folderPath);
        }

        string fileName = GetRandomFileName().Replace(".", "") + ".xml";

        return Combine(folderPath, fileName);
    }

    private void AssertSection(MyConfig? config)
    {
        IsNotNull(          config);
                            
        AreEqual (32,       config.Bits);
        AreEqual (1,        config.Channels);
        AreEqual (48000,    config.SamplingRate);
        AreEqual (Wav,      config.AudioFormat);
        AreEqual (Line,     config.Interpolation);
        AreEqual (2,        config.CourtesyFrames);
                            
        AreEqual (0.2,      config.NoteLength);
        AreEqual (1.0,      config.BarLength);
        AreEqual (0.25,     config.BeatLength);
        AreEqual (1.0,      config.AudioLength);
        AreEqual (0.25,     config.LeadingSilence);
        AreEqual (0.25,     config.TrailingSilence);
                            
        AreEqual (true,     config.AudioPlayback);
        AreEqual (false,    config.DiskCache);
        AreEqual (true,     config.MathBoost);
        AreEqual (true,     config.ParallelProcessing);
        AreEqual (false,    config.PlayAllTapes);

        AreEqual (120,      config.LeafCheckTimeOut);
        AreEqual (Continue, config.TimeOutAction);
        AreEqual (4,        config.FileExtensionMaxLength);

        IsNotNull(          config.NCrunch);
        AreEqual (false,    config.NCrunch.AudioPlayback);
        AreEqual (10,       config.NCrunch.SamplingRate);
        IsNull   (          config.NCrunch.ImpersonationMode);

        IsNotNull(          config.AzurePipelines);
        AreEqual (false,    config.AzurePipelines.AudioPlayback);
        AreEqual (300,      config.AzurePipelines.SamplingRate);
        IsNull   (          config.AzurePipelines.ImpersonationMode);
    }
}