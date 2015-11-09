namespace StudentSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using StudentSystem.Models;

    [EnableCors(origins:"*", methods:"*", headers:"*")]
    public class StudentsController : StudentSystemApiController
    {
        public StudentsController(IStudentSystemData data, IModelFactory models)
            : base(data, models)
        {
        }

        public StudentsController()
            : base()
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.data.Students.All().ProjectTo<StudentsResponseModel>());
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] StudentsResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var student = this.models.Get<Student>(model);

            this.data.Students.Add(student);
            
            this.data.SaveChanges();

            return this.Created(this.Url.ToString(), student);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] StudentsResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var student = this.data.Students
                                        .SearchFor(s => s.StudentIdentification == model.StudentIdentification)
                                        .FirstOrDefault();

            if(student == null)
            {
                return this.NotFound();
            }

            student.Level = model.Level;
            // moje da se e ojenil, kazva bobi
            student.LastName = model.LastName;

            this.data.Students.Update(student);
            this.data.SaveChanges();

            return this.Ok(student);
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromBody] StudentsResponseModel model)
        {
            var studentToRemove = this.data.Students
                                                .SearchFor(s => s.FirstName == model.FirstName && s.LastName == model.LastName)
                                                .FirstOrDefault();

            if(studentToRemove == null)
            {
                return this.NotFound();
            }

            this.data.Students.Delete(studentToRemove);
            this.data.SaveChanges();

            return this.Ok(studentToRemove);
        }
    }
}