using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }
        [StringLength(50)]
        [Display(Name = "Sala")]
        public string Location { get; set; }

        [Display(Name = "Professor")]
        public Instructor Instructor { get; set; }
    }
}