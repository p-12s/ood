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

        LinkedList<DocumentItem> GetDocumentItems();

        void InsertItem(DocumentItem documentItem, int? position = null);

        void InsertParagraph(string text, int? position = null);

        void DeleteItem(int index);

        /*
        void InsertImage(Img img);

        T GetItem(int index);
        
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

        // хранение истории. для простоты пусть помнит все
        private List<ICommand> _commandHistory;


        public Document(string title = null)
        {
            if (!string.IsNullOrEmpty(title))
                _title = title;
            _items = new LinkedList<DocumentItem>();
        }

        public string GetTitle()
        {
            return _title ?? "-";
        }

        public void SetTitle(string title)
        {
            _title = title;
        }

        public LinkedList<DocumentItem> GetDocumentItems()
        {
            return _items;
        }

        public void InsertItem(DocumentItem documentItem, int? position = null)
        {
            if (position == null)
                _items.AddLast(documentItem);
        }

        // Вставляет параграф текста в указанную позицию (сдвигая последующие элементы)
        // Если параметр position не указан, вставка происходит в конец документа
        // InsertParagraph <позиция>|end <текст параграфа>
        public void InsertParagraph(string text, int? position = null)
        {
            if (position > _items.Count)
            {
                Console.WriteLine("Position {0} does not exist, enter from 0 to {1}", position, (_items.Count - 1));
            }
            DocumentItem item = new DocumentItem(new Paragraph(text));
            if (position == null)
            {
                _items.AddLast(item);
            }
            else
            {
                _items.AddLast(item);//так-то надо по индексу вставлять, пока пойдет
            }
        }

        public void DeleteItem(int index)//лучше использовать массив, а не LinkedList
        {
            _items.RemoveLast();
        }

        /*
        void InsertImage(Img img)
        {
            //Paragraph paragraph = new Paragraph(text);
            throw new NotImplementedException();
        }


        public DocumentItem<T> GetItem(int index)
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
