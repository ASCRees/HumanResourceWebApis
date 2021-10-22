using Employees;
using HumanResourceWebApis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HumanResources.ModelBuilder
{
    public class EmployeeModelBuilder : IEmployeeModelBuilder
    {
        public IEnumerable<VwEmployeeViewModel> BuildEmployeeList(string sortOrder, int? status, int? department)
        {
            IEnumerable<VwEmployeeViewModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiclient.GetAsync("Employees").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<VwEmployeeViewModel>>().Result;

            if (status > 0)
            {
                empList = empList.Where(c => c.StatusID.Equals(status));
            }

            if (department > 0)
            {
                empList = empList.Where(c => c.DepartmentID.Equals(department));
            }

            switch (sortOrder)
            {
                case "N":
                    empList = empList.OrderBy(x => x.SurName);
                    break;

                case "D":
                    empList = empList.OrderBy(x => x.DepartmentName);
                    break;

                case "S":
                    empList = empList.OrderBy(x => x.StatusName);
                    break;

                default:
                    empList = empList.OrderBy(x => x.EmployeeNumber);
                    break;
            }

            return empList;
        }

        public SelectList CreateStatusFilterOptions(int? status)
        {
            List<StatusViewModel> statusList = new List<StatusViewModel>(){ new StatusViewModel()
            {
                StatusId = 0,
                StatusName = ""
            } };

            HttpResponseMessage response = GlobalVariables.WebApiclient.GetAsync("Status").Result;
            statusList.AddRange(response.Content.ReadAsAsync<IEnumerable<StatusViewModel>>().Result.ToList());

            return new SelectList(statusList, "StatusId", "StatusName", status);
        }

        public SelectList CreateDepartmentsFilterOptions(int? department)
        {
            List<DepartmentViewModel> departmentList = new List<DepartmentViewModel>() { new DepartmentViewModel()
            {
                DepartmentId = 0,
                DepartmentName = ""
            }};

            HttpResponseMessage response = GlobalVariables.WebApiclient.GetAsync("Departments").Result;
            departmentList.AddRange(response.Content.ReadAsAsync<IEnumerable<DepartmentViewModel>>().Result.ToList());

            return new SelectList(departmentList, "DepartmentId", "DepartmentName", department);
        }
    }
}