using System.Threading.Tasks;
using Moq;
using NextDashboard.Application.Http;
using NUnit.Framework;
using Newtonsoft.Json;
using NextDashboard.Application.DomainObjects;
using NextDashboard.Application.Jobs.Jenkins;

namespace NextDashboard.Test.Unit.Jobs.Jenkins
{
    [TestFixture]
    internal class JenkinsJobRefresherTests
    {
        [Test]
        public void test()
        {
            //Arrange
           
            var httpClient = new Mock<IHttpClientWrapper>();

            var mockRespone = new JenkinsBuildResponse(){result = "mocky mocky"};

            httpClient.Setup(x => x.GetResponse(It.IsAny<string>())).Returns(JsonConvert.SerializeObject(mockRespone));
            var jenkinsJobRefresher = new JenkinsJobRefresher(httpClient.Object);

            //Act
            var actual = jenkinsJobRefresher.Refresh(new JenkinsJob("Dummy", "Passing","http://10.0.0.1","TEST_JOB"));

            //Assert

        }
    }
}