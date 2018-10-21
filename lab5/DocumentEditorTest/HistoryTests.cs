using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentEditorLib;

namespace DocumentEditorTest
{
    [TestClass]
    public class HistoryTests
    {
        Document _document;
        History _emptyHistory;
        History _10SameCommandsHistory;
        History _5SameCommandsHistory;

        public HistoryTests()
        {
            _document = new Document();
            _emptyHistory = new History();
            _10SameCommandsHistory = new History();
            _5SameCommandsHistory = new History();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            _10SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "1"));
            _10SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "2"));
            _10SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "3"));
            _10SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "4"));
            _10SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "5"));
            _10SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "6"));
            _10SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "7"));
            _10SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "8"));
            _10SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "9"));
            _10SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "10"));

            _5SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "1"));
            _5SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "2"));
            _5SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "3"));
            _5SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "4"));
            _5SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "5"));
            _5SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "6"));
            _5SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "7"));
            _5SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "8"));
            _5SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "9"));
            _5SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "10"));
        }

        [TestMethod()]
        public void ByDefaultCanNotUndo()
        {
            Assert.IsFalse(_emptyHistory.CanUndo());
        }

        [TestMethod]
        public void ByDefaultCanNotRedo()
        {
            Assert.IsFalse(_emptyHistory.CanRedo());
        }

        [TestMethod]
        public void WhenInHistory10CommandsCanNotRedo()
        {
            Assert.IsFalse(_10SameCommandsHistory.CanRedo());
        }

        [TestMethod]
        public void WhenInHistory10CommandsCanUndo()
        {
            Assert.IsTrue(_10SameCommandsHistory.CanUndo());
        }

        [TestMethod]
        public void CanCancelNoMoreThanLast10Comands()
        {
            _10SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "11"));
            _10SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "12"));

            _10SameCommandsHistory.Undo();
            _10SameCommandsHistory.Undo();
            _10SameCommandsHistory.Undo();
            _10SameCommandsHistory.Undo();
            _10SameCommandsHistory.Undo();
            _10SameCommandsHistory.Undo();
            _10SameCommandsHistory.Undo();
            _10SameCommandsHistory.Undo();
            _10SameCommandsHistory.Undo();
            _10SameCommandsHistory.Undo();
            Assert.IsFalse(_10SameCommandsHistory.CanUndo());
        }

        [TestMethod]
        public void WhenInHistory5CanseledCommandsCanUndoAndRedo()
        {
            _10SameCommandsHistory.Undo();
            _10SameCommandsHistory.Undo();
            _10SameCommandsHistory.Undo();
            _10SameCommandsHistory.Undo();
            _10SameCommandsHistory.Undo();
            Assert.IsTrue(_10SameCommandsHistory.CanUndo());
            Assert.IsTrue(_10SameCommandsHistory.CanRedo());
        }

        [TestMethod]
        public void rewritedHistoryIsCleared()
        {
            _10SameCommandsHistory.Undo();
            _10SameCommandsHistory.Undo();
            _10SameCommandsHistory.Undo();
            _10SameCommandsHistory.Undo();
            _10SameCommandsHistory.Undo();
            Assert.IsTrue(_10SameCommandsHistory.CanRedo());
            _10SameCommandsHistory.AddAndExecuteCommand(new InsertParagraph(_document, "6-new"));
            Assert.IsFalse(_10SameCommandsHistory.CanRedo());
        }
    }
}
