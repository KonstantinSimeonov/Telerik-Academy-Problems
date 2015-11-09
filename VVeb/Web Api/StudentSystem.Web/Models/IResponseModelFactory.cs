namespace StudentSystem.Web.Models
{
    public interface IModelFactory
    {
        void Map<T, R>();

        void MapDoubly<T, R>();

        T Get<T>(object model);
    }
}
