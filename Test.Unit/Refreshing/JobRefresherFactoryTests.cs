using FluentAssertions;
using Moq;
using NextDashboard.Application;
using NextDashboard.Application.Http;
using NextDashboard.Application.Refreshing;
using NUnit.Framework;

namespace NextDashboard.Test.Unit.Refreshing
{
    [TestFixture]
    public class JobRefresherFactoryTests
    {
      

        [Test]
        public void When_Passed_The_Text_Jenkins_Should_Return_JenkinsJobRefresher()
        {
            //Arrange/Act
            IJobRefresher refresher = CreateJobRefresher(Constants.Jobs.Jenkins);

            //Assert
            refresher.Should().BeOfType<JenkinsJobRefresher>();
        }

        [Test]
        public void When_Passed_The_Text_Sample_Should_Return_SampleJobRefresher()
        {
            //Arrange/Act
            IJobRefresher refresher = CreateJobRefresher(Constants.Jobs.Sample);

            //Assert
            refresher.Should().BeOfType<SampleJobRefresher>();
        }

        private IJobRefresher CreateJobRefresher(string jobType)
        {
            var http = new Mock<IHttpClientWrapper>();
            var refresherFactory = new JobRefresherFactory(http.Object);
            return refresherFactory.GetJobRresher(jobType);
        }


    }
}