using AutoMapper;
using HumanResourcesWebApis.Services.Interfaces;
using HumanResourceWebApis.Models;
using StructureMap;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HumanResourceWebApis.Controllers
{
    public class StatusController : ApiController
    {
        private IBuildStatusModelServices _buildStatusModelServices;

        [DefaultConstructor]
        public StatusController(IBuildStatusModelServices buildStatusModelServices)
        {
            _buildStatusModelServices = buildStatusModelServices;
        }

        //GET: api/HumanResources

        public IQueryable<StatusViewModel> GetStatus()
        {
            List<StatusViewModel> status = Mapper.Map<List<StatusViewModel>>(_buildStatusModelServices.GetAllStatus());
            return status.AsQueryable();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _buildStatusModelServices.DisposeContext();
            }
            base.Dispose(disposing);
        }
    }
}