using FluentAssertions;
using NUnit.Framework;
using NextDashboard.Application.DomainObjects;
using Job = NextDashboard.Application.DataContracts.Job;


namespace NextDashboard.Test.Unit.DataContracts
{
    [TestFixture]
    public class JobTests
    {
        private const string JobName = "Dan's Job";
        private const string StatusDetail = "Passing";
        private const JobStatus Status = JobStatus.Passing;
        private const string Id = "1";


        public Job CreateJob()
        {
            return new Job(Id, JobName, StatusDetail, Status);
        }

        [Test]
        public void Initializing_A_Job_Should_Set_Its_Name()
        {
            //Arrange
            //Act
            Job job = CreateJob();

            //Assert
            job.Name.Should().Be(JobName);
        }

        [Test]
        public void Initializing_A_Job_Should_Set_Its_Status()
        {
            //Arrange
            //Act
            Job job = CreateJob();

            //Assert
            job.StatusDetail.Should().Be(StatusDetail);
        }
    }
}