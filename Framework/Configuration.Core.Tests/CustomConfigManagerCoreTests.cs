namespace JJ.Framework.Configuration.Core.Tests;

[TestClass]
public class CustomConfigManagerCoreTests
{
    [TestMethod]
    public void Test_CustomConfigManagerCore_MainCase()
    {
        var config = CustomConfigManagerCore.GetSection<ConfigSection>("jj.framework.configuration.core.tests");
        AssertSection(config);
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