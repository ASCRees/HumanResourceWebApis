using System;
using System.ComponentModel.DataAnnotations;

namespace HumanResourceWebApis.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [Display(Name = "Surname")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public int StatusID { get; set; }

        [Required(ErrorMessage = "Employee Number is required")]
        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; }
    }
}