using System.Collections.Generic;
using FluentAssertions;
using NextDashboard.Web;
using NextDashboard.Web.Controllers;
using NextDashboard.Web.DataContracts;
using NUnit.Framework;

namespace NextDashboard.Test.Unit.Controllers
{
    [TestFixture]
    public class JobsControllerTest
    {
        [Test]
        public void When_Asked_For_Jobs_The_Controller_Should_Return_A_List_of_Jobs()
        {
            //Arrange
            var sut = new JobController(new FakeJobsRepository());

            //Act
            List<Job> actual = sut.Get();

            //Assert
            actual.GetType().Should().Be(typeof (List<Job>));
        }
    }
}