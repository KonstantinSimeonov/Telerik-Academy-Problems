namespace StudentSystem.Web.Models
{
    using System;

    public class TestResponseModel
    {
        public int Id { get; set; }

        public virtual Guid CourseId { get; set; }
    }
}