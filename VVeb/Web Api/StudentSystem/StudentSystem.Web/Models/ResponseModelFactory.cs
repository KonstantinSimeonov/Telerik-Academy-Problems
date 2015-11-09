namespace StudentSystem.Web.Models
{
    using AutoMapper;

    public class ResponseModelFactory : IModelFactory
    {
        public void Map<T, R>()
        {
            Mapper.CreateMap<T, R>();
        }

        public void MapDoubly<T, R>()
        {
            this.Map<T, R>();
            this.Map<R, T>();
        }

        public T Get<T>(object model)
        {
            return Mapper.Map<T>(model);
        }
    }
}