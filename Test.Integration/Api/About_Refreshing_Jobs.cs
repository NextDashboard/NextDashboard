using System;
using System.Net.Http;
using FluentAssertions;
using Microsoft.Owin.Testing;
using NextDashboard.Application.DataContracts;
using NUnit.Framework;
using TestStack.BDDfy;
using UI.Host;

namespace NextDashboard.Test.Integration.Api
{
    [TestFixture]
    public class About_Refreshing_Jobs
    {
        private TestServer _inMemoryServer;
        private Job _result;

        private void GivenTheApiIsRunning()
        {
            _inMemoryServer = TestServer.Create<Startup>();
        }

        private void WhenAJobRefreshIsRequested()
        {
            var response = _inMemoryServer.HttpClient.GetAsync("/api/refresh/1").Result;
            _result = response.Content.ReadAsAsync<Job>().Result;
        }

        private void ThenTheJobShouldBeRefreshed()
        {
            _result.Status.Contains("Refreshed").Should().BeTrue();
        }

        [Test]
        public void RefreshingAJob()
        {
            this.Given(_ => GivenTheApiIsRunning())
                .When(_ => WhenAJobRefreshIsRequested())
                .Then(_ => ThenTheJobShouldBeRefreshed())
                .BDDfy();
        }
    }
}