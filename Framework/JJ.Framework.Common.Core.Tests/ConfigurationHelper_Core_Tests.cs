// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class ConfigurationHelper_Core_Tests
{
    // Lock to Force Serial Execution

    private static readonly object _lock = new();

    // Complex Example

    [TestMethod]
    public void ConfigurationHelper_Example_Core_Test()
    {
        lock (_lock)
        {
            try
            {
                // Arrange
                var configSection = new ConfigurationSectionCore();
                var configSection_FromDifferentAssembly = new object(); // Using a class from another assembly. should render a different auto-generated name.

                // Act
                ConfigurationHelper.SetSection(configSection);
                ConfigurationHelper.SetSection(configSection_FromDifferentAssembly);

                var output_ConfigSection = ConfigurationHelper.GetSection<ConfigurationSectionCore>();

                // Assert
                AssertHelper.IsNotNull(() => output_ConfigSection);
                AssertHelper.AreSame(configSection, () => output_ConfigSection);
            }
            finally
            {
                // Clean Up
                ConfigurationHelper_Accessor_Core._sections.Clear();
            }
        }
    }

    // Auto-Generated Names

    [TestMethod]
    public void ConfigurationHelper_DifferentAssembly_DifferentName_Core_Test()
    {
        lock (_lock)
        {
            try
            {
                // Arrange
                var inputConfigSection1 = new ConfigurationSectionCore();
                var inputConfigSection2 = new object();

                // Act
                ConfigurationHelper.SetSection(inputConfigSection1);
                ConfigurationHelper.SetSection(inputConfigSection2);

                var outputConfigSection1 = ConfigurationHelper.GetSection<ConfigurationSectionCore>();
                var outputConfigSection2 = ConfigurationHelper.GetSection<object>();

                // Assert
                AssertHelper.IsNotNull(() => outputConfigSection1);
                AssertHelper.IsNotNull(() => outputConfigSection2);
                AssertHelper.AreSame(inputConfigSection1, () => outputConfigSection1);
                AssertHelper.AreSame(inputConfigSection2, () => outputConfigSection2);
                AssertHelper.NotEqual(outputConfigSection1, () => outputConfigSection2);
            }
            finally
            {
                // Clean Up
                ConfigurationHelper_Accessor_Core._sections.Clear();
            }
        }
    }

    // SetSection, GetSection

    [TestMethod]
    public void ConfigurationHelper_SetSection_GetSection_Succeeds_Core_Test()
    {
        lock (_lock)
        {
            try
            {
                // Arrange
                var inputConfigSection = new ConfigurationSectionCore();

                // Act
                ConfigurationHelper.SetSection(inputConfigSection);
                var outputConfigSection = ConfigurationHelper.GetSection<ConfigurationSectionCore>();

                // Assert
                AssertHelper.IsNotNull(() => outputConfigSection);
                AssertHelper.AreSame(inputConfigSection, () => outputConfigSection);
            }
            finally
            {
                // Clean Up
                ConfigurationHelper_Accessor_Core._sections.Clear();
            }
        }
    }

    // SetSection, TryGetSection

    [TestMethod]
    public void ConfigurationHelper_SetSection_TryGetSection_Succeeds_Core_Test()
    {
        lock (_lock)
        {
            try
            {
                // Arrange
                var inputConfigSection = new ConfigurationSectionCore();

                // Act
                ConfigurationHelper.SetSection(inputConfigSection);
                var outputConfigSection = ConfigurationHelperCore.TryGetSection<ConfigurationSectionCore>();

                // Assert
                AssertHelper.IsNotNull(() => outputConfigSection);
                AssertHelper.AreSame(inputConfigSection, () => outputConfigSection);
            }
            finally
            {
                // Clean Up
                ConfigurationHelper_Accessor_Core._sections.Clear();
            }
        }
    }

    // Not Found
    
    [TestMethod]
    public void ConfigurationHelper_GetSection_SectionNotFound_ThrowsException_Core_Test()
    {
        lock (_lock)
        {
            AssertHelper.ThrowsException(
                () => ConfigurationHelper.GetSection<ConfigurationSectionCore>(),
                "Configuration section of type 'JJ.Framework.Common.Core.Tests.ConfigurationSectionCore' was not set. " +
                "To allow JJ.Framework.Common to use this configuration section, " +
                "call JJ.Framework.Common.ConfigurationHelper.SetSection.");
        }
    }

    [TestMethod]
    public void ConfigurationHelper_TryGetSection_SectionNotFound_ReturnsNull_Core_Test()
    {
        lock (_lock)
        {
            var configSection = ConfigurationHelperCore.TryGetSection<ConfigurationSectionCore>();
            AssertHelper.IsNull(() => configSection);
        }
    }

    // Edge Cases

    [TestMethod]
    public void ConfigurationHelper_EdgeCase_SetSection_ArgumentNullException_Core_Test()
    {
        lock (_lock)
        {
            try
            {
                // TODO: Make ThrowsExceptionStartsWith/ThrowsExceptionContains for beginning of string testing.
                // Arrange
                //string expectedMessage = $"Value cannot be null.{Environment.NewLine}Parameter name: section";

                // Act
                AssertHelper.ThrowsException<ArgumentNullException>(
                    () => ConfigurationHelper.SetSection<ConfigurationSectionCore>(null)//,
                    /*expectedMessage*/);
            }
            finally
            {
                // Clean Up
                ConfigurationHelper_Accessor_Core._sections.Clear();
            }
        }
    }

    [TestMethod]
    public void ConfigurationHelper_EdgeCase_SetSection_AlreadyCalled_ThrowsException_Core_Test()
    {
        lock (_lock)
        {
            try
            {
                // Arrange
                var inputConfigSection = new ConfigurationSectionCore();
                ConfigurationHelper.SetSection(inputConfigSection);

                // Act
                AssertHelper.ThrowsException(
                    () => ConfigurationHelper.SetSection(inputConfigSection),
                    "Configuration section of type 'JJ.Framework.Common.Core.Tests.ConfigurationSectionCore' was already set.");
            }
            finally
            {
                // Clean Up
                ConfigurationHelper_Accessor_Core._sections.Clear();
            }
        }
    }
}
