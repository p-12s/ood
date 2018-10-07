using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentEditorLib;

namespace DocumentEditorTest
{
    [TestClass]
    public class ParagraphTests
    {
        [TestMethod]
        public void HasText()
        {
            Paragraph p = new Paragraph();
            Assert.AreEqual(p.GetText(), null);

            p.SetText("Hello. a'm paragraph");
            Assert.AreEqual(p.GetText(), "Hello. a'm paragraph");
        }
    }
}
