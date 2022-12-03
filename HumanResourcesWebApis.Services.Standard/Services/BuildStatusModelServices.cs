using HumanResourcesWebApis.DataLayer;
using HumanResourcesWebApis.Services.Standard.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HumanResourcesWebApis.Services.Standard
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