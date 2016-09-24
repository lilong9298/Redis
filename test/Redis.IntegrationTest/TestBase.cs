using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Redis.Host;
using Xunit.Abstractions;

namespace Redis.IntegrationTest
{
    public class TestBase {
        protected readonly ITestOutputHelper _output;
        protected readonly TestServer _server;
        protected readonly HttpClient _client;
        public TestBase(ITestOutputHelper output) {
            _output = output;
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
    }
}
