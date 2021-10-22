using HumanResourceWebApis.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HumanResources.ModelBuilder
{
    public interface IEmployeeModelBuilder
    {
        IEnumerable<VwEmployeeViewModel> BuildEmployeeList(string sortOrder, int? status, int? department);
        SelectList CreateDepartmentsFilterOptions(int? department);
        SelectList CreateStatusFilterOptions(int? status);
    }
}