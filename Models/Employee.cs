using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RequestSupportApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name = "Employee Name:")]
        [Required(ErrorMessage = "Can't create an employee without a name")]
        public string EmployeeName { get; set; }
        [Display(Name = "Department Name:")]
        [Required(ErrorMessage = "Can't create an employee without an associated department name")]
        public string EmployeeDepartment { get; set; }

        public Employee()
        {

        }
    }
}
