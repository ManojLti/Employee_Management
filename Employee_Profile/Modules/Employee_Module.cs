using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Profile.Modules
{
    public class Employee_Module
    {

        [Required]
        [MaxLength(25)]
        [MinLength(3)]

        public String Name { get; set; }
        [Required]
        [MaxLength(5)]

        [MinLength(5)]

        public String Empoyee_Id { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public String Contact { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public String Email { get; set; }
        [Required]
        public String DOB { get; set; }
        public String Gender { get; set; }
    }
}
