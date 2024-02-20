using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BulkyWeb.Models
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Name")]
        public string? Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 8000, ErrorMessage = "The field must be between 1 - 8000.")]
        public int DisplayOrder { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Position { get; set; }
        public string? Department { get; set; }
        public string? AccNum { get; set; }
        public string? EmpStatus { get; set; }

        



    }


}
