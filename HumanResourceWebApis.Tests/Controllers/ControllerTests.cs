using FluentAssertions;
using HumanResourcesWebApis.Services.Interfaces;
using HumanResourceWebApis.App_Start;
using HumanResourceWebApis.Controllers;
using HumanResourceWebApis.Tests.Base;
using HumanResourceWebApis.Tests.Helper;
using Moq;
using System.Diagnostics.CodeAnalysis;
using Xunit;
using System.Linq;

namespace HumanResourceWebApis.Tests.Controllers
{
    [ExcludeFromCodeCoverage]
    public class ControllerTests : HumanResourcesBaseTests, IClassFixture<TestsFixture>
    {
        private MockRepository _mockRepository;
        private Mock<IBuildEmployeesModelServices> _mockBuildEmployeesModelServices;
        private Mock<IBuildStatusModelServices> _mockBuildStatusModelServices;
        private Mock<IBuildDepartmentsModelServices> _mockBuildDepartmentsModelServices;

        public ControllerTests()
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
        public void Get_Employees()
        {
            // Arrange
            var employeesList = EmployeeSampleTestData.CreateMultipleEmployees(5);

            _mockBuildEmployeesModelServices.Setup(c => c.GetAllEmployees()).Returns(employeesList);

            EmployeesController employeeController = new EmployeesController(_mockBuildEmployeesModelServices.Object);

            // Act
            IQueryable<Models.VwEmployeeViewModel> employeeViewModels = employeeController.GetEmployees();

            // Assert
            employeeViewModels.Should().HaveCount(5);
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
        public void Get_Departments()
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
        public void GetStatusShouldReturnFi()
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