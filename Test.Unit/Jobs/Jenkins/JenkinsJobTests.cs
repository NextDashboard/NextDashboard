using FluentAssertions;
using NextDashboard.Application.Jobs.Jenkins;
using NUnit.Framework;

namespace NextDashboard.Test.Unit.Jobs.Jenkins
{
    [TestFixture]
    public class JenkinsJobTests
    {
        
        [Test]
        public void Creating_A_Default_Job_Should_Have_A_Blank_Url()
        {
            //Arrange, Act
            var job = GetJenkinsJob();

            //Assert
            job.JenkinsBaseUrl.Should().BeNullOrEmpty();

        }

        [Test]
        public void Creating_A_Default_Job_Should_Have_A_Blank_JenkinsJobName()
        {
            //Arrange, Act
            var job = GetJenkinsJob();

            //Assert
            job.JenkinsJobName.Should().BeNullOrEmpty();

        }

        [Test]
        public void I_Should_Be_Able_To_Create_A_Jenkins_Jobs_By_An_Empty_Constructor_For_Automapper()
        {
            //Arrange, Act
            var job = new JenkinsJob();

            //Assert
            job.Should().BeOfType<JenkinsJob>();
        }

        private JenkinsJob GetJenkinsJob()
        {
            return new JenkinsJob("1", "TheName", "Passing");
        }
    }
}