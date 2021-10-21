using AutoMapper;
using HumanResourcesWebApis.DataLayer;
using HumanResourcesWebApis.Services.Interfaces;
using HumanResourceWebApis.Models;
using StructureMap;
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
        private IBuildEmployeesModelServices _buildEmployeesModelServices;

        [DefaultConstructor]
        public EmployeesController(IBuildEmployeesModelServices buildEmployeesModelServices)
        {
            _buildEmployeesModelServices = buildEmployeesModelServices;
        }

        //GET: api/HumanResources

        public IQueryable<VwEmployeeViewModel> GetEmployees()
        {
            List<VwEmployeeViewModel> emps = Mapper.Map<List<VwEmployeeViewModel>>(_buildEmployeesModelServices.GetAllEmployees());
            return emps.AsQueryable();
        }

        // GET: api/HumanResources/5
        [ResponseType(typeof(EmployeeViewModel))]
        public IHttpActionResult GetEmployee(int id)
        {
            EmployeeViewModel employee = Mapper.Map<EmployeeViewModel>(_buildEmployeesModelServices.GetEmployeeById(id));
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/HumanResources/5
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
            catch (DbUpdateConcurrencyException)
            {
                if (!_buildEmployeesModelServices.EmployeeExists(employee.EmployeeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/HumanResources
        [ResponseType(typeof(EmployeeViewModel))]
        public IHttpActionResult PostEmployee(EmployeeViewModel employee)
        {
            _buildEmployeesModelServices.CreateEmployee(Mapper.Map<Employee>(employee));

            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/HumanResources/5
        [ResponseType(typeof(EmployeeViewModel))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            EmployeeViewModel employeeViewModel = Mapper.Map<EmployeeViewModel>(_buildEmployeesModelServices.GetEmployeeById(id));

            _buildEmployeesModelServices.DeleteEmployee(id);

            return Ok(employeeViewModel);
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