﻿using ExampleLib;
using System;

namespace ExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Component fileSystem = new Directory("File system");

            // определяем новый диск
            Component diskC = new Directory("Disk C");

            // новые файлы
            Component pngFile = new File("12345.png");
            Component docxFile = new File("Document.docx");

            // добавляем файлы на диск С
            diskC.Add(pngFile);
            diskC.Add(docxFile);

            // добавляем диск С в файловую систему
            fileSystem.Add(diskC);

            // выводим все данные
            fileSystem.Print();
            Console.WriteLine();

            // удаляем с диска С файл
            diskC.Remove(pngFile);

            // создаем новую папку
            Component docsFolder = new Directory("My documents");

            // добавляем в нее файлы
            Component txtFile = new File("readme.txt");
            Component csFile = new File("Program.cs");
            docsFolder.Add(txtFile);
            docsFolder.Add(csFile);

            diskC.Add(docsFolder);

            fileSystem.Print();

            Console.Read();
        }
    }
}
