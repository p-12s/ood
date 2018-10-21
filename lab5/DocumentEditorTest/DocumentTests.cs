using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentEditorLib;
using System.Collections.Generic;
using System.Linq;

namespace DocumentEditorTest
{
    [TestClass]
    public class DocumentTests
    {
        public void AreDocumentsEqual(Document document, string expectedTitle, LinkedList<DocumentItem> expectedList)
        {
            Assert.AreEqual(document.GetTitle(), expectedTitle);

            var items = document.GetDocumentItems();
            for (var i = 0; i < items.Count; i++)
            {
                // проверка только для параграфа
                var lhs = items.ElementAt(i).GetItem();
                var rhs = expectedList.ElementAt(i).GetItem();

                Assert.AreEqual(lhs.GetText(), rhs.GetText());
            }
        }

        [TestMethod]
        public void HasTitleAndItems()
        {
            Document docWithoutTitle = new Document();
            Assert.AreEqual(docWithoutTitle.GetTitle(), null);
            Assert.AreEqual(docWithoutTitle.GetDocumentItems().Count, 0);

            Document superDoc = new Document("Super title");
            Assert.AreEqual(superDoc.GetTitle(), "Super title");
            Assert.AreEqual(superDoc.GetDocumentItems().Count, 0);
        }

        [TestMethod]
        public void CanInsertParagraphIntoItemsList()
        {
            var expectedList = new LinkedList<DocumentItem>();
            Document doc = new Document("Hello");
            Assert.AreEqual(doc.GetDocumentItems().Count, expectedList.Count);

            doc.InsertItem(new DocumentItem(new Paragraph("Hi, I'm first paragraph!")));
            expectedList.AddLast(new DocumentItem(new Paragraph("Hi, I'm first paragraph!")));
            AreDocumentsEqual(doc, "Hello", expectedList);

            doc.InsertItem(new DocumentItem(new Paragraph("Ok, I'm second")));
            expectedList.AddLast(new DocumentItem(new Paragraph("Ok, I'm second")));
            AreDocumentsEqual(doc, "Hello", expectedList);
        }




    }
}
