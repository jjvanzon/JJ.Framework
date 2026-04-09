namespace JJ.Framework.Presentation.Resources.Tests
{
    [TestClass]
    public class CommonTitlesTests
    {
        [TestMethod]
        public void Add_ReturnsExpectedValue()
        {
            string result = CommonTitles.Add;
            Assert.AreEqual("Add", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Cancel_ReturnsExpectedValue()
        {
            string result = CommonTitles.Cancel;
            Assert.AreEqual("Cancel", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete_ReturnsExpectedValue()
        {
            string result = CommonTitles.Delete;
            Assert.AreEqual("Delete", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit_ReturnsExpectedValue()
        {
            string result = CommonTitles.Edit;
            Assert.AreEqual("Edit", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EntityCount_ReturnsExpectedTemplate()
        {
            string result = CommonTitles.EntityCount;
            Assert.AreEqual("Number of {0}", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ID_ReturnsExpectedValue()
        {
            string result = CommonTitles.ID;
            Assert.AreEqual("ID", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Language_ReturnsExpectedValue()
        {
            string result = CommonTitles.Language;
            Assert.AreEqual("Language", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LogIn_ReturnsExpectedValue()
        {
            string result = CommonTitles.LogIn;
            Assert.AreEqual("LogIn", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LogOut_ReturnsExpectedValue()
        {
            string result = CommonTitles.LogOut;
            Assert.AreEqual("LogOut", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void New_ReturnsExpectedValue()
        {
            string result = CommonTitles.New;
            Assert.AreEqual("New", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void No_ReturnsExpectedValue()
        {
            string result = CommonTitles.No;
            Assert.AreEqual("No", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void None_ReturnsExpectedValue()
        {
            string result = CommonTitles.None;
            Assert.AreEqual("None", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void NotAuthorized_ReturnsExpectedValue()
        {
            string result = CommonTitles.NotAuthorized;
            Assert.AreEqual("NotAuthorized", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Remove_ReturnsExpectedValue()
        {
            string result = CommonTitles.Remove;
            Assert.AreEqual("Remove", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Save_ReturnsExpectedValue()
        {
            string result = CommonTitles.Save;
            Assert.AreEqual("Save", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Search_ReturnsExpectedValue()
        {
            string result = CommonTitles.Search;
            Assert.AreEqual("Search", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Yes_ReturnsExpectedValue()
        {
            string result = CommonTitles.Yes;
            Assert.AreEqual("Yes", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ResourceManager_IsNotNull()
        {
            var resourceManager = CommonTitles.ResourceManager;
            Assert.IsNotNull(resourceManager);
        }
    }
}
