using System;

namespace DocumentEditorLib
{
    public interface ICommand
    {
        void Execute();
        void Unexecute();
    }

    public class Help : ICommand
    {
        public void Execute() // может не стоит там перехватывать
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

        public void Execute()
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

        public void Execute()
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

        // делаем еще и инвертированную команду
        // причем каждый экземпляр будет содержать разные значения
        public InsertParagraph(Document document, string text, int? position = null)
        {
            _document = document;
            _text = text;

            _position = position ?? (_document.GetDocumentItems().Count - 1);
            _previousText = document.;// предыдущий текст в изменяемой позиции закидываю в отменение операции
        }

        public void Execute()
        {
            _document.InsertParagraph(_text, _position);//
        }

        public void Unexecute()
        {
            Console.WriteLine("Unexecute InsertParagraph");
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

    public class Undo : ICommand
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

    public class Redo : ICommand
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
}
