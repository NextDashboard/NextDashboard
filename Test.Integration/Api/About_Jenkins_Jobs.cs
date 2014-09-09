using NextDashboard.Application.DomainObjects;
using NextDashboard.Application.Jobs.Jenkins;
using NUnit.Framework;

namespace NextDashboard.Test.Integration.Api
{
    [TestFixture]
    public class About_Jenkins_Jobs
    {
        [Test]
        public void I_Should_Be_Able_To_Refresh_A_Jenkins_Job()
        {
            const string jenkinsBaseUrl = "http://jenkins.msohosting.local:8080";
            const string jenkinsJobName = "BB - CI/job/Auditing CI";
            var job = new JenkinsJob("J1", "Passing", jenkinsBaseUrl, jenkinsJobName);
            Job actual = job.Refresh();

            const string expected = "SUCCESS";
            Assert.AreEqual(expected, actual.Status);
        }
    }
}