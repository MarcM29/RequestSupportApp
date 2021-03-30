using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RequestSupportApp.Models
{
    public class Ticket
    {
        //Primary key for Ticket
        public int Id { get; set; }

        //Following Ticket attributes are required -> the user MUST enter a value for these variables before a Ticket may be created 
        [Display(Name = "Project Name:")]
        [Required(ErrorMessage = "Submitted tickets must have an associated project name")]
        public string ProjectName { get; set; }

        [Display(Name = "Department Name:")]
        [Required(ErrorMessage = "Submitted tickets must have an associated department")]
        public string DepartmentName { get; set; }

        [Display(Name = "Requested by:")]
        [Required(ErrorMessage = "You must include name of employee")]
        public string EmployeeName { get; set; }

        [Display(Name = "Description of Problem")]
        [Required(ErrorMessage = "You must include name of employee")]
        public string ProjectDesc { get; set; }

        [Display(Name = "Date and Time:")]
        public string TicketDate { get; set; }

        //Constructor
        public Ticket()
        {

        }
    }
}
