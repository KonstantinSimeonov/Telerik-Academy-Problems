namespace StudentSystem.Services
{
    using Data.Repositories;
    using Models;
    using System.Linq;
    using System;

    public class TestServices
    {
        private IGenericRepository<Test> tests;

        public TestServices(IGenericRepository<Test> testsRepository)
        {
            this.tests = testsRepository;
        }

        public IQueryable<Test> GetAllTestsForStudent(Student student)
        {
            var result = this.tests
                                .All()
                                .Where(t => t.Students.Contains(student));
            return result;
        }

        public double GetAverageLevelForParticipants(int testId)
        {
            var test = this.tests
                                .All()
                                .FirstOrDefault(t => t.Id == testId);
            if(test == null)
            {
                throw new InvalidOperationException("The test with the given Id was not found");
            }

            var average = test.Students
                                    .Select(x => x.Level)
                                    .Average();

            return average;
        }
    }
}
