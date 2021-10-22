using HumanResourceWebApis.App_Start;
using System;

namespace HumanResourceWebApis.Tests.Controllers
{
    public class TestsFixture : IDisposable
    {
        public TestsFixture()
        {
            try
            {
                AutoMapper.Mapper.Configuration.AssertConfigurationIsValid();
            }
            catch (InvalidOperationException)
            {
                AutoMapperConfig.CreateMappings();
            }
        }

        public void Dispose()
        {
            // Do "global" teardown here; Only called once.
        }
    }
}