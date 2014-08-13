using System;
using System.Net.Http;
using Microsoft.Owin.Testing;
using NUnit.Framework;
using TestStack.BDDfy;
using UI.Host;

namespace NextDashboard.Test.Integration.Api
{
    [TestFixture]
    public class About_Refreshing_Jobs
    {
        private TestServer _inMemoryServer;


        private void GivenTheApiIsRunning()
        {
            _inMemoryServer = TestServer.Create<Startup>();
        }

        private void WhenAJobRefreshIsRequested()
        {
            HttpResponseMessage response = _inMemoryServer.HttpClient.GetAsync("/api/job/Refresh").Result;
            throw new NotImplementedException();
        }

        private void ThenTheJobShouldBeRefreshed()
        {
            throw new NotImplementedException();
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