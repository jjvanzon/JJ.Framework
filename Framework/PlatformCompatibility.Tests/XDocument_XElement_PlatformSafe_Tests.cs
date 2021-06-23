using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using JJ.Framework.IO.Core;
using JJ.Framework.PlatformCompatibility.Core;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.PlatformCompatibility.Tests
{
    [TestClass]
    public class XDocument_XElement_PlatformSafe_Tests
    {
        // TODO: Varying the content among tests?
        private const string XML = "<root><value>2</value></root>";

        [TestMethod]
        public void Test_XDocument_Save_PlatformSafe()
        {
            string fileName = "";
            try
            {
                // Arrange
                fileName = GenerateFileName();
                XDocument docToSave = XDocument.Parse(XML);
                string contentToSave = docToSave.ToString();

                // Act
                docToSave.Save_PlatformSafe(fileName);

                // Assert
                XDocument docLoaded = XDocument.Load(fileName);
                string contentLoaded = docLoaded.ToString();
                AssertHelper.AreEqual(contentToSave, () => contentLoaded);
            }
            finally
            {
                // Clean Up
                if (File.Exists(fileName)) File.Delete(fileName);
            }
        }

        [TestMethod]
        public void Test_XDocument_Save_WithDotNet()
        {
            string fileName = "";
            try
            {
                // Arrange
                fileName = GenerateFileName();
                XDocument docToSave = XDocument.Parse(XML);
                string contentToSave = docToSave.ToString();

                // Act
                docToSave.Save(fileName);

                // Assert
                XDocument docLoaded = XDocument.Load(fileName);
                string contentLoaded = docLoaded.ToString();
                AssertHelper.AreEqual(contentToSave, () => contentLoaded);
            }
            finally
            {
                // Clean Up
                if (File.Exists(fileName)) File.Delete(fileName);
            }
        }

        [TestMethod]
        public void Test_XElement_Save_PlatformSafe_WithFileName()
        {
            string fileName = "";
            try
            {
                // Arrange
                fileName = GenerateFileName();
                XElement elementToSave = XElement.Parse(XML);
                string contentToSave = elementToSave.ToString();

                // Act
                elementToSave.Save_PlatformSafe(fileName);

                // Assert
                XElement elementLoaded = XElement.Load(fileName);
                string contentLoaded = elementLoaded.ToString();
                AssertHelper.AreEqual(contentToSave, () => contentLoaded);
            }
            finally
            {
                // Clean Up
                if (File.Exists(fileName)) File.Delete(fileName);
            }
        }

        [TestMethod]
        public void Test_XElement_Save_WithDotNet_WithFileName()
        {
            string fileName = "";
            try
            {
                // Arrange
                fileName = GenerateFileName();
                XElement elementToSave = XElement.Parse(XML);
                string contentToSave = elementToSave.ToString();

                // Act
                elementToSave.Save(fileName);

                // Assert
                XElement elementLoaded = XElement.Load(fileName);
                string contentLoaded = elementLoaded.ToString();
                AssertHelper.AreEqual(contentToSave, () => contentLoaded);
            }
            finally
            {
                // Clean Up
                if (File.Exists(fileName)) File.Delete(fileName);
            }
        }

        [TestMethod]
        public void Test_XElement_Save_PlatformSafe_WithStream()
        {
            string fileName = "";
            try
            {
                // Arrange
                fileName = GenerateFileName();
                XElement elementToSave = XElement.Parse(XML);
                string contentToSave = elementToSave.ToString();

                using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    // Act
                    elementToSave.Save_PlatformSafe(stream);
                }

                // Assert
                XElement elementLoaded = XElement.Load(fileName);
                string contentLoaded = elementLoaded.ToString();
                AssertHelper.AreEqual(contentToSave, () => contentLoaded);
            }
            finally
            {
                // Clean Up
                if (File.Exists(fileName)) File.Delete(fileName);
            }
        }

        [TestMethod]
        public void Test_XElement_Save_WithDotNet_WithStream()
        {
            string fileName = "";
            try
            {
                // Arrange
                XElement elementToSave = XElement.Parse(XML);
                fileName = GenerateFileName();
                string contentToSave = elementToSave.ToString();

                using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    // Act
                    elementToSave.Save(stream);
                }

                // Assert
                XElement elementLoaded = XElement.Load(fileName);
                string contentLoaded = elementLoaded.ToString();
                AssertHelper.AreEqual(contentToSave, () => contentLoaded);
            }
            finally
            {
                // Clean Up
                if (File.Exists(fileName)) File.Delete(fileName);
            }
        }

        // Helper

        private string GenerateFileName([CallerMemberName] string callerMemberName = "")
            => FileHelperCore.GetNumberedFilePath($"{callerMemberName}.xml", numberPrefix: "_", numberSuffix: "");
    }
}
