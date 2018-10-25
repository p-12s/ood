using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DocumentEditorLib
{
    // как тут добавить картинки по красоте?
    public class DocumentItem
    {
        private Paragraph _paragraph;
        private Img _img;

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

        void InsertParagraph(int position, string text, bool isNotRestoreCommand = true);

        void DeleteItem(int index);

        void Undo();

        void Redo();

        void Save(string path);

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

            // как считать 
        // InsertParagraph <позиция>|end <текст параграфа>
        public void InsertParagraph(int position, string text, bool isNotRestoreCommand = true)
        {
            if (position > _items.Count)
            {
                Console.WriteLine("Position {0} does not exist, enter from 0 to {1}", position, (_items.Count - 1));
            }

            DocumentItem item = new DocumentItem(new Paragraph(text));
            if (position == -1) // в конец
            {
                _items.AddLast(item);
            }
            else
            {
                //for(int i = 0; i < _items.)
                //AddAfter(LinkedListNode<T> node, T value): вставляет в список новый узел со значением value после узла node.
                //LinkedListNode<Person> tom = persons.AddLast(new Person() { Name = "Tom" });

                LinkedListNode<DocumentItem> lastItem = _items.First;
                if (lastItem == null)
                {
                    _items.AddLast(item);
                }
                else
                {
                    int index = 0;
                    while (position > index)
                    {
                        lastItem = lastItem.Next;
                        index += 1;
                    }
                    //_items.AddAfter(lastItem, item); lastItem почему-то null
                    _items.AddLast(item);
                }
            }

            if (isNotRestoreCommand)
                _history.AddCommand(new InsertParagraph(this, position, text));
        }

        public void DeleteItem(int index)
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
                Console.WriteLine("Undo operation cannot be performed");
            }

        }

        public void Redo()
        {
            if (_history.CanRedo())
                _history.Redo();
            else
                Console.WriteLine("Redo operation cannot be performed");
        }

        public DocumentItem GetItem(int index) // может сделать приватным? извне он не нужен
        {
            if (index >= 0 && index <= (_items.Count - 1))
            {
                return _items.ElementAt(index);
            }
            return null;
        }

        public void Save(string path)
        {
            string paragraphList = "";
            foreach (var item in _items)
            {
                paragraphList += "<p>" + item.GetItem().GetText() + "</p>";
            }

            string html = string.Format("<!doctype html>" +
                "<html lang=\"en\">" +
                "<head>" +
                "<meta charset=\"utf-8\">" +
                "<title>{0}</title>" +
                "</head>" +
                "<body>" +
                "{1}" +
                "</body>" +
                "</html>", _title ?? "", paragraphList);

            // передавать директорию, в ней создавать папку
            using (StreamWriter writer = new StreamWriter(@"C:\Users\user\Desktop\test.html"))
            {
                writer.Write(html);
            }

        }

        /*
        void InsertImage(Img img)
        {
            //Paragraph paragraph = new Paragraph(text);
            throw new NotImplementedException();
        }*/
    }

}
