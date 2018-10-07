using System;
using System.Collections.Generic;

namespace DocumentEditorLib
{
    // как тут добавить картинки по красоте?
    public class DocumentItem
    {
        private Paragraph _paragraph;

        public DocumentItem(Paragraph paragraph)
        {
            _paragraph = paragraph;
        }

        public Paragraph GetItem()
        {
            return _paragraph;
        }
    };

    /* Интерфейс документа */
    public interface IDocument
    {
        string GetTitle();

        void SetTitle(string title);

        LinkedList<DocumentItem> GetDocumentItem();

        void InsertItem(DocumentItem documentItem, int? position = null);

        /*
        void InsertImage(Img img);

        T GetItem(int index);

        void DeleteItem(int index);

        void InsertParagraph(Paragraph paragraph);
        
        bool CanUndo();

        void Undo();

        bool CanRedo();

        void Redo();

        // Сохраняет документ в формате html. Изображения сохраняются в подкаталог images
        // пути к изображениям указываются относительно пути к сохраняемому HTML файлу
        void Save(string path);
        */
    }

    public class Document : IDocument
    {
        private string _title;
        private LinkedList<DocumentItem> _items;

        public Document(string title = null)
        {
            if (!string.IsNullOrEmpty(title))
                _title = title;
            _items = new LinkedList<DocumentItem>();
        }

        public string GetTitle()
        {
            return _title;
        }

        public void SetTitle(string title)
        {
            _title = title;
        }

        public LinkedList<DocumentItem> GetDocumentItem()
        {
            return _items;
        }

        public void InsertItem(DocumentItem documentItem, int? position = null)
        {
            if (position == null)
                _items.AddLast(documentItem);


        }

        /*void InsertParagraph(Paragraph paragraph)
        {
            //Paragraph paragraph = new Paragraph(text);
            throw new NotImplementedException();
        }

        void InsertImage(Img img)
        {
            //Paragraph paragraph = new Paragraph(text);
            throw new NotImplementedException();
        }


        public DocumentItem<T> GetItem(int index)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(int index)
        {
            throw new NotImplementedException();
        }        

        public bool CanUndo()
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }

        public bool CanRedo()
        {
            throw new NotImplementedException();
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }

        public void Save(string path)
        {
            throw new NotImplementedException();
        }*/
    }

}
