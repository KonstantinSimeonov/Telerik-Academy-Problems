namespace Composite
{
    using System.Collections.Generic;

    public interface IHtmlElement : IDomElement
    {
        string Tag { get; }
        IList<IDomElement> Children { get; }

        IHtmlElement AppendChild(IDomElement element);
        IHtmlElement RemoveChild(IDomElement element);
    }
}