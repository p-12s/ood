using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentEditorLib;
using System.Collections.Generic;
using System.Linq;

namespace DocumentEditorTest
{
    [TestClass]
    public class DocumentTests
    {
        Document _emptyDocument;
        Document _document;
        Document _10ParagraphsDocument;

        public DocumentTests()
        {
            _emptyDocument = new Document();
            _document = new Document();
            _10ParagraphsDocument = new Document();
        }

        public Document CreateTestDoc(string title, List<string> paragraphs = null)
        {
            Document doc = new Document(title);
            foreach (var p in paragraphs)
            {
                doc.InsertParagraph(p);
            }            
            return doc;
        }

        public void AreDocumentTitleAndParagraphsEqual(Document checkedDoc, 
            string expectedTitle,
            List<string> expectedParagraphs)
        {
            Assert.AreEqual(checkedDoc.GetTitle(), expectedTitle);

            var checkedItems = checkedDoc.GetDocumentItems();
            
            Assert.IsTrue(checkedItems.Count == expectedParagraphs.Count);

            for (var i = 0; i < checkedItems.Count; i++)
            {
                var checkedP = checkedItems.ElementAt(i).GetItem();
                var expectedP = expectedParagraphs[i];

                Assert.AreEqual(checkedP.GetText(), expectedP);
            }
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            _10ParagraphsDocument.InsertParagraph("1");
            _10ParagraphsDocument.InsertParagraph("2");
            _10ParagraphsDocument.InsertParagraph("3");
            _10ParagraphsDocument.InsertParagraph("4");
            _10ParagraphsDocument.InsertParagraph("5");
            _10ParagraphsDocument.InsertParagraph("6");
            _10ParagraphsDocument.InsertParagraph("7");
            _10ParagraphsDocument.InsertParagraph("8");
            _10ParagraphsDocument.InsertParagraph("9");
            _10ParagraphsDocument.InsertParagraph("10");
        }

        [TestMethod]
        public void HasNullTitleByDefault()
        {
            Assert.AreEqual(_emptyDocument.GetTitle(), null);
            
        }

        [TestMethod]
        public void HasZeroItemsByDefault()
        {
            Assert.AreEqual(_emptyDocument.GetDocumentItems().Count, 0);
        }

        // потом что можно делать с каждым видом элементов
        [TestMethod]
        public void CanCreateDocumentWithTitle()
        {
            Document doc = new Document("Title");
            Assert.AreEqual(doc.GetTitle(), "Title");
            Assert.AreEqual(doc.GetDocumentItems().Count, 0);
        }

        [TestMethod]
        public void CanEditTitleOfAnExistingDocument()
        {
            _emptyDocument.SetTitle("New title");
            Assert.AreEqual(_emptyDocument.GetTitle(), "New title");
            Assert.AreEqual(_emptyDocument.GetDocumentItems().Count, 0);
        }

       [TestMethod]
        public void CanAddParagraphs()
        {
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
        }

        // отменить с эффектом стирания истории
        [TestMethod]
        public void CanUndoAdditionOfParagraph()
        {
            _10ParagraphsDocument.InsertParagraph("11");
            _10ParagraphsDocument.InsertParagraph("12");
            _10ParagraphsDocument.InsertParagraph("13");


            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" });

            var c = _10ParagraphsDocument;

            _10ParagraphsDocument.Undo(); // теперь проверить, что знчение парагр изменилось

            var a = _10ParagraphsDocument;
        }

        [TestMethod]
        public void CanRedoAdditionOfParagraph()
        {
            /*Document expectedDoc = CreateTestDoc("Title",
                new List<string> { "first", "second", "third" });

            _document.SetTitle("Title");
            _document.InsertItem(new DocumentItem(new Paragraph("first")));
            _document.InsertItem(new DocumentItem(new Paragraph("second")));
            _document.InsertItem(new DocumentItem(new Paragraph("third")));

            AreDocumentTitleAndParagraphsEqual(_document, expectedDoc);*/
        }

        // и сохранить в хтмл


        // потом что можно делать вообще с доком

        // конец


    }
}
