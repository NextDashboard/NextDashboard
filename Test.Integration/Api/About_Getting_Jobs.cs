using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using FluentAssertions;
using Microsoft.Owin.Testing;
using NUnit.Framework;
using NextDashboard.Application.DataContracts;
using UI.Host;

namespace NextDashboard.Test.Integration.Api
{
    [TestFixture]
    public class About_Getting_Jobs
    {
        private TestServer _inMemoryServer;

        [SetUp]
        public void Setup()
        {
            _inMemoryServer = TestServer.Create<Startup>();
        }
        
        [Test]
        public void I_Should_Be_Able_To_Get_A_List_Of_Jobs()
        {
            var response = _inMemoryServer.HttpClient.GetAsync("/api/job").Result;
            var result = response.Content.ReadAsAsync<IEnumerable<Job>>().Result;

            result.Count().Should().BeGreaterThan(0);
        }




    }
}
