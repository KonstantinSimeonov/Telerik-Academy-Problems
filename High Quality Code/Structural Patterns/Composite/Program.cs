namespace Composite
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var container = new HtmlElement("div");

            var navBar = new HtmlElement("nav")
                            .AppendChild(new HtmlElement("button").AppendChild(new TextElement("Home")));

            navBar.AppendChild(new HtmlElement("button").AppendChild(new TextElement("Log in or register")));

            container.AppendChild(navBar);

            var p = new HtmlElement("p");
            var text = new TextElement("Nqkoy pravi izvrashteniya sus C#");

            p.AppendChild(text);
            container.AppendChild(p);

            Console.WriteLine(container.Render(0));

            container.RemoveChild(p);

            Console.WriteLine(container.Render(0));
        }
    }
}