namespace StudentSystem.Web
{
    using System.Web.Http;
    using AutoMapper;
    using StudentSystem.Models;
    using Models;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Mapper.CreateMap<Course, CourseResponseModel>();
            Mapper.CreateMap<CourseResponseModel, Course>();
            Mapper.CreateMap<Student, StudentsResponseModel>();
            Mapper.CreateMap<StudentsResponseModel, Student>();
            Mapper.CreateMap<Homework, HomeworkResponseModel>();
            Mapper.CreateMap<HomeworkResponseModel, Homework>();
            Mapper.CreateMap<Test, TestResponseModel>();
            Mapper.CreateMap<TestResponseModel, Test>();
        }
    }
}
