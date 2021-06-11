using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class ConfigurationHelper_Tests
    {
        // Lock to Force Serial Execution

        private static readonly object _lock = new object();

        // SetSection, GetSection

        [TestMethod]
        public void Test_ConfigurationHelper_SetSection_GetSection_Succeeds_SectionNameOmitted()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigurationSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigurationSection);
                    var outputConfigurationSection = ConfigurationHelper.GetSection<ConfigurationSection>();

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigurationSection);
                    AssertHelper.AreSame(inputConfigurationSection, () => outputConfigurationSection);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_SetSection_GetSection_Succeeds_SectionNameNull()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigurationSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigurationSection, null);
                    var outputConfigurationSection = ConfigurationHelper.GetSection<ConfigurationSection>(null);

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigurationSection);
                    AssertHelper.AreSame(inputConfigurationSection, () => outputConfigurationSection);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_SetSection_GetSection_Succeeds_SectionNameEmpty()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigurationSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigurationSection, "");
                    var outputConfigurationSection = ConfigurationHelper.GetSection<ConfigurationSection>("");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigurationSection);
                    AssertHelper.AreSame(inputConfigurationSection, () => outputConfigurationSection);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_SetSection_GetSection_Succeeds_SectionNameProvided()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigurationSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigurationSection, "MyConfigSection1");
                    var outputConfigurationSection = ConfigurationHelper.GetSection<ConfigurationSection>("MyConfigSection1");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigurationSection);
                    AssertHelper.AreSame(inputConfigurationSection, () => outputConfigurationSection);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }

        // SetSection, TryGetSection

        [TestMethod]
        public void Test_ConfigurationHelper_SetSection_TryGetSection_Succeeds_SectionNameOmitted()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigurationSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigurationSection);
                    var outputConfigurationSection = ConfigurationHelper.TryGetSection<ConfigurationSection>();

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigurationSection);
                    AssertHelper.AreSame(inputConfigurationSection, () => outputConfigurationSection);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_SetSection_TryGetSection_Succeeds_SectionNameNull()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigurationSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigurationSection, null);
                    var outputConfigurationSection = ConfigurationHelper.TryGetSection<ConfigurationSection>(null);

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigurationSection);
                    AssertHelper.AreSame(inputConfigurationSection, () => outputConfigurationSection);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_SetSection_TryGetSection_Succeeds_SectionNameEmpty()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigurationSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigurationSection, "");
                    var outputConfigurationSection = ConfigurationHelper.TryGetSection<ConfigurationSection>("");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigurationSection);
                    AssertHelper.AreSame(inputConfigurationSection, () => outputConfigurationSection);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_SetSection_TryGetSection_Succeeds_SectionNameProvided()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigurationSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigurationSection, "MyConfigSection2");
                    var outputConfigurationSection = ConfigurationHelper.TryGetSection<ConfigurationSection>("MyConfigSection2");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigurationSection);
                    AssertHelper.AreSame(inputConfigurationSection, () => outputConfigurationSection);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }


        // Generated Names

        [TestMethod]
        public void Test_ConfigurationHelper_SetSection_WithSectionNameOmitted_GetSection_WithGeneratedName_Succeeds()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigurationSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigurationSection);
                    var outputConfigurationSection = ConfigurationHelper.GetSection<ConfigurationSection>("jj.framework.common.tests");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigurationSection);
                    AssertHelper.AreSame(inputConfigurationSection, () => outputConfigurationSection);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_SetSection_WithSectionNameNull_GetSection_WithGeneratedName_Succeeds()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigurationSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigurationSection, null);
                    var outputConfigurationSection = ConfigurationHelper.GetSection<ConfigurationSection>("jj.framework.common.tests");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigurationSection);
                    AssertHelper.AreSame(inputConfigurationSection, () => outputConfigurationSection);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_SetSection_WithSectionNameEmpty_GetSection_WithGeneratedName_Succeeds()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigurationSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigurationSection, "");
                    var outputConfigurationSection = ConfigurationHelper.GetSection<ConfigurationSection>("jj.framework.common.tests");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigurationSection);
                    AssertHelper.AreSame(inputConfigurationSection, () => outputConfigurationSection);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }


        // Section Not Found

        private const string DEFAULT_NOT_FOUND_EXCEPTION_MESSAGE = 
            "Configuration section with name 'jj.framework.common.tests' was not set. " +
            "To allow JJ.Framework.Common to use this configuration section, " +
            "call JJ.Framework.Common.ConfigurationHelper.SetSection.";

        [TestMethod]
        public void Test_ConfigurationHelper_GetSection_SectionNotFound_ThrowsException_SectionNameOmitted()
        {
            lock (_lock)
            {
                AssertHelper.ThrowsException(
                    () => ConfigurationHelper.GetSection<ConfigurationSection>(),
                    DEFAULT_NOT_FOUND_EXCEPTION_MESSAGE);
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_GetSection_SectionNotFound_ThrowsException_SectionNameNull()
        {
            lock (_lock)
            {
                AssertHelper.ThrowsException(
                    () => ConfigurationHelper.GetSection<ConfigurationSection>(null),
                    DEFAULT_NOT_FOUND_EXCEPTION_MESSAGE);
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_GetSection_SectionNotFound_ThrowsException_SectionNameEmpty()
        {
            lock (_lock)
            {
                AssertHelper.ThrowsException(
                    () => ConfigurationHelper.GetSection<ConfigurationSection>(""),
                    DEFAULT_NOT_FOUND_EXCEPTION_MESSAGE);
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_GetSection_SectionNotFound_ThrowsException_SectionNameProvided()
        {
            lock (_lock)
            {
                string expectedMessage = 
                    "Configuration section with name 'MyConfigSection3' was not set. " +
                    "To allow JJ.Framework.Common to use this configuration section, " +
                    "call JJ.Framework.Common.ConfigurationHelper.SetSection.";

                AssertHelper.ThrowsException(
                    () => ConfigurationHelper.GetSection<ConfigurationSection>("MyConfigSection3"),
                    expectedMessage);
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_TryGetSection_SectionNotFound_ReturnsNull_SectionNameOmitted()
        {
            lock (_lock)
            {
                var configurationSection = ConfigurationHelper.TryGetSection<ConfigurationSection>();
                AssertHelper.IsNull(() => configurationSection);
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_TryGetSection_SectionNotFound_ReturnsNull_SectionNameNull()
        {
            lock (_lock)
            {
                var configurationSection = ConfigurationHelper.TryGetSection<ConfigurationSection>(null);
                AssertHelper.IsNull(() => configurationSection);
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_TryGetSection_SectionNotFound_ReturnsNull_SectionNameEmpty()
        {
            lock (_lock)
            {
                var configurationSection = ConfigurationHelper.TryGetSection<ConfigurationSection>("");
                AssertHelper.IsNull(() => configurationSection);
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_TryGetSection_SectionNotFound_ReturnsNull_SectionNameProvided()
        {
            lock (_lock)
            {
                var configurationSection = ConfigurationHelper.TryGetSection<ConfigurationSection>("MyConfigSection4");
                AssertHelper.IsNull(() => configurationSection);
            }
        }

        // Edge Cases

        [TestMethod]
        public void Test_ConfigurationHelper_EdgeCase_SetSection_AlreadyCalled_ThrowsException()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigurationSection = new ConfigurationSection();
                    ConfigurationHelper.SetSection(inputConfigurationSection);

                    // Act
                    AssertHelper.ThrowsException(
                        () => ConfigurationHelper.SetSection(inputConfigurationSection),
                        "Configuration section with with name 'jj.framework.common.tests' was already set.");
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_EdgeCase_SetSection_WithoutName_GetSection_WrongSectionName_ThrowsException()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    string expectedMessage = 
                        "Configuration section with name 'MyConfigSection7' was not set. " +
                        "To allow JJ.Framework.Common to use this configuration section, " +
                        "call JJ.Framework.Common.ConfigurationHelper.SetSection.";
                    var inputConfigurationSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigurationSection, "MyConfigSection6");
                    AssertHelper.ThrowsException(
                        () => ConfigurationHelper.GetSection<ConfigurationSection>("MyConfigSection7"),
                        expectedMessage);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_EdgeCase_SetSection_WithName_GetSection_WithoutName_Succeeds()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigurationSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigurationSection, "jj.framework.common.tests");
                    var outputConfigurationSection = ConfigurationHelper.GetSection<ConfigurationSection>();

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigurationSection);
                    AssertHelper.AreSame(inputConfigurationSection, () => outputConfigurationSection);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_EdgeCase_WhiteSpaceSectionName_Allowed_AndDifferentFromEmptyString()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigurationSection1 = new ConfigurationSection();
                    var inputConfigurationSection2 = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigurationSection1, "");
                    ConfigurationHelper.SetSection(inputConfigurationSection2, " ");
                    var outputConfigurationSection1 = ConfigurationHelper.GetSection<ConfigurationSection>("");
                    var outputConfigurationSection2 = ConfigurationHelper.GetSection<ConfigurationSection>(" ");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigurationSection1);
                    AssertHelper.IsNotNull(() => outputConfigurationSection2);
                    AssertHelper.AreSame(inputConfigurationSection1, () => outputConfigurationSection1);
                    AssertHelper.AreSame(inputConfigurationSection2, () => outputConfigurationSection2);
                    Assert.IsFalse(outputConfigurationSection1 == outputConfigurationSection2);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_EdgeCase_SameObject_UnderDifferentName_IsAllowed()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigurationSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigurationSection, "MyConfigSection5");
                    ConfigurationHelper.SetSection(inputConfigurationSection, "MyConfigSection6");
                    var outputConfigurationSection1 = ConfigurationHelper.GetSection<ConfigurationSection>("MyConfigSection5");
                    var outputConfigurationSection2 = ConfigurationHelper.GetSection<ConfigurationSection>("MyConfigSection6");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigurationSection1);
                    AssertHelper.IsNotNull(() => outputConfigurationSection2);
                    AssertHelper.AreSame(inputConfigurationSection, () => outputConfigurationSection1);
                    AssertHelper.AreSame(inputConfigurationSection, () => outputConfigurationSection2);
                    AssertHelper.AreSame(outputConfigurationSection2, () => outputConfigurationSection1);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }
    }
}
