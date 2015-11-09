namespace StudentSystem.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CourseResponseModel
    {
        public string CourseId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}