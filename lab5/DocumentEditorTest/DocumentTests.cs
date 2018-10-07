using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentEditorLib;

namespace DocumentEditorTest
{
    [TestClass]
    public class DocumentTests
    {
        /*
         Разработайте консольное приложение, позволяющее пользователю создать документ, 
         содержащий блоки текста и изображений, и сохранить его в HTML-формате.
        */

        [TestMethod]
        public void HasTitle()
        {
            Document doc = new Document("Super title");
            Assert.AreEqual(doc.GetTitle(), "Super title");
        }

        [TestMethod]
        public void HasEmptyItemList()
        {
            Document doc = new Document("Super title");
            Assert.AreEqual(doc.GetItemsCount(), 0);
        }
        



    }
}
