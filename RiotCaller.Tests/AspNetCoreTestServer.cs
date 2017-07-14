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

        public TestServer Server { get; }

        public HttpClient Client { get; }

        public AspNetCoreTestServer()
        {
            Server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            Client = Server.CreateClient();
            ServiceProvider = Server.Host.Services;
        }
    }
}