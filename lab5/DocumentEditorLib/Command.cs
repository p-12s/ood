using System;

namespace DocumentEditorLib
{
    public interface ICommand
    {
        void Execute();
    }

    public class Help : ICommand
    {
        public void Execute()
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
            /*
            ▪ Title: Это заголовок документа
            ▪ 0. Paragraph: Это самый первый параграф
            ▪ 1. Image: 400 300 images/img1.png
            ▪ 2. Paragraph: Это параграф, идущий следом за изображением.
             */
            Console.WriteLine("Title: " + _document.GetTitle());
            int i = 1;
            foreach(var item in _document.GetDocumentItems())
            {
                Console.WriteLine(i + ": " + item.GetItem().GetText());
                ++i;
            }
        }
    };

    public class InsertParagraph : ICommand
    {
        private Document _document;
        private string _text;
        private int _position;

        public InsertParagraph(Document document, string text, int? position = null)
        {
            _document = document;
            _text = text;

            _position = position ?? (_document.GetDocumentItems().Count - 1);
        }

        public void Execute()
        {
            _document.InsertParagraph(_text, _position);
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
            _document.DeleteItem(_index);//снимает отметку
        }
    };
}
