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

        // Complex Example

        [TestMethod]
        public void Test_ConfigurationHelper_ComplexExample()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var input_AutoNamed_ConfigSection = new ConfigurationSection();
                    var input_AutoNamed_ConfigSection_FromDifferentAssembly = new object(); // Using a class from another assembly. should render a different auto-generated name.
                    var input_ExplicitlyNamed_ConfigSection = new ConfigurationSection2();
                    var input_Another_ConfigSection = new ConfigurationSection3();
                    // Same-ness
                    var input_ConfigSection_OfSameType = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(input_AutoNamed_ConfigSection);
                    ConfigurationHelper.SetSection(input_AutoNamed_ConfigSection_FromDifferentAssembly);
                    ConfigurationHelper.SetSection(input_ExplicitlyNamed_ConfigSection, "MyConfigSection");
                    ConfigurationHelper.SetSection(input_Another_ConfigSection, "AnotherConfigSection");
                    // Same-ness
                    ConfigurationHelper.SetSection(input_AutoNamed_ConfigSection, "DuplicateConfigSection");
                    ConfigurationHelper.SetSection(input_ConfigSection_OfSameType, "ConfigSectionOfSameType");

                    var output_AutoNamed_ConfigSection = ConfigurationHelper.GetSection<ConfigurationSection>("jj.framework.common.tests");
                    var output_AutoNamed_ConfigSection_FromDifferentAssembly = ConfigurationHelper.GetSection<object>("mscorlib");
                    var output_ExplicitlyNamed_ConfigSection = ConfigurationHelper.GetSection<ConfigurationSection2>("MyConfigSection");
                    var output_Another_ConfigSection = ConfigurationHelper.GetSection<ConfigurationSection3>("AnotherConfigSection");
                    // Same-ness
                    var output_Duplicate_ConfigSection = ConfigurationHelper.GetSection<ConfigurationSection>("DuplicateConfigSection");
                    var output_ConfigSection_OfSameType = ConfigurationHelper.GetSection<ConfigurationSection>("ConfigSectionOfSameType");
                    // Names Unspecified
                    var output_ConfigSection_ByOmittedName = ConfigurationHelper.GetSection<ConfigurationSection>();
                    var output_ConfigSection_ByNullName = ConfigurationHelper.GetSection<ConfigurationSection>(null);
                    var output_ConfigSection_ByEmptyName = ConfigurationHelper.GetSection<ConfigurationSection>("");
                    var output_ConfigSection_ByWhiteSpaceName = ConfigurationHelper.TryGetSection<ConfigurationSection>(" ");

                    // Assert
                    AssertHelper.IsNotNull(() => output_AutoNamed_ConfigSection);
                    AssertHelper.IsNotNull(() => output_AutoNamed_ConfigSection_FromDifferentAssembly);
                    AssertHelper.IsNotNull(() => output_ExplicitlyNamed_ConfigSection);
                    AssertHelper.IsNotNull(() => output_Another_ConfigSection);
                    AssertHelper.AreSame(input_AutoNamed_ConfigSection, () => output_AutoNamed_ConfigSection);
                    AssertHelper.AreSame(input_AutoNamed_ConfigSection_FromDifferentAssembly, () => output_AutoNamed_ConfigSection_FromDifferentAssembly);
                    AssertHelper.AreSame(input_ExplicitlyNamed_ConfigSection, () => output_ExplicitlyNamed_ConfigSection);
                    AssertHelper.AreSame(input_Another_ConfigSection, () => output_Another_ConfigSection);
                    AssertHelper.AreSame(input_ConfigSection_OfSameType, () => output_ConfigSection_OfSameType);
                    // Same-ness
                    AssertHelper.IsNotNull(() => output_Duplicate_ConfigSection);
                    AssertHelper.IsNotNull(() => output_ConfigSection_OfSameType);
                    AssertHelper.AreSame(input_AutoNamed_ConfigSection, () => output_Duplicate_ConfigSection);
                    AssertHelper.NotSame(input_AutoNamed_ConfigSection , () => input_ConfigSection_OfSameType);
                    // Names Unspecified
                    AssertHelper.IsNotNull(() => output_ConfigSection_ByOmittedName);
                    AssertHelper.IsNotNull(() => output_ConfigSection_ByNullName);
                    AssertHelper.IsNotNull(() => output_ConfigSection_ByEmptyName);
                    AssertHelper.IsNull(() => output_ConfigSection_ByWhiteSpaceName);
                    AssertHelper.AreSame(input_AutoNamed_ConfigSection, () => output_ConfigSection_ByOmittedName);
                    AssertHelper.AreSame(input_AutoNamed_ConfigSection, () => output_ConfigSection_ByNullName);
                    AssertHelper.AreSame(input_AutoNamed_ConfigSection, () => output_ConfigSection_ByEmptyName);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }

        // Auto-Generated Names

        [TestMethod]
        public void Test_ConfigurationHelper_AutoGeneratedNames_DifferentAssembly_DifferentName()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigSection1 = new ConfigurationSection();
                    var inputConfigSection2 = new object();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigSection1);
                    ConfigurationHelper.SetSection(inputConfigSection2);

                    var outputConfigSection1_ByName = ConfigurationHelper.GetSection<ConfigurationSection>("jj.framework.common.tests");
                    var outputConfigSection1_NameOmitted = ConfigurationHelper.GetSection<ConfigurationSection>();
                    var outputConfigSection2_ByName = ConfigurationHelper.GetSection<object>("mscorlib");
                    var outputConfigSection2_NameOmitted = ConfigurationHelper.GetSection<object>();

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigSection1_ByName);
                    AssertHelper.IsNotNull(() => outputConfigSection1_NameOmitted);
                    AssertHelper.IsNotNull(() => outputConfigSection2_ByName);
                    AssertHelper.IsNotNull(() => outputConfigSection2_NameOmitted);
                    AssertHelper.AreSame(inputConfigSection1, () => outputConfigSection1_ByName);
                    AssertHelper.AreSame(inputConfigSection1, () => outputConfigSection1_NameOmitted);
                    AssertHelper.AreSame(inputConfigSection2, () => outputConfigSection2_ByName);
                    AssertHelper.AreSame(inputConfigSection2, () => outputConfigSection2_NameOmitted);
                    AssertHelper.NotSame(outputConfigSection1_ByName, () => outputConfigSection2_ByName);
                    AssertHelper.NotSame(outputConfigSection1_NameOmitted, () => outputConfigSection2_NameOmitted);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }

        // SetSection, GetSection

        [TestMethod]
        public void Test_ConfigurationHelper_SetSection_GetSection_Succeeds_SectionNameOmitted()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigSection);
                    var outputConfigSection = ConfigurationHelper.GetSection<ConfigurationSection>();

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigSection);
                    AssertHelper.AreSame(inputConfigSection, () => outputConfigSection);
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
                    var inputConfigSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigSection, null);
                    var outputConfigSection = ConfigurationHelper.GetSection<ConfigurationSection>(null);

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigSection);
                    AssertHelper.AreSame(inputConfigSection, () => outputConfigSection);
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
                    var inputConfigSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigSection, "");
                    var outputConfigSection = ConfigurationHelper.GetSection<ConfigurationSection>("");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigSection);
                    AssertHelper.AreSame(inputConfigSection, () => outputConfigSection);
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
                    var inputConfigSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigSection, "MyConfigSection");
                    var outputConfigSection = ConfigurationHelper.GetSection<ConfigurationSection>("MyConfigSection");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigSection);
                    AssertHelper.AreSame(inputConfigSection, () => outputConfigSection);
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
                    var inputConfigSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigSection);
                    var outputConfigSection = ConfigurationHelper.TryGetSection<ConfigurationSection>();

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigSection);
                    AssertHelper.AreSame(inputConfigSection, () => outputConfigSection);
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
                    var inputConfigSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigSection, null);
                    var outputConfigSection = ConfigurationHelper.TryGetSection<ConfigurationSection>(null);

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigSection);
                    AssertHelper.AreSame(inputConfigSection, () => outputConfigSection);
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
                    var inputConfigSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigSection, "");
                    var outputConfigSection = ConfigurationHelper.TryGetSection<ConfigurationSection>("");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigSection);
                    AssertHelper.AreSame(inputConfigSection, () => outputConfigSection);
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
                    var inputSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputSection, "MyConfigSection");
                    var outputConfigSection = ConfigurationHelper.TryGetSection<ConfigurationSection>("MyConfigSection");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigSection);
                    AssertHelper.AreSame(inputSection, () => outputConfigSection);
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
                    var inputConfigSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigSection);
                    var outputConfigSection = ConfigurationHelper.GetSection<ConfigurationSection>("jj.framework.common.tests");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigSection);
                    AssertHelper.AreSame(inputConfigSection, () => outputConfigSection);
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
                    var inputConfigSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigSection, null);
                    var outputConfigSection = ConfigurationHelper.GetSection<ConfigurationSection>("jj.framework.common.tests");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigSection);
                    AssertHelper.AreSame(inputConfigSection, () => outputConfigSection);
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
                    var inputConfigSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigSection, "");
                    var outputConfigSection = ConfigurationHelper.GetSection<ConfigurationSection>("jj.framework.common.tests");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigSection);
                    AssertHelper.AreSame(inputConfigSection, () => outputConfigSection);
                }
                finally
                {
                    // Clean Up
                    ConfigurationHelper_Accessor._sections.Clear();
                }
            }
        }

        // Not Found

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
                    "Configuration section with name 'MyConfigSection' was not set. " +
                    "To allow JJ.Framework.Common to use this configuration section, " +
                    "call JJ.Framework.Common.ConfigurationHelper.SetSection.";

                AssertHelper.ThrowsException(
                    () => ConfigurationHelper.GetSection<ConfigurationSection>("MyConfigSection"),
                    expectedMessage);
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_TryGetSection_SectionNotFound_ReturnsNull_SectionNameOmitted()
        {
            lock (_lock)
            {
                var configSection = ConfigurationHelper.TryGetSection<ConfigurationSection>();
                AssertHelper.IsNull(() => configSection);
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_TryGetSection_SectionNotFound_ReturnsNull_SectionNameNull()
        {
            lock (_lock)
            {
                var configSection = ConfigurationHelper.TryGetSection<ConfigurationSection>(null);
                AssertHelper.IsNull(() => configSection);
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_TryGetSection_SectionNotFound_ReturnsNull_SectionNameEmpty()
        {
            lock (_lock)
            {
                var configSection = ConfigurationHelper.TryGetSection<ConfigurationSection>("");
                AssertHelper.IsNull(() => configSection);
            }
        }

        [TestMethod]
        public void Test_ConfigurationHelper_TryGetSection_SectionNotFound_ReturnsNull_SectionNameProvided()
        {
            lock (_lock)
            {
                var configSection = ConfigurationHelper.TryGetSection<ConfigurationSection>("MyConfigSection");
                AssertHelper.IsNull(() => configSection);
            }
        }

        // Edge Cases

        [TestMethod]
        public void Test_ConfigurationHelper_EdgeCase_SetSection_ArgumentNullException()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    string expectedMessage = $"Value cannot be null.{Environment.NewLine}Parameter name: section";

                    // Act
                    AssertHelper.ThrowsException<ArgumentNullException>(
                        () => ConfigurationHelper.SetSection<ConfigurationSection>(null),
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
        public void Test_ConfigurationHelper_EdgeCase_SetSection_AlreadyCalled_ThrowsException()
        {
            lock (_lock)
            {
                try
                {
                    // Arrange
                    var inputConfigSection = new ConfigurationSection();
                    ConfigurationHelper.SetSection(inputConfigSection);

                    // Act
                    AssertHelper.ThrowsException(
                        () => ConfigurationHelper.SetSection(inputConfigSection),
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
                        "Configuration section with name 'MyConfigSection2' was not set. " +
                        "To allow JJ.Framework.Common to use this configuration section, " +
                        "call JJ.Framework.Common.ConfigurationHelper.SetSection.";
                    var inputConfigSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigSection, "MyConfigSection1");
                    AssertHelper.ThrowsException(
                        () => ConfigurationHelper.GetSection<ConfigurationSection>("MyConfigSection2"),
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
                    var inputConfigSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigSection, "jj.framework.common.tests");
                    var outputConfigSection = ConfigurationHelper.GetSection<ConfigurationSection>();

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigSection);
                    AssertHelper.AreSame(inputConfigSection, () => outputConfigSection);
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
                    var inputConfigSection1 = new ConfigurationSection();
                    var inputConfigSection2 = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigSection1, "");
                    ConfigurationHelper.SetSection(inputConfigSection2, " ");
                    var outputConfigSection1 = ConfigurationHelper.GetSection<ConfigurationSection>("");
                    var outputConfigSection2 = ConfigurationHelper.GetSection<ConfigurationSection>(" ");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigSection1);
                    AssertHelper.IsNotNull(() => outputConfigSection2);
                    AssertHelper.AreSame(inputConfigSection1, () => outputConfigSection1);
                    AssertHelper.AreSame(inputConfigSection2, () => outputConfigSection2);
                    AssertHelper.NotSame(outputConfigSection1, () => outputConfigSection2);
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
                    var inputConfigSection = new ConfigurationSection();

                    // Act
                    ConfigurationHelper.SetSection(inputConfigSection, "MyConfigSection1");
                    ConfigurationHelper.SetSection(inputConfigSection, "MyConfigSection2");
                    var outputConfigSection1 = ConfigurationHelper.GetSection<ConfigurationSection>("MyConfigSection1");
                    var outputConfigSection2 = ConfigurationHelper.GetSection<ConfigurationSection>("MyConfigSection2");

                    // Assert
                    AssertHelper.IsNotNull(() => outputConfigSection1);
                    AssertHelper.IsNotNull(() => outputConfigSection2);
                    AssertHelper.AreSame(inputConfigSection, () => outputConfigSection1);
                    AssertHelper.AreSame(inputConfigSection, () => outputConfigSection2);
                    AssertHelper.AreSame(outputConfigSection2, () => outputConfigSection1);
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
