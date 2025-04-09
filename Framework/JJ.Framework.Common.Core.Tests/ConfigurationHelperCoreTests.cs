// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class ConfigurationHelperCoreTests
{
    // Lock to Force Serial Execution

    private static readonly object _lock = new();

    // Example

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
                IsNotNull(() => output_ConfigSection);
                AreSame(configSection, () => output_ConfigSection);
            }
            finally
            {
                // Clean Up
                ConfigurationHelperAccessorCore._sections.Clear();
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
                IsNotNull(() => outputConfigSection1);
                IsNotNull(() => outputConfigSection2);
                AreSame(inputConfigSection1, () => outputConfigSection1);
                AreSame(inputConfigSection2, () => outputConfigSection2);
                NotEqual(outputConfigSection1, () => outputConfigSection2);
            }
            finally
            {
                // Clean Up
                ConfigurationHelperAccessorCore._sections.Clear();
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
                IsNotNull(() => outputConfigSection);
                AreSame(inputConfigSection, () => outputConfigSection);
            }
            finally
            {
                // Clean Up
                ConfigurationHelperAccessorCore._sections.Clear();
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
                IsNotNull(() => outputConfigSection);
                AreSame(inputConfigSection, () => outputConfigSection);
            }
            finally
            {
                // Clean Up
                ConfigurationHelperAccessorCore._sections.Clear();
            }
        }
    }

    // Not Found
    
    [TestMethod]
    public void ConfigurationHelper_GetSection_SectionNotFound_ThrowsException_Core_Test()
    {
        lock (_lock)
        {
            ThrowsException(
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
            IsNull(() => configSection);
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
                ThrowsException<ArgumentNullException>(
                    () => ConfigurationHelper.SetSection<ConfigurationSectionCore>(null)//,
                    /*expectedMessage*/);
            }
            finally
            {
                // Clean Up
                ConfigurationHelperAccessorCore._sections.Clear();
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
                ThrowsException(
                    () => ConfigurationHelper.SetSection(inputConfigSection),
                    "Configuration section of type 'JJ.Framework.Common.Core.Tests.ConfigurationSectionCore' was already set.");
            }
            finally
            {
                // Clean Up
                ConfigurationHelperAccessorCore._sections.Clear();
            }
        }
    }
    
    [TestMethod]
    public void ConfigurationHelperCore_EdgeCase_TryGetSection_ThrowsExceptions_OtherThanNotFound_Core_Test()
    {
        lock (_lock)
        {
            try
            {
                // Arrange
                ConfigurationHelperAccessorCore._sections = null;

                // Act & Assert
                ThrowsException(() => ConfigurationHelperCore.TryGetSection<object>());
            }
            finally
            {
                // Clean Up
                ConfigurationHelperAccessorCore._sections = new Dictionary<Type, object>();
            }
        }
    }
}
