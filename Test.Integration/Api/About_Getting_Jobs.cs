using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using FluentAssertions;
using Microsoft.Owin.Testing;
using NUnit.Framework;
using NextDashboard.Application.DataContracts;
using TestStack.BDDfy;
using UI.Host;

namespace NextDashboard.Test.Integration.Api
{
    [TestFixture]
    public class About_Getting_Jobs
    {
        private TestServer _inMemoryServer;

        private IEnumerable<Job> _result;


        private void GivenTheApiIsRunning()
        {
            _inMemoryServer = TestServer.Create<Startup>();
        }

        private void WhenIRequestAListOfJobs()
        {
            HttpResponseMessage response = _inMemoryServer.HttpClient.GetAsync("/api/job").Result;
            _result = response.Content.ReadAsAsync<IEnumerable<Job>>().Result;
        }

        private void ThenIShouldSeeAListOfJobs()
        {
            _result.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void GettingAListOfJobs()
        {
            this.Given(_ => GivenTheApiIsRunning())
                .When(_ => WhenIRequestAListOfJobs())
                .Then(_ => ThenIShouldSeeAListOfJobs())
                .BDDfy();
        }

    }
}
