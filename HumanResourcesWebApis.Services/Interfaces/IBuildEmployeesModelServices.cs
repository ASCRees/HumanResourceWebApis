using HumanResourcesWebApis.DataLayer;
using System.Collections.Generic;

namespace HumanResourcesWebApis.Services.Interfaces
{
    public interface IBuildEmployeesModelServices
    {
        Employee CreateEmployee(Employee employee);

        int DeleteEmployee(int employeeId);

        Employee GetEmployeeById(int Id);

        List<vwEmployee> GetListOfEmployeesByFilter(int statusId, int departmentId);

        bool EmployeeExists(int id);

        List<vwEmployee> GetAllEmployees();

        vwEmployee GetvwEmployeeById(int Id);

        int UpdateEmployee(int? id, Employee employee);

        void DisposeContext();
    }
}