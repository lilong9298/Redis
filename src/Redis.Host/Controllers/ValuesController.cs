using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Redis.Host.Controllers {
    [Route("api/[controller]")]
    public class ValuesController : Controller {
        protected readonly IRedis _redis;

        public ValuesController(IRedis redis) {
            _redis = redis;
        }
        // GET api/values
        [HttpGet]
        public async Task<bool> Get() {
            await _redis.StoreAsync<string>("123", DateTime.Now.Date.ToString(), "123121");
            return true;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id) {

            var val = await _redis.GetAsync<string>("123",DateTime.Now.Date.ToString());

            return val;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value) {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
