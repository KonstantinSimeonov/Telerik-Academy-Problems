namespace Composite
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class HtmlElement : IHtmlElement
    {
        private const string RenderFormat = "{2}<{0}>\n{1}{2}</{0}>";
        private const int IndentSpaceCount = 3;

        private IList<IDomElement> children;

        public string Tag { get; private set; }

        public HtmlElement(string tagName)
        {
            this.Tag = tagName;
            this.Children = new List<IDomElement>();
        }

        public IList<IDomElement> Children
        {
            get
            {
                return this.children;
            }

            private set
            {
                this.children = value;
            }
        }

        public IHtmlElement AppendChild(IDomElement element)
        {
            this.children.Add(element);
            return this;
        }

        public IHtmlElement RemoveChild(IDomElement element)
        {
            this.children.Remove(element);
            return this;
        }

        public string Render(int depth)
        {
            var renderedChildren = new StringBuilder();

            foreach (var child in this.children)
            {
                renderedChildren.AppendLine(child.Render(depth + IndentSpaceCount));
            }

            var indent = new string(' ', depth);
            var resultFormat = string.Format(RenderFormat, this.Tag, renderedChildren.ToString(), indent);

            return resultFormat;
        }
    }
}