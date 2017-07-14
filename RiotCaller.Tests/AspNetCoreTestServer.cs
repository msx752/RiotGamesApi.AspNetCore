using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Builder.Internal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RiotGamesApi.Web;

namespace RiotGamesApi.Tests
{
    public class AspNetCoreTestServer
    {
        public IServiceProvider ServiceProvider { get; }

        public TestServer _server { get; }

        public HttpClient _client { get; }

        public AspNetCoreTestServer()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
            ServiceProvider = _server.Host.Services;
        }
    }
}