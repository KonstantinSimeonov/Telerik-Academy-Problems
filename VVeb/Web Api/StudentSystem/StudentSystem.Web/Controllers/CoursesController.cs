namespace StudentSystem.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using System.Web.Http;
    using Data;
    using Models;
    using StudentSystem.Models;
    using System.Linq;
    using System.Web.Http.Cors;

    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class CoursesController : StudentSystemApiController
    {
        public CoursesController(IStudentSystemData data, IModelFactory models)
            : base(data, models)
        {
        }

        public CoursesController()
            : base()
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.data.Courses.All().ProjectTo<CourseResponseModel>());
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] CourseResponseModel model)
        {
            if(!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var result = this.models.Get<Course>(model);

            this.data.Courses.Add(result);
            this.data.SaveChanges();

            return this.Created(this.Url.ToString(), result);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] CourseResponseModel model)
        {
            if(!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var course = this.data.Courses
                                        .SearchFor(c => c.Name == model.Name)
                                        .FirstOrDefault();

            if(course == null)
            {
                return this.NotFound();
            }

            course.Description = model.Description;

            this.data.Courses.Update(course);

            this.data.SaveChanges();

            return this.Ok(course);
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromBody] string guid)
        {
            var course = this.data.Courses.SearchFor(c => c.Id.ToString() == guid).FirstOrDefault();

            if(course == null)
            {
                return this.NotFound();
            }

            this.data.Courses.Delete(course);
            this.data.SaveChanges();

            return this.Ok(course);
        }
    }
}