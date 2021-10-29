using System;

namespace HumanResourceWebApis.Tests.Base
{
    public class HumanResourcesBaseTests
    {
        public void Setup()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory + "App_Data\\");
        }
    }
}