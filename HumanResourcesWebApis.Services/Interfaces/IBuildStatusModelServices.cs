using HumanResourcesWebApis.DataLayer;
using System.Collections.Generic;

namespace HumanResourcesWebApis.Services.Interfaces
{
    public interface IBuildStatusModelServices
    {
        HRDatabaseEntities Context { get; }

        List<Status> GetStatus();
    }
}