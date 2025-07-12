using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using JJ.Framework.IO.Core;
using JJ.Framework.PlatformCompatibility.Core;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.PlatformCompatibility.Tests
{
    [Suppress("Trimmer", "IL2026", Justification = ExpressionsWithArrays)]
    [TestClass]
    public class XDocument_XElement_PlatformSafe_Tests
    {
        [TestMethod]
        public void Test_XDocument_Save_PlatformSafe()
        {
            string fileName = "";
            try
            {
                // Arrange
                fileName = GetFileName();
                string xml = GetXml();
                XDocument documentToSave = XDocument.Parse(xml);
                string contentToSave = documentToSave.ToString();

                // Act
                documentToSave.Save_PlatformSafe(fileName);

                // Assert
                XDocument documentLoaded = XDocument.Load(fileName);
                string contentLoaded = documentLoaded.ToString();
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
                fileName = GetFileName();
                string xml = GetXml();
                XDocument documentToSave = XDocument.Parse(xml);
                string contentToSave = documentToSave.ToString();

                // Act
                documentToSave.Save(fileName);

                // Assert
                XDocument documentLoaded = XDocument.Load(fileName);
                string contentLoaded = documentLoaded.ToString();
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
                fileName = GetFileName();
                string xml = GetXml();
                XElement elementToSave = XElement.Parse(xml);
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
                fileName = GetFileName();
                string xml = GetXml();
                XElement elementToSave = XElement.Parse(xml);
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
                fileName = GetFileName();
                string xml = GetXml();
                XElement elementToSave = XElement.Parse(xml);
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
                fileName = GetFileName();
                string xml = GetXml();
                XElement elementToSave = XElement.Parse(xml);
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

        private string GetXml([CallerMemberName] string callerMemberName = "")
            => $"<root><testName>{callerMemberName}</testName></root>";

        private string GetFileName([CallerMemberName] string callerMemberName = "")
            => FileHelperCore.GetNumberedFilePath($"{callerMemberName}.xml", numberPrefix: "_", numberSuffix: "");
    }
}
