using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Profile.Entities
{
    public class Employee_Entity
    {




        

    
        [Required]
        [MaxLength(25)]
        [MinLength(3)]

        public string Name { get; set; }
     

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Empoyee_Id { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public long Contact { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string Email { get; set; }
        [Required]
        public DateTime DOJ { get; set; }
        public DateTime DOB { get; set; }
        public String Gender { get; set; }
    }
}
