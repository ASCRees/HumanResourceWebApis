using HumanResourcesWebApis.Services.Interfaces;
using HumanResourceWebApis.Models;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.Web.Http.Description;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using HumanResourcesWebApis.DataLayer;

namespace HumanResourceWebApis.Controllers
{
    public class DepartmentsController : ApiController
    {
        private IBuildDepartmentsModelServices _buildDepartmentsModelServices;

        [DefaultConstructor]
        public DepartmentsController(IBuildDepartmentsModelServices buildDepartmentsModelServices)
        {
            _buildDepartmentsModelServices = buildDepartmentsModelServices;
        }

        //GET: api/Departments

        public IQueryable<DepartmentViewModel> GetDepartments()
        {
            List<DepartmentViewModel> departments = Mapper.Map<List<DepartmentViewModel>>(_buildDepartmentsModelServices.GetAllDepartments());
            return departments.AsQueryable();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _buildDepartmentsModelServices.DisposeContext();
            }
            base.Dispose(disposing);
        }
    }
}