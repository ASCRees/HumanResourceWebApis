using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using HumanResourcesWebApis.DataLayer;

namespace HumanResourceWebApis.Tests.Helper
{
    public static class EmployeeSampleTestData
    {
        public static List<Status> StatusList = new List<Status>() { new Status()
        {
            StatusId=1,
            StatusName="Advanced"
        },
            new Status()
        {
            StatusId=2,
            StatusName="Pending"
        },
            new Status()
        {
            StatusId=3,
            StatusName="Disabled"
        },
        };

        public static List<Department> DepartmentList = new List<Department>() { new Department()
        {
            DepartmentId=1,
            DepartmentName="Marketing"
        },
            new Department()
        {
            DepartmentId=2,
            DepartmentName="Software Development"
        },
            new Department()
        {
            DepartmentId=3,
            DepartmentName="Sales"
        },
        };

        public static Employee CreateEmployee(int id)
        {
            var faker = new Faker("en");

            return new Employee()
            {
                EmployeeId = id,
                FirstName = faker.Person.FirstName,
                SurName = faker.Person.LastName,
                DateOfBirth = faker.Person.DateOfBirth,
                DepartmentID = faker.PickRandom(DepartmentList).DepartmentId,
                StatusID = faker.PickRandom(StatusList).StatusId,
                EmployeeNumber = "A" + faker.Random.Int(0, 500)
            };
        }

        public static vwEmployee CreatevwEmployee(int id)
        {
            var faker = new Faker("en");

            Department department = faker.PickRandom(DepartmentList);
            Status status = faker.PickRandom(StatusList);

            return new vwEmployee()
            {
                EmployeeId = id,
                FirstName = faker.Person.FirstName,
                SurName = faker.Person.LastName,
                DateOfBirth = faker.Person.DateOfBirth,
                DepartmentID = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                StatusID = status.StatusId,
                StatusName = status.StatusName,
                EmployeeNumber = "A" + faker.Random.Int(0, 500)
            };
        }

        public static List<vwEmployee> CreateMultiplevwEmployees(int numberOfEmployees)
        {
            List<vwEmployee> employeesList = new List<vwEmployee>();

            for (int i = 0; i < numberOfEmployees; i++)
            {
                employeesList.Add(CreatevwEmployee(i));
            }

            return employeesList;
        }
    }
}