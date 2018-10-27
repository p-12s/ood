using System;

namespace DocumentEditorLib
{
    /*
      Команда, используемая классом меню - это один вариант паттерна "Команда". 
      У неё не должно быть метода Unexecute. Команда, используемая историей Undo/Redo - 
      это другой вариант применения паттерна "Команда". 
      У неё уже должен быть метод Unexecute(). 
      Лучше дать им разные имена (Command для меню и UndoableEdit/Action для операций редактирования), 
      чтобы избежать путаницы. Можно еще положить в разные namespace-ы.
         */
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
            Console.WriteLine("Title: " + _document.GetTitle());
            int i = 1;
            foreach (var item in _document.GetDocumentItems())
            {
                Console.WriteLine(i + ": " + item.GetText());
                ++i;
            }
        }
    };

}
