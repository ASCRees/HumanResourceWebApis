using System;
using System.ComponentModel.DataAnnotations;

namespace HumanResourceWebApis.Models
{
    public class VwEmployeeViewModel : EmployeeViewModel
    {
        public string DepartmentName { get; set; }
        public string StatusName { get; set; }

        [Display(Name = "Resource Name*")]
        public string FullName
        {
            get
            {
                return FirstName + " " + SurName;
            }
        }
    }
}