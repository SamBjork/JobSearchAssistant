using JobSearchAssistant.Server.Data;
using JobSearchAssistant.Server.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq.EntityFrameworkCore;
using Xunit;
using JobSearchAssistant.Server.Services;

namespace JobSearchAssistantTests
{
    public class JobTest
    {
        [Fact]
        public void GetAllJobs()
        {
            var mockContext = new Mock<ApplicationDbContext>();
            var jobService = new JobService(mockContext.Object);

            var result = jobService.GetJobs();

            Assert.NotNull(result);
        }

    }
}
