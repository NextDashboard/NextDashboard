using System.Collections.Generic;
using AutoMapper;
using FluentAssertions;
using Moq;
using NextDashboard.Application;
using NextDashboard.Application.DataContracts;
using NextDashboard.Application.Repository;
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
            var mappingEngine = new Mock<IMappingEngine>();
            mappingEngine.Setup(m => m.Map<List<Job>>(It.IsAny<List<Application.DomainObjects.Job>>())).Returns(new List<Job>());
            
            var sut = new JobController(new FakeJobRepository(), mappingEngine.Object);

            //Act
            List<Job> actual = sut.Get();

            //Assert
            actual.GetType().Should().Be(typeof (List<Job>));
        }
    }
}