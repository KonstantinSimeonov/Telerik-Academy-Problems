using System;

namespace Flyweight
{
    public class Emoticon : IFlyweightEmoticon
    {
        // this is the reusable part i.e. intrinsic value
        public string TextContent { get; private set; }

        public Emoticon(string content)
        {
            this.TextContent = content;
        }

        // this is the changing part of the emoticon i.e. the extrinsic value
        public void Print(string user, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(user + ": " + this.TextContent);
        }
    }
}