namespace Flyweight
{
    using System;

    public interface IFlyweightEmoticon
    {
        string TextContent { get; }
        void Print(string user, int x, int y);
    }
}