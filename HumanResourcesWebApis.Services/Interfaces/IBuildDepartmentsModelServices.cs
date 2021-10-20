using HumanResourcesWebApis.DataLayer;
using System.Collections.Generic;

namespace HumanResourcesWebApis.Services.Interfaces
{
    public interface IBuildDepartmentsModelServices
    {
        HRDatabaseEntities Context { get; }

        List<Department> GetDepartments();
    }
}