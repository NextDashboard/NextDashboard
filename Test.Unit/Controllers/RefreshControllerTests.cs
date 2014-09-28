using Moq;
using NextDashboard.Application.DomainObjects;
using NextDashboard.Application.Refreshing;
using NextDashboard.Application.Repository;
using NUnit.Framework;
using UI.Host.Controllers;

namespace NextDashboard.Test.Unit.Controllers
{
    [TestFixture]
    public class RefreshControllerTests
    {
        [Test]
        public void Refreshing_A_Job_Calls_Asks_The_Refresher_To_Peform_A_Refresh()
        {
            //Arrange
            var jobRepo = new Mock<IJobRepository>();
            var jobRefresherFactory = new Mock<IJobRefresherFactory>();
            var jobRefresher = new Mock<IJobRefresher>();

            jobRepo.Setup(x => x.Select(It.IsAny<int>())).Returns(new FakeJobRepository().Select(1));
            jobRefresherFactory.Setup(x => x.GetJobRresher(It.IsAny<string>())).Returns(jobRefresher.Object);

            var sut = new RefreshController(jobRepo.Object, jobRefresherFactory.Object);

            //Act
            const int jobId = 1;
            sut.Get(jobId);

            //Assert
            jobRefresher.Verify(x => x.RefreshJob(It.IsAny<Job>()), Times.Once);
        }
    }
}