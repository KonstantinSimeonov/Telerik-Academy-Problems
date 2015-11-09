using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Web.Models
{
    public class StudentsResponseModel
    {
        public int StudentIdentification { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Level { get; set; }
    }
}