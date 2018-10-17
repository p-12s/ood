using System;
using System.Collections.Generic;
using DocumentEditorLib;

namespace DocumentEditorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Разработайте консольное приложение, позволяющее пользователю создать документ, 
            содержащий блоки текста и изображений, и сохранить его в HTML-формате.*/

            
            // портировать весь с++ код
            // пока только с параграфами
            // добавить и удалить параграф
            // распечатать хелп
            // сохранить его в хтмл
            // хочу добавлять параграфы

            Document doc = new Document();
            Menu menu = new Menu();

            menu.AddItem("Help", "Displays information about the available editing commands and their arguments", 
                new List<ICommand>
                {
                    new Help()
                }
            );
            menu.AddItem("List", "Displays the title and list of elements of the document",
                new List<ICommand>
                {
                    new List(doc)
                }
            );

            menu.Run();

            Console.WriteLine("Bye");
            Console.Read();
        }
    }
}
