using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace JJ.Framework.Configuration.Tests
{
    [TestClass]
    public class ConfigurationSectionTests
    {
        //[TestMethod]
        //public void Test_ConfigurationSection_WithGenericClass()
        //{
        //    Assembly assembly = typeof(IPersistenceConfiguration).Assembly;
        //    var section = new ConfigurationSection<IPersistenceConfiguration>(assembly);

        //    string contextType = section.GetValue(x => x.ContextType);
        //    string location = section.GetValue(x => x.Location);
        //    string modelAssembly1 = section.GetValue(x => x.ModelAssemblies[0]);
        //}

        //[TestMethod]
        //public void Test_ConfigurationSection_WithGenericClass_WithSubConfiguration()
        //{
        //    var section = new ConfigurationSection<IPersistenceConfiguration>("jj.framework.configuration.tests");

        //    string contextType = section.GetValue(x => x.ContextType);
        //    string location = section.GetValue(x => x.Location);
        //    string assembly1 = section.GetValue(x => x.ModelAssemblies[0]);

        //    int someProperty = section.GetElement(x => x.SubConfiguration).GetValue(x => x.SomeProperty);
        //}

        //[TestMethod]
        //public void Test_ConfigurationSection_WithStaticGenericClass()
        //{
        //    Assembly assembly = typeof(JJ.Framework.Configuration.ConfigurationSection<>).Assembly;
        //    var section = new ConfigurationSection<IPersistenceConfiguration>(assembly);

        //    string contextType = Configuration<IPersistenceConfiguration>.GetSection(assembly).GetValue(x => x.ContextType);
        //    string assembly1 = Configuration<IPersistenceConfiguration>.GetSection(assembly).GetValue(x => x.ModelAssemblies[0]);
        //    int someProperty = Configuration<IPersistenceConfiguration>.GetSection(assembly).GetValue(x => x.SubConfiguration).GetValue(x => x.SomeProperty);
        //}

        //[TestMethod]
        //public void Test_ConfigurationSection_WithStaticGenericClass_WithSectionNameConvention()
        //{
        //    // This would not require a complicated expression translator,
        //    // but it would be kind of lazy not to make a proper expression translator
        //    string contextType = Configuration<IPersistenceConfiguration>.GetValue(x => x.ContextType);
        //    string assembly1 = Configuration<IPersistenceConfiguration>.GetValue(x => x.ModelAssemblies[0]);
        //    int someProperty = Configuration<IPersistenceConfiguration>.GetValue(x => x.SubConfiguration).GetValue(x => x.SomeProperty);
        //}

        // Complex Expression Translator

        // This would be nice, but requires complex expression resolution.
        // Or actually, just requires a special expression translator.

        [TestMethod]
        public void Test_ConfigurationSection_WithStaticGenericClass_SectionNameConvention_AndComplexExpressionTranslator()
        {
            string contextType = Configuration<IPersistenceConfiguration>.GetValue(x => x.ContextType);
            //string assembly1 = Configuration<IPersistenceConfiguration>.GetValue(x => x.ModelAssemblies[0]);
            int someProperty = Configuration<IPersistenceConfiguration>.GetValue(x => x.SubConfiguration.SomeProperty);
        }

        [TestMethod]
        public void Test_ConfigurationSection_WithStaticGenericClass_CustomSectionName_AndComplexExpressionTranslator()
        {
            ConfigurationSection<IPersistenceConfiguration> configuration;

            // Method 1: section name based on configuration interface's assembly.
            configuration = new ConfigurationSection<IPersistenceConfiguration>();

            // Method 2: section name based on assembly.
            configuration = new ConfigurationSection<IPersistenceConfiguration>(typeof(IPersistenceConfiguration).Assembly);

            // Method 3: custom section name.
            configuration = new ConfigurationSection<IPersistenceConfiguration>("jj.framework.configuration.tests");
            
            string contextType = configuration.GetValue(x => x.ContextType);
            //string assembly1 = configuration.GetValue(x => x.ModelAssemblies[0]);
            //int someProperty = configuration.GetValue(x => x.SubConfiguration.SomeProperty);
        }

        // Custom Classes

        // Rejected idea.
        // The interfacing would be awsome like this,
        // but it requires you to create a custom class for every step in the property path,
        // which we were trying to prevent.

        //[TestMethod]
        //public void Test_ConfigurationSection_WithCustomStaticClass()
        //{
        //    string contextType = PersistenceConfiguration.ContextType;
        //    string assembly1 = PersistenceConfiguration.ModelAssemblies[0];
        //    int someProperty = PersistenceConfiguration.SubConfiguration.Property;
        //}

        //[TestMethod]
        //public void Test_ConfigurationSection_WithCustomClass()
        //{
        //    var section = new PersistenceConfiguration();

        //    string contextType = section.ContextType;
        //    string location = section.Location;
        //    string assembly1 = section.ModelAssemblies[0];
        //}
    }
}
