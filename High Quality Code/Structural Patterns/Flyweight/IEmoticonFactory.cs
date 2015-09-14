namespace Flyweight
{
    public interface IEmoticonFactory
    {
        IFlyweightEmoticon GetEmoticon(string content);
    }
}
