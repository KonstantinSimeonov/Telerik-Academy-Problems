namespace Flyweight
{
    using System;

    public interface IFlyweightEmoticon
    {
        // instrinsic state
        string TextContent { get; }
        // extrinsic state
        void Print(string user, int x, int y);
    }
}