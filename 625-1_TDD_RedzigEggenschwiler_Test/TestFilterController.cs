using System;
using NSubstitute;
using ImageConversion.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _625_1_TDD_RedzigEggenschwiler_Test
{
    [TestClass]
    public class TestFilterController
    {
        [TestMethod]
        public void TestMethod1()
        {
            FilterController controller = Substitute.For<IFilterController>();
        }
    }
}
