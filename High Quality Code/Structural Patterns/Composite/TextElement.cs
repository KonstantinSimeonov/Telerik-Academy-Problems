namespace Composite
{
    public class TextElement : IDomElement
    {
        public string Text { get; set; }

        public TextElement(string text)
        {
            this.Text = text;
        }

        public string Render(int depth)
        {
            return new string(' ', depth) + this.Text;
        }
    }
}