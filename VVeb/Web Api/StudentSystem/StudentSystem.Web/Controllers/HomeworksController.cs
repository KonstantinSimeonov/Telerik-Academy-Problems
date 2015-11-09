namespace StudentSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using StudentSystem.Models;

    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class HomeworksController : StudentSystemApiController
    {
        public HomeworksController(IStudentSystemData data, IModelFactory models)
            : base(data, models)
        {
        }

        public HomeworksController()
            : base()
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.data.Courses.All().SelectMany(c => c.Homeworks).ProjectTo<HomeworkResponseModel>());
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] HomeworkResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var student = this.data.Students
                                        .SearchFor(s => s.StudentIdentification == model.StudentIdentification)
                                        .FirstOrDefault();

            if (student == null)
            {
                return this.BadRequest();
            }

            var course = this.data.Courses.SearchFor(c => c.Id.ToString() == model.CourseId).FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest();
            }

            var homeworkToAdd = new Homework()
            {
                FileUrl = model.FileUrl,
                TimeSent = DateTime.Now
            };

            course.Homeworks.Add(homeworkToAdd);
            student.Homeworks.Add(homeworkToAdd);

            this.data.SaveChanges();

            return this.Ok(model);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] HomeworkResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var student = this.data.Students
                                        .SearchFor(s => s.StudentIdentification == model.StudentIdentification)
                                        .FirstOrDefault();

            if (student == null)
            {
                return this.NotFound();
            }

            var homework = student.Homeworks.FirstOrDefault(h => h.Id == model.Id);

            if (homework == null)
            {
                return this.NotFound();
            }

            homework.FileUrl = model.FileUrl;
            this.data.SaveChanges();

            return this.Ok(homework);
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromBody] HomeworkResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var course = this.data.Courses.All().FirstOrDefault(c => c.Homeworks.Any(h => h.Id == model.Id));
            var student = this.data.Students.All().FirstOrDefault(s => s.Homeworks.Any(h => h.Id == model.Id));

            if (course == null && student == null)
            {
                return this.NotFound();
            }

            var homeworkToRemove = (course == null ? student.Homeworks : course.Homeworks).FirstOrDefault(h => h.Id == model.Id);

            if (course != null)
            {
                course.Homeworks.Remove(homeworkToRemove);
            }

            if (student != null)
            {
                student.Homeworks.Remove(homeworkToRemove);
            }

            return this.Ok(homeworkToRemove);
        }

    }
}