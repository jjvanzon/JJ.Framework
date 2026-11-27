namespace JJ.Framework.Configuration.Core.Tests;

[TestClass]
public class CustomConfigManagerCoreTests
{
    private const string SECTION_NAME = "jj.framework.configuration.core.tests";
    private static readonly Assembly _assembly = typeof(ConfigSection).Assembly;

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
            var config = GetSection<ConfigSection>(SECTION_NAME);
            NotEqual(100, config.NoteLength);

            // Set a custom section
            SetSection(SECTION_NAME, new ConfigSection { NoteLength = 100 });
            config = GetSection<ConfigSection>(SECTION_NAME);
            AreEqual(100, config.NoteLength);

            // Clear to get auto-resolved section next loop.
            ClearSection(SECTION_NAME);
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

    // Helpers

    private const int REPEATS = 3; // 2nd time hits cache
    private static readonly Lock _noParallel = new();

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
                Clear();
            }
        }
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