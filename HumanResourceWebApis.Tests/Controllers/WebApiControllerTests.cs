using FluentAssertions;
using FluentAssertions.Execution;
using HumanResourcesWebApis.DataLayer;
using HumanResourcesWebApis.Services.Interfaces;
using HumanResourceWebApis.Controllers;
using HumanResourceWebApis.Models;
using HumanResourceWebApis.Tests.Base;
using HumanResourceWebApis.Tests.Helper;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web.Http.Results;
using Xunit;

namespace HumanResourceWebApis.Tests.Controllers
{
    [ExcludeFromCodeCoverage]
    public class WebApiControllerTests : HumanResourcesBaseTests, IClassFixture<TestsFixture>
    {
        private MockRepository _mockRepository;
        private Mock<IBuildEmployeesModelServices> _mockBuildEmployeesModelServices;
        private Mock<IBuildStatusModelServices> _mockBuildStatusModelServices;
        private Mock<IBuildDepartmentsModelServices> _mockBuildDepartmentsModelServices;

        public WebApiControllerTests()
        {
            Setup();
            _mockRepository = new MockRepository(MockBehavior.Default);
            _mockBuildEmployeesModelServices = _mockRepository.Create<IBuildEmployeesModelServices>();
            _mockBuildStatusModelServices = _mockRepository.Create<IBuildStatusModelServices>();
            _mockBuildDepartmentsModelServices = _mockRepository.Create<IBuildDepartmentsModelServices>();
        }

        [Fact]
        public void EmployeeControllerInstance()
        {
            //Arrange
            EmployeesController employeeController = new EmployeesController(_mockBuildEmployeesModelServices.Object);

            //Act

            //Assert
            employeeController.Should().NotBeNull();
        }

        [Fact]
        public void GetEmployeesReturnsMultipleRecords()
        {
            // Arrange
            var employeesList = EmployeeSampleTestData.CreateMultiplevwEmployees(5);

            _mockBuildEmployeesModelServices.Setup(c => c.GetAllEmployees()).Returns(employeesList);

            EmployeesController employeeController = new EmployeesController(_mockBuildEmployeesModelServices.Object);

            // Act
            IQueryable<Models.VwEmployeeViewModel> employeeViewModels = employeeController.GetEmployees();

            // Assert
            employeeViewModels.Should().HaveCount(5);
        }

        [Fact]
        public void GetEmployeesReturnsNoRecords()
        {
            // Arrange
            List<vwEmployee> employeesList = new List<vwEmployee>();

            _mockBuildEmployeesModelServices.Setup(c => c.GetAllEmployees()).Returns(employeesList);

            EmployeesController employeeController = new EmployeesController(_mockBuildEmployeesModelServices.Object);

            // Act
            IQueryable<Models.VwEmployeeViewModel> employeeViewModels = employeeController.GetEmployees();

            // Assert
            employeeViewModels.Should().HaveCount(0);
        }

        [Fact]
        public void GetSingleEmployeeByIdReturnsRecord()
        {
            // Arrange
            int employeeid = 1;
            Employee employee = EmployeeSampleTestData.CreateEmployee(1);

            _mockBuildEmployeesModelServices.Setup(c => c.GetEmployeeById(1)).Returns(employee);

            EmployeesController employeeController = new EmployeesController(_mockBuildEmployeesModelServices.Object);

            // Act
            var employeeResult = employeeController.GetEmployee(employeeid);

            // Assert
            using (new AssertionScope())
            {
                OkNegotiatedContentResult<EmployeeViewModel> result = Assert.IsType<OkNegotiatedContentResult<EmployeeViewModel>>(employeeResult);
                (result.Content).EmployeeId.Should().Be(1);
            }
        }

        [Fact]
        public void GetSingleEmployeeByIdNotFound()
        {
            // Arrange
            int employeeid = 1;
            Employee employee = EmployeeSampleTestData.CreateEmployee(1);

            _mockBuildEmployeesModelServices.Setup(c => c.GetEmployeeById(2)).Returns(employee);

            EmployeesController employeeController = new EmployeesController(_mockBuildEmployeesModelServices.Object);

            // Act
            var employeeResult = employeeController.GetEmployee(employeeid);
            var posRes = employeeResult as NotFoundResult;

            // Assert
            posRes.Should().NotBeNull();
        }

        [Fact]
        public void DepartmentsControllerInstance()
        {
            //Arrange
            DepartmentsController departmentsController = new DepartmentsController(_mockBuildDepartmentsModelServices.Object);

            //Act

            //Assert
            departmentsController.Should().NotBeNull();
        }

        [Fact]
        public void GetDepartmentsReturnsMultipleRecords()
        {
            // Arrange
            var DepartmentsList = EmployeeSampleTestData.DepartmentList;

            _mockBuildDepartmentsModelServices.Setup(c => c.GetAllDepartments()).Returns(DepartmentsList);

            DepartmentsController departmentsController = new DepartmentsController(_mockBuildDepartmentsModelServices.Object);

            // Act
            IQueryable<Models.DepartmentViewModel> departmentViewModels = departmentsController.GetDepartments();

            // Assert
            departmentViewModels.Should().HaveCount(3);
        }

        [Fact]
        public void StatusControllerInstance()
        {
            //Arrange
            StatusController statusController = new StatusController(_mockBuildStatusModelServices.Object);

            //Act

            //Assert
            statusController.Should().NotBeNull();
        }

        [Fact]
        public void GetStatusReturnsMultipleRecords()
        {
            // Arrange
            var statusList = EmployeeSampleTestData.StatusList;

            _mockBuildStatusModelServices.Setup(c => c.GetAllStatus()).Returns(statusList);

            StatusController statusController = new StatusController(_mockBuildStatusModelServices.Object);

            // Act
            IQueryable<Models.StatusViewModel> statusViewModels = statusController.GetStatus();

            // Assert
            statusViewModels.Should().HaveCount(3);
        }
    }
}