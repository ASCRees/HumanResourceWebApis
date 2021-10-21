using System;

namespace HumanResourceWebApis.Models
{
    public class VwEmployeeViewModel : EmployeeViewModel
    {
        public string DepartmentName { get; set; }
        public string StatusName { get; set; }
    }
}