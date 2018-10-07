using System;
using DocumentEditorLib;

namespace DocumentEditorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Разработайте консольное приложение, позволяющее пользователю создать документ, 
            содержащий блоки текста и изображений, и сохранить его в HTML-формате.*/

            // пока только с параграфами
            // создать док и сохранить его в хтмл

            Document doc = new Document();
            string title = doc.GetTitle();
            doc.SetTitle("Super title");
            title = doc.GetTitle();

            Console.WriteLine("Hello World 2!");
        }
    }
}
