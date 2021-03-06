﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DocumentEditorLib
{
    /*public interface IDocumentItem
    {
        void Insert(int position, string text);
        Paragraph Delete(int position);
    }   
    */

    public interface IDocument// : IDocumentItem
    {
        string GetTitle();
        void SetTitle(string title);
        void InsertParagraph(int position, string text);
        Paragraph DeleteParagraph(int position);
        LinkedList<IParagraph> GetDocumentItems();
    }


    public class Document : IDocument
    {
        private string _title;
        private LinkedList<IParagraph> _items;
        private History _history;

        public Document(string title)
        {
            _title = title;
            _items = new LinkedList<IParagraph>();
            _history = new History();
        }

        public string GetTitle()
        {
            return _title;
        }

        public void SetTitle(string title)
        {
            _title = title;
            //_history.AddCommand(new SetTitle(this, title));
        }

        public void InsertParagraph(int position, string text)
        {
            var cmd = new InsertParagraph(this, position, text);
        }

        public Paragraph DeleteParagraph(int position)
        {
            //бывает удалить нужно как первый, так средний и конечный элемент

            // может тут возвращать этот элемент? 
            if (position >= 0 && position < _items.Count)
            {
                var deletedItem = _items.ElementAt(position);
                _items.Remove(deletedItem);
            }

            return null;
            // удалить item из коллекции и вернуть его
        }

        public LinkedList<IParagraph> GetDocumentItems()
        {
            return _items;
        }

        
        /*
        

        public void Undo()
        {
            if (_history.CanUndo())
            {
                _history.Undo();
            }
            else
            {
                Console.WriteLine("Undo operation cannot be performed");
            }

        }

        public void Redo()
        {
            if (_history.CanRedo())
                _history.Redo();
            else
                Console.WriteLine("Redo operation cannot be performed");
        }

        public DocumentItem GetItem(int index) // может сделать приватным? извне он не нужен
        {
            if (index >= 0 && index <= (_items.Count - 1))
            {
                return _items.ElementAt(index);
            }
            return null;
        }

        public void Save(string path)
        {
            string paragraphList = "";
            foreach (var item in _items)
            {
                paragraphList += "<p>" + item.GetItem().GetText() + "</p>";
            }

            string html = string.Format("<!doctype html>" +
                "<html lang=\"en\">" +
                "<head>" +
                "<meta charset=\"utf-8\">" +
                "<title>{0}</title>" +
                "</head>" +
                "<body>" +
                "{1}" +
                "</body>" +
                "</html>", _title ?? "", paragraphList);

            // передавать директорию, в ней создавать папку
            using (StreamWriter writer = new StreamWriter(@"C:\Users\user\Desktop\test.html"))
            {
                writer.Write(html);
            }

        }

        
        void InsertImage(Img img)
        {
            //Paragraph paragraph = new Paragraph(text);
            throw new NotImplementedException();
        }*/
    }

}


/*
     // как считать 
        // InsertParagraph <позиция>|end <текст параграфа>
        public void InsertParagraph(int position, string text)
        {
            if (position < 0 || position > _items.Count)
            {
                Console.WriteLine("Position {0} does not exist, enter from 0 to {1}", position, (_items.Count - 1));
            }

            DocumentItem item = new DocumentItem(new Paragraph(text));

            LinkedListNode<DocumentItem> lastItem = _items.First;
            if (lastItem == null)
            {
                _items.AddLast(item);
            }
            else
            {
                int index = 0;
                while (position > index)
                {
                    lastItem = lastItem.Next;
                    index += 1;
                }
                //_items.AddAfter(lastItem, item); lastItem почему-то null
                _items.AddLast(item);
            }

        }
     */

