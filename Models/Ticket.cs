using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RequestSupportApp.Models
{
    public class Ticket
    {
        public int Id { get; set; }
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
        public Ticket()
        {

        }
    }
}
