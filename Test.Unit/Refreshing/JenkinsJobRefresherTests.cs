using Moq;
using Newtonsoft.Json;
using NextDashboard.Application.Http;
using NextDashboard.Application.Jobs.Jenkins;
using NextDashboard.Application.Refreshing;
using NextDashboard.Application.Repository;
using NUnit.Framework;

namespace NextDashboard.Test.Unit.Refreshing
{
    [TestFixture]
    public class JenkinsJobRefresherTests
    {
        private JenkinsJob GetJob()
        {
            var repo = new FakeJobRepository();
            return (JenkinsJob) repo.Select(1);
        }

        [Test]
        public void Refreshing_A_Jenkins_Job_Passes_The_Api_Token_To_The_HttpClient()
        {
            //Arrange
            JenkinsJob job = GetJob();
            var httpClient = new Mock<IHttpClientWrapper>();
            httpClient.Setup(x => x.GetResponse(It.IsAny<string>())).Returns(JsonConvert.SerializeObject(job));
            var sut = new JenkinsJobRefresher(httpClient.Object);

            //Act
            sut.RefreshJob(job);

            //Assert
            httpClient.Verify(x => x.SetHeaderUserNameAndPassword(It.IsAny<string>(), job.ApiToken));
        }
    }
}