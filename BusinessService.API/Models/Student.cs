using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessService.API.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be more than 50 characters")]
        public string Name { get; set; }

        public DateTime? Dob { get; set; }

        [StringLength(10, ErrorMessage = "Gender can't be more than 10 characters")]
        public string Gender { get; set; }
    }
}
