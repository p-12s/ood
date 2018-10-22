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

    public class InsertParagraph : ICommand
    {
        private Document _document;
        private string _text;
        private string _previousText;
        private int _position;

        public InsertParagraph(Document document, string text, int? position = null)
        {
            _document = document;
            _text = text;

            _position = position ?? (_document.GetDocumentItems().Count - 1);
            
            // сохраняю текст на случай отмены операции
            if (position == null || _position == _document.GetDocumentItems().Count - 1)
            {
                _previousText = null;
            }
            else
            {
                _previousText = document.GetItem(_position).GetItem().GetText();
            }
            
        }

        // если нужно выполнить "восстановление" удаленной - передаем false
        public void Execute(bool isNotRestoreCommand = true)
        {
            _document.InsertParagraph(_text, _position, isNotRestoreCommand);
        }

        public void Unexecute()
        {
            if (_previousText == null)
                _document.DeleteItem(_position);
            else
                _document.InsertParagraph(_previousText, _position);
        }
    };

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
}
