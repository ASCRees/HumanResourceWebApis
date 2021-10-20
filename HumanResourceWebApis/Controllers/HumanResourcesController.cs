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
    public class HumanResourcesController : ApiController
    {
        private IBuildEmployeesModelServices _buildEmployeesModelServices;

        [DefaultConstructor]
        public HumanResourcesController(IBuildEmployeesModelServices buildEmployeesModelServices)
        {
            _buildEmployeesModelServices = buildEmployeesModelServices;
        }

        //GET: api/Employees

        public IQueryable<EmployeeViewModel> GetEmployees()
        {
            var emps = Mapper.Map<List<VwEmployeeViewModel>>(_buildEmployeesModelServices.GetAllEmployees());
            return emps.AsQueryable();
        }

        // GET: api/Employees/5
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

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, EmployeeViewModel employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            try
            {
                _buildEmployeesModelServices.UpdateEmployee(id, Mapper.Map<Employee>(employee));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_buildEmployeesModelServices.EmployeeExists(employee.Id))
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

        // POST: api/Employees
        [ResponseType(typeof(EmployeeViewModel))]
        public IHttpActionResult PostEmployee(EmployeeViewModel employee)
        {
            _buildEmployeesModelServices.CreateEmployee(Mapper.Map<Employee>(employee));

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
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