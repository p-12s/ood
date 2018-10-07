using System;
using System.Collections.Generic;

namespace DocumentEditorLib
{
    /* Интерфес документа */
    public interface IDocument
    {
        List<IParagraph> InsertParagraph(string text, int? position = null);

        int GetItemsCount();

        // Доступ к элементам изображения
        ConstDocumentItem GetItem(int index);
        //DocumentItem GetItem(int index);

        void DeleteItem(int index);

        string GetTitle();

        void SetTitle(string title); // ref?

	    // Сообщает о доступности операции Undo
        bool CanUndo();

        // Отменяет команду редактирования
        void Undo();

        // Сообщает о доступности операции Redo
        bool CanRedo();

        // Выполняет отмененную команду редактирования
        void Redo();

        // Сохраняет документ в формате html. Изображения сохраняются в подкаталог images
        // пути к изображениям указываются относительно пути к сохраняемому HTML файлу
        void Save(string path);

    }

    public class Document : IDocument
    {
        private string _title;
        private LinkedList<DocumentItem> _items;

        public Document(string title = null)
        {
            if (!string.IsNullOrEmpty(title))
                _title = title;
            _items = new LinkedList<DocumentItem>();
        }

        public string GetTitle()
        {
            return _title;
        }

        public void SetTitle(string title)
        {
            _title = title;
        }

        public int GetItemsCount()
        {
            return _items.Count;
        }

        public List<IParagraph> InsertParagraph(string text, int? position = null)
        {
            throw new NotImplementedException();
        }

        public ConstDocumentItem GetItem(int index)
        {
            throw new NotImplementedException();
        }
        /*
        public DocumentItem GetItem(int index)
        {
            throw new NotImplementedException();
        }*/

        public void DeleteItem(int index)
        {
            throw new NotImplementedException();
        }        

        public bool CanUndo()
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }

        public bool CanRedo()
        {
            throw new NotImplementedException();
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }

        public void Save(string path)
        {
            throw new NotImplementedException();
        }
    }

    /* Неизменяемый элемент документа */
    public class ConstDocumentItem
    {
        // Возвращает указатель на константное изображение, либо nullptr, если элемент не является изображением
        public Image GetImage()
        {
            throw new NotImplementedException();
        }

        // Возвращает указатель на константный параграф, либо nullptr, если элемент не является параграфом
        public Paragraph GetParagraph()
        {
            throw new NotImplementedException();
        }
    };

    /* Элемент документа. Позволяет получить доступ к изображению или параграфу */
    class DocumentItem : ConstDocumentItem
    {
	    // Возвращает указатель на изображение, либо nullptr, если элемент не является изображением
	    public Image GetImage() //shared_ptr
        {
            throw new NotImplementedException();
        }

        // Возвращает указатель на параграф, либо nullptr, если элемент не является параграфом
        public Paragraph GetParagraph()
        {
            throw new NotImplementedException();
        }

    };

}
