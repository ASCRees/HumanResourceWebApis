using AutoMapper;
using HumanResourcesWebApis.DataLayer;
using HumanResourcesWebApis.Services.Interfaces;
using HumanResourceWebApis.Models;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace HumanResourceWebApis.Controllers
{
    public class EmployeesController : ApiController
    {
        internal static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(EmployeesController));

        private IBuildEmployeesModelServices _buildEmployeesModelServices;

        [DefaultConstructor]
        public EmployeesController(IBuildEmployeesModelServices buildEmployeesModelServices)
        {
            _buildEmployeesModelServices = buildEmployeesModelServices;
        }

        //GET: api/Employees

        public IQueryable<VwEmployeeViewModel> GetEmployees()
        {           
                List<VwEmployeeViewModel> emps = Mapper.Map<List<VwEmployeeViewModel>>(_buildEmployeesModelServices.GetAllEmployees());
                return emps.AsQueryable();        
        }

        [Route("api/EmployeesFiltered/{statusId?}/{departmentId?}")]
        public IQueryable<VwEmployeeViewModel> GetEmployeesFiltered(int? statusId=null, int? departmentId=null)
        {
            List<VwEmployeeViewModel> empsFiltered = Mapper.Map<List<VwEmployeeViewModel>>(_buildEmployeesModelServices.GetListOfEmployeesByFilter((int)statusId, (int)departmentId));
            return empsFiltered.AsQueryable();

        }

        // GET: api/Employees/5
        [ResponseType(typeof(EmployeeViewModel))]
        public IHttpActionResult GetEmployee(int id)
        {
            try
            {
                EmployeeViewModel employee = Mapper.Map<EmployeeViewModel>(_buildEmployeesModelServices.GetEmployeeById(id));
                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return BadRequest();
            }
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, EmployeeViewModel employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            try
            {
                _buildEmployeesModelServices.UpdateEmployee(id, Mapper.Map<Employee>(employee));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!_buildEmployeesModelServices.EmployeeExists(employee.EmployeeId))
                {
                    return NotFound();
                }
                else
                {
                    Log.Error(ex);
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [ResponseType(typeof(EmployeeViewModel))]
        public IHttpActionResult PostEmployee(EmployeeViewModel employee)
        {
            try
            {
                _buildEmployeesModelServices.CreateEmployee(Mapper.Map<Employee>(employee));

                return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeId }, employee);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return BadRequest();
            }
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(EmployeeViewModel))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            try
            {
                EmployeeViewModel employeeViewModel = Mapper.Map<EmployeeViewModel>(_buildEmployeesModelServices.GetEmployeeById(id));

                _buildEmployeesModelServices.DeleteEmployee(id);

                return Ok(employeeViewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return BadRequest();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _buildEmployeesModelServices.DisposeContext();
            }
            base.Dispose(disposing);
        }
    }
}