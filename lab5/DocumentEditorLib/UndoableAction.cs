using System;

namespace DocumentEditorLib
{
    public interface IUndoableAction
    {
        void Execute();
        void Unexecute();
    }

    public class SetTitle : IUndoableAction
    {
        private Document _document;
        private string _title;
        private string _prevTitle;

        public SetTitle(Document document, string title)
        {
            _document = document;
            _prevTitle = document.GetTitle();
            _title = title;
        }

        public void Execute()
        {
            _document.SetTitle(_title);
        }

        public void Unexecute()
        {
            _document.SetTitle(_prevTitle);
        }
    };


    public class InsertParagraph : IUndoableAction
    {
        IDocument _doc;
        Paragraph _paragraph;
        int _position;

        public InsertParagraph(IDocument doc, int position, string text) // end преобразовать в последний номер, пока -1
        {
            _doc = doc;
            _position = position;
            _paragraph = new Paragraph(text);
        }

        public void Execute()
        {
            _doc.InsertParagraph(_position, _paragraph.GetText());
        }

        public void Unexecute()
        {
            _doc.DeleteParagraph(_position);
        }
    };


    /*
    public class DeleteItem : IUndoableAction
    {
        private Document _document;
        private int _index;

        public DeleteItem(Document document, int index)
        {
            _document = document;
            _index = index;
        }

        public void Execute()
        {
            _document.DeleteItem(_index);//не реально удаляет, а помечает
        }

        public void Unexecute()
        {
            Console.WriteLine("Unexecute DeleteItem");
            //_document.DeleteItem(_index);//снимает отметку
        }
    };

    public class Undo : IUndoableAction
    {
        private Document _document;

        public Undo(Document document)
        {
            _document = document;
        }

        public void Execute()
        {
            _document.Undo();
        }

        public void Unexecute()
        {
            Console.WriteLine("Unexecute Undo");
        }
    };

    public class Redo : IUndoableAction
    {
        private Document _document;

        public Redo(Document document)
        {
            _document = document;
        }

        public void Execute()
        {
            _document.Redo();
        }

        public void Unexecute()
        {
            Console.WriteLine("Unexecute Redo");
        }
    };

    public class Save : IUndoableAction
    {
        private Document _document;
        private string _path;

        public Save(Document document, string path)
        {
            _document = document;
            _path = path;
        }

        public void Execute()
        {
            _document.Save(_path);
        }

        public void Unexecute()
        {
            Console.WriteLine("Unexecute Save");
        }
    };

    */

}
