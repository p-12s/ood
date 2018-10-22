using System;
using System.Collections.Generic;
using System.Linq;

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

        //void InsertItem(DocumentItem documentItem, int? position = null);

        void InsertParagraph(string text, int? position = null, bool isNotRestoreCommand = true);

        void DeleteItem(int index);

        void Undo();

        void Redo();

        /*
        void InsertImage(Img img);

        T GetItem(int index);

        // Сохраняет документ в формате html. Изображения сохраняются в подкаталог images
        // пути к изображениям указываются относительно пути к сохраняемому HTML файлу
        void Save(string path);
        */
    }

    public class Document : IDocument
    {
        private string _title;
        private LinkedList<DocumentItem> _items;
        private History _history;


        public Document(string title = null)
        {
            if (!string.IsNullOrEmpty(title))
                _title = title;
            _items = new LinkedList<DocumentItem>();
            _history = new History();
        }

        public string GetTitle()
        {
            return _title;
        }

        public void SetTitle(string title)
        {
            _title = title;
            _history.AddCommand(new SetTitle(this, title));
        }

        public LinkedList<DocumentItem> GetDocumentItems()
        {
            return _items;
        }

        /*public void InsertItem(DocumentItem documentItem, int? position = null)
        {
            if (position == null)
                _items.AddLast(documentItem);
        }*/

        public void InsertParagraph(string text, int? position = null, bool isNotRestoreCommand = true)
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
                _items.AddLast(item); // так-то надо по индексу вставлять, пока пойдет
            }
            //тут надо различать новую команду и осстанавлиаве6мую

            if (isNotRestoreCommand)
                _history.AddCommand(new InsertParagraph(this, text));
        }

        public void DeleteItem(int index)//лучше использовать массив, а не LinkedList
        {
            //бывает удалить нужно как первый, так средний и конечный элемент

            // может тут возвращать этот элемент? 
            if (index >= 0 && index < _items.Count)
            {
                var deletedItem = _items.ElementAt(index);
                _items.Remove(deletedItem);
            }
        }

        public void Undo()
        {
            if (_history.CanUndo())
            {
                _history.Undo();
            }
            else
            {
                Console.WriteLine("Операция отмены не может быть выполнена");
            }

        }

        public void Redo()
        {
            if (_history.CanRedo())
                _history.Redo();
            else
                Console.WriteLine("Операция возврата не может быть выполнена");
        }

        public DocumentItem GetItem(int index) // может сделать приватным? извне он не нужен
        {
            if (index >= 0 && index <= (_items.Count - 1))
            {
                return _items.ElementAt(index);
            }
            return null;
        }

        /*
        void InsertImage(Img img)
        {
            //Paragraph paragraph = new Paragraph(text);
            throw new NotImplementedException();
        }


        

        public void Save(string path)
        {
            throw new NotImplementedException();
        }*/
    }

}
