using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RequestSupportApp.Models
{
    public class Employee
    {
        //Primary key for Employee
        public int Id { get; set; }
        //Following Employee attributes are required -> user must enter values for these attributes in order to create a new Employee
        [Display(Name = "Employee Name:")]
        [Required(ErrorMessage = "Can't create an employee without a name")]
        public string EmployeeName { get; set; }
        [Display(Name = "Department Name:")]
        [Required(ErrorMessage = "Can't create an employee without an associated department name")]
        public string EmployeeDepartment { get; set; }
        //Constructor
        public Employee()
        {

        }
    }
}
