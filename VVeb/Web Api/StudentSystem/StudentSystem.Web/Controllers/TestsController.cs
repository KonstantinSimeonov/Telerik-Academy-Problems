namespace StudentSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using StudentSystem.Models;

    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class TestsController : StudentSystemApiController
    {
        public TestsController(IStudentSystemData data, IModelFactory models)
            : base(data, models)
        {
        }

        public TestsController()
            : base()
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.data.Tests.All().ProjectTo<TestResponseModel>());
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] TestResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var test = this.models.Get<Test>(model);

            this.data.Tests.Add(test);
            this.data.SaveChanges();

            return this.Created(this.Url.ToString(), model);
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromBody] TestResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var testToDelete = this.data.Tests.All().FirstOrDefault(t => t.Id == model.Id);

            if(testToDelete == null)
            {
                return this.NotFound();
            }

            this.data.Tests.Delete(testToDelete);
            this.data.SaveChanges();

            return this.Ok(model);
        }
    }
}