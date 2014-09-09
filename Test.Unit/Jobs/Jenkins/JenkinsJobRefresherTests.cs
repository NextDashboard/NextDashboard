using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using NextDashboard.Application.DomainObjects;
using NextDashboard.Application.Http;
using NextDashboard.Application.Jobs.Jenkins;
using NUnit.Framework;

namespace NextDashboard.Test.Unit.Jobs.Jenkins
{
    [TestFixture]
    internal class JenkinsJobRefresherTests
    {
        [Test]
        public void A_Job_Should_Be_Able_To_Refresh_Itself()
        {
            //Arrange

            var httpClient = new Mock<IHttpClientWrapper>();

            string expectedStatus = "mocky mocky";
            var mockRespone = new JenkinsBuildResponse {result = expectedStatus};

            httpClient.Setup(x => x.GetResponse(It.IsAny<string>())).Returns(JsonConvert.SerializeObject(mockRespone));
            var jenkinsJobRefresher = new JenkinsJobRefresher(httpClient.Object);

            //Act
            var actual = jenkinsJobRefresher.Refresh(new JenkinsJob("Dummy", "Passing", "http://10.0.0.1", "TEST_JOB"));

            //Assert
            actual.Status.Should().Be(expectedStatus);
        }
    }
}