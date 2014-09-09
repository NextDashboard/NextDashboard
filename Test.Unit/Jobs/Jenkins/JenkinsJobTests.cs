using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NextDashboard.Application;
using NextDashboard.Application.DomainObjects;
using NextDashboard.Application.Jobs.Jenkins;
using NUnit.Framework;

namespace NextDashboard.Test.Unit.Jobs.Jenkins
{
    [TestFixture]
    public class JenkinsJobTests
    {
        
        [Test]
        public void Refreshing_A_Jenkins_Job_Should_Return_A_New_Instance_Of_A_Job()
        {
            //Arrange
            var jobRefresher = new Mock<JobRefresher<JenkinsJob>>();
            jobRefresher.Setup(x => x.Refresh(It.IsAny<JenkinsJob>())).Returns(
                new JenkinsJob(){Status = "Refreshed!!"}
                );
            var job = new JenkinsJob("Dan's Job", "Passing", "10.1.1.1", "Dan's Job", jobRefresher.Object);

            //Act
            var refreshedJob = job.Refresh();

            //Assert
            refreshedJob.Should().BeOfType<JenkinsJob>();

        }
    }
}
