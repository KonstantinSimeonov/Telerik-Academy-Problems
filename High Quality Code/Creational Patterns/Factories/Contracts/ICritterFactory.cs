namespace Factories.Contracts
{
    public interface ICritterFactory
    {
        ICritter Create(string type);
    }
}
