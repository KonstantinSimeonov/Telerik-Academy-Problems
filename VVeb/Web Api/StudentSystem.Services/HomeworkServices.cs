namespace StudentSystem.Services
{
    using Data.Repositories;
    using Models;
    using System.Linq;

    public class HomeworkServices
    {
        private IGenericRepository<Homework> homeworks;

        public HomeworkServices(IGenericRepository<Homework> homeworksRepository)
        {
            this.homeworks = homeworksRepository;
        }

        public Homework GetHomeworkFromUrl(string url)
        {
            var result = this.homeworks
                                    .All()
                                    .FirstOrDefault(h => h.FileUrl == url);

            return result;
        }

        public IQueryable<Homework> GetHomeworkForCourseByCourse(string courseName)
        {
            var result = this.homeworks
                                    .All()
                                    .Where(h => h.Course.Name == courseName);

            return result;
        }
    }
}
