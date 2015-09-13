namespace Factories.Contracts
{
    public interface ICharacterFactory
    {
        ICharacter CreateCharacter(string characterType);
    }
}