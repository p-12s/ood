namespace DocumentEditorLib
{
    public interface IParagraph
    {
        string GetText();
        void SetText(string text);
    };

    public class Paragraph : IParagraph
    {
        private string _text;

        public Paragraph(string text = null)
        {
            _text = text;
        }

        public string GetText()
        {
            return _text;
        }

        public void SetText(string text)
        {
            _text = text;
        }
    }
}
