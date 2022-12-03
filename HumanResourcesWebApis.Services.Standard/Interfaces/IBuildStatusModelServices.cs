using HumanResourcesWebApis.DataLayer;
using System.Collections.Generic;

namespace HumanResourcesWebApis.Services.Standard.Interfaces
{
    public interface IBuildStatusModelServices
    {
        HRDatabaseEntities1 Context { get; }

        List<Status> GetAllStatus();

        void DisposeContext();
    }
}