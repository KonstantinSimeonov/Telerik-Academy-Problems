namespace StudentSystem.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class HomeworkResponseModel
    {
        public int Id { get; set; }

        [Required]
        public string FileUrl { get; set; }

        [Required]
        public int StudentIdentification { get; set; }

        [Required]
        public string CourseId { get; set; }
    }
}