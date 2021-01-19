using System;
using Xunit;
using OSD_Utility;

namespace OSD_Utility_Tester
{
    public class Tester_PowerShellHelper
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal("", PowerShellHelper.RunScript("ping www.baidu.com"));
        }
    }
}
