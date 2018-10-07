using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentEditorLib;

namespace DocumentEditorTest
{
    [TestClass]
    public class DocumentTests
    {
        /*
         ������������ ���������� ����������, ����������� ������������ ������� ��������, 
         ���������� ����� ������ � �����������, � ��������� ��� � HTML-�������.
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
