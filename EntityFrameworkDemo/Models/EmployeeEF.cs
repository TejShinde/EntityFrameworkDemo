﻿using System .ComponentModel .DataAnnotations;
using System .Xml .Linq;

using System .ComponentModel .DataAnnotations .Schema;

namespace EntityFrameworkDemo .Models
    {
    [Table("Employee")]
    public class EmployeeEF
        {
        [Key]

        public int EmpId { get; set; }
        [Required]
        [Display(Name = "Employee Name")]

        public string? Name { get; set; }
        [Required]
        [DataType(DataType .EmailAddress)]
        [Display(Name = "Email Id")]
   
        public string? Email { get; set; }


        [Display(Name = "Employee Salary")]
         [Required]

        public decimal Salary{ get; set; }
        }
    }








