using System;

namespace HumanResourceWebApis.Models
{
    public class VwEmployeeViewModel : EmployeeViewModel
    {
        public string Department { get; set; }
        public string Status { get; set; }
    }
}