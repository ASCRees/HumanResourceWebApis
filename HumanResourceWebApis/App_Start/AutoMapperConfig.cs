using AutoMapper;
using HumanResourcesWebApis.DataLayer;
using HumanResourceWebApis.Models;
using System.Diagnostics.CodeAnalysis;

namespace HumanResourceWebApis.App_Start
{
    [ExcludeFromCodeCoverage]
    public class AutoMapperConfig : Profile
    {
        /// <summary>
        /// Creates the mappings.
        /// </summary>
        public static void CreateMappings()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeViewModel>();
                cfg.CreateMap<EmployeeViewModel, Employee>();
                cfg.CreateMap<vwEmployee, VwEmployeeViewModel>();
                cfg.CreateMap<Department, Department>();
                cfg.CreateMap<Status, Status>();
            });
        }
    }
}