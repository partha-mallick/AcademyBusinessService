using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.API.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be more than 50 characters")]
        public string Name { get; set; }

        [StringLength(10, ErrorMessage = "Code can't be more than 10 characters")]
        public string Code { get; set; }

        [StringLength(200, ErrorMessage = "Description can't be more than 200 characters")]
        public string Description { get; set; }

        [StringLength(100, ErrorMessage = "Language can't be more than 100 characters")]
        public string Languages { get; set; }
    }
}
