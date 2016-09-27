using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace Redis.IntegrationTest
{
    public class ValuesTest:TestBase
    {
        public ValuesTest(ITestOutputHelper output) : base(output) { }

        [Fact]
        public async Task Get() {
            var response = await _client.GetAsync($"api/Values");

            response.EnsureSuccessStatusCode();
            var s1 = await response.Content.ReadAsStringAsync();
            _output.WriteLine(s1);
            var r = JsonConvert.DeserializeObject<bool>(s1);

            Assert.True(r);
        }

        [Fact]
        public async Task Gettest() {
            var response = await _client.GetAsync($"api/Values/1");

            response.EnsureSuccessStatusCode();
            var s1 = await response.Content.ReadAsStringAsync();
            _output.WriteLine(s1);
            var r = JsonConvert.DeserializeObject<string>(s1);

            Assert.True(!string.IsNullOrEmpty(r));
        }
    }
}
