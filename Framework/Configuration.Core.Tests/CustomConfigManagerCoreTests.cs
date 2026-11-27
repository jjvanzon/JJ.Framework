namespace JJ.Framework.Configuration.Core.Tests;

[TestClass]
public class CustomConfigManagerCoreTests
{
    private const int REPEATS = 3; // Subsequent loops hit cache
    private const string SECTION_NAME = "jj.framework.configuration.core.tests";
    private static readonly Assembly _assembly = typeof(ConfigSection).Assembly;
    private static readonly Lock _noParallel = new();

    // GetSection
    
    [TestMethod]
    public void Test_CustomConfigManagerCore_GetSection()
    {
        LoopInIsolation(() =>
        {
            var config = GetSection<ConfigSection>();
            AssertSection(config);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_GetSection_ByName()
    {
        LoopInIsolation(() =>
        {
            var config = GetSection<ConfigSection>(SECTION_NAME);
            AssertSection(config);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_GetSection_WithAssemblyName()
    {
        LoopInIsolation(() =>
        {
            
            var config = GetSection<ConfigSection>(_assembly);
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
            Throws(() => GetSection<ConfigSection>("oops"), "not found");
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_GetSection_WithAssemblyName_NotFound_ReturnsNull()
    {
        LoopInIsolation(() =>
        {
            Assembly assembly = typeof(string).Assembly;
            Throws(() => GetSection<ConfigSection>(assembly), "not found");
        });
    }

    // TryGetSection

    [TestMethod]
    public void Test_CustomConfigManagerCore_TryGetSection()
    {
        LoopInIsolation(() =>
        {
            var config = TryGetSection<ConfigSection>();
            AssertSection(config);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_TryGetSection_ByName()
    {
        LoopInIsolation(() =>
        {
            var config = TryGetSection<ConfigSection>(SECTION_NAME);
            AssertSection(config);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_TryGetSection_WithAssemblyName()
    {
        LoopInIsolation(() =>
        {
            var config = TryGetSection<ConfigSection>(_assembly);
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
            var config = TryGetSection<ConfigSection>("oops");
            IsNull(config);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_TryGetSection_WithAssemblyName_NotFound_ReturnsNull()
    {
        LoopInIsolation(() =>
        {
            Assembly assembly = typeof(string).Assembly;
            var config = TryGetSection<ConfigSection>(assembly);
            IsNull(config);
        });
    }

    // SetSection / ClearSection

    [TestMethod]
    public void Test_CustomConfigManagerCore_SetSection_ClearSection()
    {
        LoopInIsolation(() =>
        {
            // Get auto-resolved config
            var config = GetSection<ConfigSection>();
            NotEqual(100, config.NoteLength);

            // Set a custom section
            SetSection(new ConfigSection { NoteLength = 100 });
            config = GetSection<ConfigSection>();
            AreEqual(100, config.NoteLength);

            // Clear to get auto-resolved section next loop.
            ClearSection<ConfigSection>();
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_SetSection_ClearSection_ByName()
    {
        LoopInIsolation(() =>
        {
            // Get auto-resolved config
            var config = TryGetSection<ConfigSection>("myconfig");
            IsNull(config);

            // Set a custom section
            SetSection("myconfig", new ConfigSection { NoteLength = 100 });
            config = GetSection<ConfigSection>("myconfig");
            AreEqual(100, config.NoteLength);

            // Clear to get auto-resolved section next loop.
            ClearSection("myconfig");
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_SetSection_ClearSection_WithAssemblyName()
    {
        LoopInIsolation(() =>
        {
            // Get auto-resolved config
            var config = GetSection<ConfigSection>(_assembly);
            NotEqual(100, config.NoteLength);

            // Set a custom section
            SetSection(_assembly, new ConfigSection { NoteLength = 100 });
            config = GetSection<ConfigSection>(_assembly);
            AreEqual(100, config.NoteLength);

            // Clear to get auto-resolved section next loop.
            ClearSection(_assembly);
        });
    }

    // From Text
        
    [TestMethod]
    public void Test_CustomConfigManagerCore_SetSection_FromText()
    {
        InIsolation(() =>
        { 
            SetSection<ConfigSection>(xml:
              $"""
              <config>
                <{SECTION_NAME} noteLength="1.23" />
              </config>
              """);

            var config = GetSection<ConfigSection>();

            AreEqual(1.23, config.NoteLength);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_SetSection_FromText_WithName()
    {
        InIsolation(() =>
        { 
            SetSection<ConfigSection>("myconfig", xml:
              """
              <config>
                <myconfig noteLength="2.34" />
              </config>
              """);

            var config = GetSection<ConfigSection>("myconfig");

            AreEqual(2.34, config.NoteLength);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_SetSection_FromText_WithAssembly()
    {
        InIsolation(() =>
        { 
            SetSection<ConfigSection>(_assembly, xml:
              $"""
              <config>
                <{SECTION_NAME} noteLength="3.45" />
              </config>
              """);

            var config = GetSection<ConfigSection>(_assembly);

            AreEqual(3.45, config.NoteLength);
        });
    }

    // From Bytes
        
    [TestMethod]
    public void Test_CustomConfigManagerCore_SetSection_FromBytes()
    {
        InIsolation(() =>
        {
            byte[] bytes = StringToBytes(
              $"""
              <config>
                <{SECTION_NAME} noteLength="4.56" />
              </config>
              """);

            SetSection<ConfigSection>(bytes);

            var config = GetSection<ConfigSection>();

            AreEqual(4.56, config.NoteLength);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_SetSection_FromBytes_WithName()
    {
        InIsolation(() =>
        {
            byte[] bytes = StringToBytes(
              """
              <config>
                <myconfig noteLength="5.67" />
              </config>
              """);

            SetSection<ConfigSection>("myconfig", bytes);

            var config = GetSection<ConfigSection>("myconfig");

            AreEqual(5.67, config.NoteLength);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_SetSection_FromBytes_WithAssembly()
    {
        InIsolation(() =>
        {
            byte[] bytes = StringToBytes(
              $"""
              <config>
                <{SECTION_NAME} noteLength="6.78" />
              </config>
              """);

            SetSection<ConfigSection>(_assembly, bytes);

            var config = GetSection<ConfigSection>(_assembly);

            AreEqual(6.78, config.NoteLength);
        });
    }

    // From Stream
        
    [TestMethod]
    public void Test_CustomConfigManagerCore_SetSection_FromStream()
    {
        InIsolation(() =>
        {
            Stream stream = StringToStream(
              $"""
              <config>
                <{SECTION_NAME} noteLength="7.89" />
              </config>
              """);

            SetSection<ConfigSection>(stream);

            var config = GetSection<ConfigSection>();

            AreEqual(7.89, config.NoteLength);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_SetSection_FromStream_WithName()
    {
        InIsolation(() =>
        {
            Stream stream = StringToStream(
              """
              <config>
                <myconfig noteLength="8.90" />
              </config>
              """);

            SetSection<ConfigSection>("myconfig", stream);

            var config = GetSection<ConfigSection>("myconfig");

            AreEqual(8.90, config.NoteLength);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_SetSection_FromStream_WithAssembly()
    {
        InIsolation(() =>
        {
            Stream stream = StringToStream(
              $"""
              <config>
                <{SECTION_NAME} noteLength="9.01" />
              </config>
              """);

            SetSection<ConfigSection>(_assembly, stream);

            var config = GetSection<ConfigSection>(_assembly);

            AreEqual(9.01, config.NoteLength);
        });
    }

    // From File Path

        
    [TestMethod]
    public void Test_CustomConfigManagerCore_SetSection_FromFilePath()
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

            SetSection<ConfigSection>(filePath: filePath);

            var config = GetSection<ConfigSection>();

            AreEqual(0.12, config.NoteLength);
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
                ClearSections();
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
                ClearSections();
            }
        }
    }

    private void InIsolation(Action<string> actionWithFilePath)
    {
        lock (_noParallel)
        {
            string filePath = GetTempFilePath();
            try
            {
                actionWithFilePath(filePath);
            }
            finally
            {
                ClearSections();
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

    private static string GetTempFilePath()
    {
        const string subFolderName = nameof(JJ) + "." + nameof(CustomConfigManagerCoreTests);
        string folderPath = Combine(GetTempPath(), subFolderName);

        if (!Directory.Exists(folderPath)) 
        {
            Directory.CreateDirectory(folderPath);
        }

        string fileName = GetRandomFileName().Replace(".", "") + ".xml";

        return Combine(folderPath, fileName);
    }

    private void AssertSection(ConfigSection? config)
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