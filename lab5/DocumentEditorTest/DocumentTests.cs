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
                doc.InsertParagraph(-1, p);
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
            _10ParagraphsDocument.InsertParagraph(-1, "1");
            _10ParagraphsDocument.InsertParagraph(-1, "2");
            _10ParagraphsDocument.InsertParagraph(-1, "3");
            _10ParagraphsDocument.InsertParagraph(-1, "4");
            _10ParagraphsDocument.InsertParagraph(-1, "5");
            _10ParagraphsDocument.InsertParagraph(-1, "6");
            _10ParagraphsDocument.InsertParagraph(-1, "7");
            _10ParagraphsDocument.InsertParagraph(-1, "8");
            _10ParagraphsDocument.InsertParagraph(-1, "9");
            _10ParagraphsDocument.InsertParagraph(-1, "10");
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

        [TestMethod]
        public void CanUndo10LastParagraphInsertion()
        {
            _10ParagraphsDocument.InsertParagraph(-1, "11");
            _10ParagraphsDocument.InsertParagraph(-1, "12");
            _10ParagraphsDocument.InsertParagraph(-1, "13");

            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" });

            _10ParagraphsDocument.Undo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });

            _10ParagraphsDocument.Undo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" });

            _10ParagraphsDocument.Undo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"});

            _10ParagraphsDocument.Undo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" });

            _10ParagraphsDocument.Undo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8" });

            _10ParagraphsDocument.Undo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7" });

            _10ParagraphsDocument.Undo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6" });

            _10ParagraphsDocument.Undo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5" });

            _10ParagraphsDocument.Undo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4" });

            _10ParagraphsDocument.Undo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3" });

            _10ParagraphsDocument.Undo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3" });

            _10ParagraphsDocument.Undo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3" });
        }

        [TestMethod]
        public void CanRedo10LastParagraphInsertion()
        {
            _10ParagraphsDocument.InsertParagraph(-1, "11");
            _10ParagraphsDocument.InsertParagraph(-1, "12");
            _10ParagraphsDocument.InsertParagraph(-1, "13");

            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();

            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3" });

            _10ParagraphsDocument.Redo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4" });

            _10ParagraphsDocument.Redo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5" });

            _10ParagraphsDocument.Redo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6" });

            _10ParagraphsDocument.Redo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7" });

            _10ParagraphsDocument.Redo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8" });

            _10ParagraphsDocument.Redo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" });

            _10ParagraphsDocument.Redo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });

            _10ParagraphsDocument.Redo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" });

            _10ParagraphsDocument.Redo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });

            _10ParagraphsDocument.Redo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" });

            _10ParagraphsDocument.Redo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" });

            _10ParagraphsDocument.Redo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" });
        }

        [TestMethod]
        public void CanRedoParagraphInsertionWithClearHistory()
        {
            _10ParagraphsDocument.InsertParagraph(-1, "11");
            _10ParagraphsDocument.InsertParagraph(-1, "12");
            _10ParagraphsDocument.InsertParagraph(-1, "13");

            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();
            _10ParagraphsDocument.Undo();

            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3" });

            // восстановим часть старой истории
            _10ParagraphsDocument.Redo();
            _10ParagraphsDocument.Redo();
            _10ParagraphsDocument.Redo();
            _10ParagraphsDocument.Redo();
            _10ParagraphsDocument.Redo();
            _10ParagraphsDocument.Redo();
            _10ParagraphsDocument.Redo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });

            // напишем новую историю
            _10ParagraphsDocument.InsertParagraph(-1, "11'");
            _10ParagraphsDocument.InsertParagraph(-1, "12'");
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11'", "12'" });

            _10ParagraphsDocument.Redo(); // проверка, что Redo() "в будущее" при новой истории не срабатывает
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11'", "12'" });

            // вернемся до границы старой и новой истории
            _10ParagraphsDocument.Undo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11'" });

            _10ParagraphsDocument.Undo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });

            // видим, что можно восстанановить только новая историю
            _10ParagraphsDocument.Redo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11'" });

            _10ParagraphsDocument.Redo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11'", "12'" });

            _10ParagraphsDocument.Redo();
            AreDocumentTitleAndParagraphsEqual(_10ParagraphsDocument, null,
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11'", "12'" });
        }

        [TestMethod]
        public void CanSaveDocumentAsHTMLFile()
        {
            
            _10ParagraphsDocument.Save("test");
        }




        /* 
        доработки:

        дописать тесты для сохранения
        пофиксить проблему ввода кастомного текста при вставке параграфа

        - описания команд не нужны
        - сделать понятнее ввод команд: вставить параграф<тут текст> <позиция (необязательно)>
        - переносы между командами не нужны
        - вод должен быть компактным и простым
        */

        // потом реализовать оставиеся операции (замены текста и прочее)
    }
}
