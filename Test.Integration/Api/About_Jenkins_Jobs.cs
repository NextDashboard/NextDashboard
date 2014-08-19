using NUnit.Framework;
using NextDashboard.Application;
using NextDashboard.Application.DomainObjects;
using NextDashboard.Application.Jobs.Jenkins;

namespace NextDashboard.Test.Integration.Api
{
    [TestFixture]
    public class About_Jenkins_Jobs
    {
        [Test]
        public void I_Should_Be_Able_To_Refresh_A_Jenkins_Job()
        {
            const string jenkinsBaseUrl = "http://54.79.101.11:8080";
            const string jenkinsJobName = "Test2";
            var job = new JenkinsJob("J1", "Passing", jenkinsBaseUrl,jenkinsJobName,new JenkinsJobRefresher(new HttpClientWrapper()));
            var actual = job.Refresh();

            const string expected = "SUCCESS";
            Assert.AreEqual(expected, actual.Status);
        }
    }
}