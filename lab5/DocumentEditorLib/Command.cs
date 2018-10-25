using System;

namespace DocumentEditorLib
{
    public interface ICommand
    {
        void Execute(bool isNotRestoreCommand = true);
        void Unexecute();
    }

    public class Help : ICommand
    {
        public void Execute(bool isNotRestoreCommand = true) // может не стоит там перехватывать
        {
        }
        public void Unexecute()
        {
        }
    };

    public class List : ICommand
    {
        private Document _document;

        public List(Document document)
        {
            _document = document;
        }

        public void Execute(bool isNotRestoreCommand = true) // тут дублирование и бесполезость
        {
            Console.WriteLine("Title: " + _document.GetTitle());
            int i = 1;
            foreach(var item in _document.GetDocumentItems())
            {
                Console.WriteLine(i + ": " + item.GetItem().GetText());
                ++i;
            }
        }

        public void Unexecute()
        {
        }
    };

    public class SetTitle : ICommand
    {
        private Document _document;
        private string _title;

        public SetTitle(Document document, string title)
        {
            _document = document;
            _title = title;
        }

        public void Execute(bool isNotRestoreCommand = true)
        {
            _document.SetTitle(_title);
        }

        public void Unexecute()
        {
            Console.WriteLine("Unexecute SetTitle");
        }
    };

    interface IDocumentItems
    {
        void InsertItem(DocumentItem item, int position);
        DocumentItem RemoveItem(int position);
    }


    public class InsertParagraph : ICommand
    {
        //private Document _document;
        //private string _text;
        //private string _previousText;
        //private int _position;

        IDocumentItems _items;
        DocumentItem _paragraphItem;
        int _position;
        //передавать интер
        public InsertParagraph(IDocumentItems items, int position, string text) // end преобразовать в последний номер, пока -1
        {
            _paragraphItem = new DocumentItem(new Paragraph(text));
            _position = position;
            _items = items;

            //_document = document;
            //_text = text;

            //_position = (position == -1) ? (_document.GetDocumentItems().Count - 1) : position;
            
            //// сохраняю текст на случай отмены операции
            //if (_position == _document.GetDocumentItems().Count - 1)
            //{
            //    _previousText = null;
            //}
            //else
            //{
            //    _previousText = document.GetItem(_position).GetItem().GetText();
            //}
        }

        // если нужно выполнить "восстановление" удаленной - передаем false
        public void Execute()
        {
            _items.InsertItem(_paragraphItem, _position);
            //_document.InsertParagraph(_position, _text, isNotRestoreCommand);
        }

        public void Unexecute()
        {
            _items.RemoveItem(_position);
            //if (_previousText == null)
            //    _document.DeleteItem(_position);
            //else
            //    _document.InsertParagraph(_position, _previousText);
        }
    };

    class Document1 : IDocumentItems
    {
        public void InsertItem(DocumentItem item, int position)
        {
           // поместить item в коллекцию
        }

        public DocumentItem RemoveItem(int position)
        {

            // удалить item из коллекции и вернуть его
        }

        void InsertParagraph(int pos, string text)
        {
            var cmd = new InsertParagraph(this, pos, text);
        }
    }

    public class DeleteItem : ICommand
    {
        private Document _document;
        private int _index;

        public DeleteItem(Document document, int index)
        {
            _document = document;
            _index = index;
        }

        public void Execute(bool isNotRestoreCommand = true)
        {
            _document.DeleteItem(_index);//не реально удаляет, а помечает
        }

        public void Unexecute()
        {
            Console.WriteLine("Unexecute DeleteItem");
            //_document.DeleteItem(_index);//снимает отметку
        }
    };

    public class Undo : ICommand
    {
        private Document _document;

        public Undo(Document document)
        {
            _document = document;
        }

        public void Execute(bool isNotRestoreCommand = true)
        {
            _document.Undo();
        }

        public void Unexecute()
        {
            Console.WriteLine("Unexecute Undo");
        }
    };

    public class Redo : ICommand
    {
        private Document _document;

        public Redo(Document document)
        {
            _document = document;
        }

        public void Execute(bool isNotRestoreCommand = true)
        {
            _document.Redo();
        }

        public void Unexecute()
        {
            Console.WriteLine("Unexecute Redo");
        }
    };

    public class Save : ICommand
    {
        private Document _document;
        private string _path;

        public Save(Document document, string path)
        {
            _document = document;
            _path = path;
        }

        public void Execute(bool isNotRestoreCommand = true)
        {
            _document.Save(_path);
        }

        public void Unexecute()
        {
            Console.WriteLine("Unexecute Save");
        }
    };
}
