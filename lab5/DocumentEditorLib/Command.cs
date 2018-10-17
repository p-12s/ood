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
            ◦ Выводит название и список элементов документа в стандартный поток вывода. Пример вывода
            ▪ Title: Это заголовок документа
            ▪ 0. Paragraph: Это самый первый параграф
            ▪ 1. Image: 400 300 images/img1.png
            ▪ 2. Paragraph: Это параграф, идущий следом за изображением.
             */
            //_document.TurnOn();
            Console.WriteLine("run List");
        }
    };

}
