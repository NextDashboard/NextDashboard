using System.Collections.Generic;
using FluentAssertions;
using NextDashboard.Application;
using NextDashboard.Application.DataContracts;
using NUnit.Framework;
using UI.Host.Controllers;

namespace NextDashboard.Test.Unit.Controllers
{
    [TestFixture]
    public class JobsControllerTest
    {
        [Test]
        public void When_Asked_For_Jobs_The_Controller_Should_Return_A_List_of_Jobs()
        {
            //Arrange
            var sut = new JobController();

            //Act
            List<Job> actual = sut.Get();

            //Assert
            actual.GetType().Should().Be(typeof(List<Job>));
        }
    }
}