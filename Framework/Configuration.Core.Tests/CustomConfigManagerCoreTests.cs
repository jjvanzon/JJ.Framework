namespace JJ.Framework.Configuration.Core.Tests;

[TestClass]
public class CustomConfigManagerCoreTests
{
    private const int REPEATS = 2; // 2nd time hits cache
    private static readonly Lock _noParallel = new();
    
    [TestMethod]
    public void Test_CustomConfigManagerCore_GetSection()
    {
        Isolated(() =>
        {
            var config = CustomConfigManagerCore.GetSection<ConfigSection>();
            AssertSection(config);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_GetSection_WithSectionName()
    {
        Isolated(() =>
        {
            var config = CustomConfigManagerCore.GetSection<ConfigSection>("jj.framework.configuration.core.tests");
            AssertSection(config);
        });
    }

    [TestMethod]
    public void Test_CustomConfigManagerCore_GetSection_WithAssembly()
    {
        Isolated(() =>
        {
            Assembly assembly = typeof(ConfigSection).Assembly;
            var config = CustomConfigManagerCore.GetSection<ConfigSection>(assembly);
            AssertSection(config);
        });
    }

    private void Isolated(Action action)
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
                CustomConfigManagerCore.Clear();
            }
        }
    }

    private void AssertSection(ConfigSection config)
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