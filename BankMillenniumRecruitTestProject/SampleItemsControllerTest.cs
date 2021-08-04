using System;
using BankMillenniumRecruitProject.Controllers;
using BankMillenniumRecruitProject.Services;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;

namespace BankMillenniumRecruitTestProject
{
    public class SampleItemsControllerTest
    {
        private SampleItemsController _testController;
        public SampleItemsControllerTest()
        {
            Mock<ISampleItemService> service = new Mock<ISampleItemService>();
            Mock<ILogger<SampleItemsController>> logger = new Mock<ILogger<SampleItemsController>>();
            _testController = new SampleItemsController(service.Object, logger.Object);
        }

        [Fact]
        public void CreateTest()
        {
            // 
        }
    }
}
