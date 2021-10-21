using HumanResourcesWebApis.DataLayer;
using System.Collections.Generic;

namespace HumanResourcesWebApis.Services.Interfaces
{
    public interface IBuildDepartmentsModelServices
    {
        HRDatabaseEntities1 Context { get; }

        List<Department> GetAllDepartments();

        void DisposeContext();
    }
}