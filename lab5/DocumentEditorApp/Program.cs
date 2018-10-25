using System;
using System.Collections.Generic;
using DocumentEditorLib;

namespace DocumentEditorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document();
            Menu menu = new Menu();

            menu.AddItem("Help", "Displays information about commands", 
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
            menu.AddItem("InsertParagraph", "Inserts text into the document position",
                new List<ICommand>
                {
                    new InsertParagraph(doc, -1, "str")   //как сюда передавать строку и число?
                }
            );
            menu.AddItem("DeleteItem", "Deletes the document element in transmitted position",
                new List<ICommand>
                {
                    new DeleteItem(doc, 1)
                }
            );
            menu.AddItem("Undo", "Cancels the previous command",
                new List<ICommand>
                {
                    new Undo(doc)
                }
            );
            menu.AddItem("Redo", "Executes the canceled command",
                new List<ICommand>
                {
                    new Redo(doc)
                }
            );
            menu.AddItem("Save", "Saves the document in html-file",
                new List<ICommand>
                {
                    new Save(doc, "some-path")
                }
            );
            menu.Run();

            Console.WriteLine("Bye");
            Console.Read();
        }
    }
}
