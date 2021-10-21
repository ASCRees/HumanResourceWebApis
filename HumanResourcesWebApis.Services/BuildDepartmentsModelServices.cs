using HumanResourcesWebApis.DataLayer;
using HumanResourcesWebApis.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HumanResourcesWebApis.Services
{
    public class BuildDepartmentsModelServices : BuildModelServicesBase, IBuildDepartmentsModelServices
    {
        public List<Department> GetAllDepartments()
        {
            return Context.Departments.ToList();
        }

        public void DisposeContext()
        {
            base.Dispose();
        }
    }
}