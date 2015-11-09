namespace StudentSystem.Web.Controllers
{
    using System.Web.Http;
    using Data;
    using Models;

    public abstract class StudentSystemApiController : ApiController
    {
        protected IStudentSystemData data;
        protected IModelFactory models;

        public StudentSystemApiController(IStudentSystemData data, IModelFactory models)
        {
            this.data = data;
            this.models = models;
        }

        public StudentSystemApiController()
            : this(new StudentsSystemData(), new ResponseModelFactory())
        {
        }
    }
}