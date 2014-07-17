using System.Collections.Generic;
using FluentAssertions;
using NextDashboard.Api.Contollers;
using NUnit.Framework;

namespace NextDashboard.Api.Test.Controllers
{
    [TestFixture]
    public class JobsControllerTest
    {
        
        [Test]
        public void When_Asked_For_Jobs_The_Controller_Should_Return_A_List_of_Jobs()
        {
            //Arrange
            var sut = new JobsController(new FakeJobsRepository()); 

            //Act
            var actual = sut.Get();

            //Assert
            actual.GetType().Should().Be(typeof (List<Job>));



        }
    }
}