using System;

namespace HumanResourceWebApis.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public int DepartmentID { get; set; }
        public int StatusID { get; set; }
        public string EmployeeNumber { get; set; }
    }
}