using HumanResourcesWebApis.DataLayer;
using HumanResourcesWebApis.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HumanResourcesWebApis.Services
{
    public class BuildStatusModelServices : BuildModelServicesBase, IBuildStatusModelServices
    {
        public List<Status> GetStatus()
        {
            return Context.Status.ToList();
        }
    }
}