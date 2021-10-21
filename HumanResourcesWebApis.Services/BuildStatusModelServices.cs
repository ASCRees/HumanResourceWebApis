using HumanResourcesWebApis.DataLayer;
using HumanResourcesWebApis.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HumanResourcesWebApis.Services
{
    public class BuildStatusModelServices : BuildModelServicesBase, IBuildStatusModelServices
    {
        public List<Status> GetAllStatus()
        {
            return Context.Status.ToList();
        }

        public void DisposeContext()
        {
            base.Dispose();
        }
    }
}