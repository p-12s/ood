using System;
using System.Collections.Generic;
using System.IO;

namespace DocumentEditorLib
{
    /* Параграф текста */
    public interface IParagraph
    {
        string GetText();
        void SetText(string text);
    };

    /* Изображение */
    public interface IImage
    {
        // Возвращает путь относительно каталога документа
        Path GetPath();

        // Ширина изображения в пикселях
        int GetWidth();

        // Высота изображения в пикселях
        int GetHeight();

        // Изменяет размер изображения
        void Resize(int width, int height);
    }

    /* Интерфес документа */
    public interface IDocument
    {
        // Вставляет параграф текста в указанную позицию (сдвигая последующие элементы)
        // Если параметр position не указан, вставка происходит в конец документа
        List<IParagraph> InsertParagraph(string text, int? position = null);

        // Возвращает количество элементов в документе
        int GetItemsCount();

        // Доступ к элементам изображения
        ConstDocumentItem GetItem(int index);
        //DocumentItem GetItem(int index);

        // Удаляет элемент из документа
        void DeleteItem(int index);

        // Возвращает заголовок документа
        string GetTitle();

        // Изменяет заголовок документа
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
        void Save(Path path);
    }

    /* Неизменяемый элемент документа */
    public class ConstDocumentItem
    {
        // Возвращает указатель на константное изображение, либо nullptr, если элемент не является изображением
        public List<IImage> GetImage()
        {
            throw new NotImplementedException();
        }

        // Возвращает указатель на константный параграф, либо nullptr, если элемент не является параграфом
        public List<IParagraph> GetParagraph()
        {
            throw new NotImplementedException();
        }
    };

    /* Элемент документа. Позволяет получить доступ к изображению или параграфу */
    class DocumentItem : ConstDocumentItem
    {
	    // Возвращает указатель на изображение, либо nullptr, если элемент не является изображением
	    public List<IImage> GetImage()
        {
            throw new NotImplementedException();
        }

        // Возвращает указатель на параграф, либо nullptr, если элемент не является параграфом
        public List<IParagraph> GetParagraph()
        {
            throw new NotImplementedException();
        }

    };

}
