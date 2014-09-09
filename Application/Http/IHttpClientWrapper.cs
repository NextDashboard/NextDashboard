using System;

namespace NextDashboard.Application.Http
{
    public interface IHttpClientWrapper
    {
        Uri BaseAddress { get; set; }
        string GetResponse(string address);
    }
}