using HumanResourcesWebApis.DataLayer;
using HumanResourcesWebApis.Services.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HumanResourcesWebApis.Services
{
    public class BuildEmployeesModelServices : BuildModelServicesBase, IBuildEmployeesModelServices
    {
        public Employee CreateEmployee(Employee employee)
        {
            Context.Employees.Add(employee);
            Context.SaveChanges();
            return employee;
        }

        public int UpdateEmployee(int? id, Employee employee)
        {
            Context.Entry(employee).State = EntityState.Modified;

            Context.SaveChanges();

            return Context.SaveChanges();
        }

        public int DeleteEmployee(int employeeId)
        {
            Employee employee = GetEmployeeById(employeeId);
            Context.Employees.Attach(employee);
            Context.Employees.Remove(employee);
            return Context.SaveChanges();
        }

        public bool EmployeeExists(int id)
        {
            return Context.Employees.Count(e => e.EmployeeId.Equals(id)) > 0;
        }

        public List<vwEmployee> GetListOfEmployeesByFilter(int statusId, int departmentId)
        {
            var employeeQueryable = Context.vwEmployees.AsQueryable();

            if (statusId > 0)
            {
                employeeQueryable=employeeQueryable.Where(c => c.StatusID.Equals(statusId));
            }

            if (departmentId > 0)
            {
                employeeQueryable=employeeQueryable.Where(c => c.DepartmentID.Equals(departmentId));
            }

            return employeeQueryable.ToList();
        }

        public List<vwEmployee> GetAllEmployees()
        {
            return Context.vwEmployees.ToList();
        }

        public Employee GetEmployeeById(int Id)
        {
            return Context.Employees
                               .Where(s => s.EmployeeId.Equals(Id))
                               .FirstOrDefault<Employee>();
        }

        public vwEmployee GetvwEmployeeById(int Id)
        {
            return Context.vwEmployees
                               .Where(s => s.EmployeeId.Equals(Id))
                               .FirstOrDefault<vwEmployee>();
        }

        public void DisposeContext()
        {
            base.Dispose();
        }
    }
}