using HumanResourcesWebApis.DataLayer;
using HumanResourcesWebApis.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HumanResourcesWebApis.Services
{
    public class BuildDepartmentsModelServices : BuildModelServicesBase, IBuildDepartmentsModelServices
    {
        public List<Department> GetDepartments()
        {
            return Context.Departments.ToList();
        }
    }
}