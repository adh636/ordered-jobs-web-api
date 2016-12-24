using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ordered_jobs_web_api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        // GET api/test
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/test/5
        [HttpGet("{value}")]
        public string Get(string value)
        {
            return value;
        }

        // POST api/test
        [HttpPost]
        public void Post([FromBody]TestCase value)
        {
            IMongoClient client = new MongoClient();
            var database = client.GetDatabase("orderedjobs");
            var collection = database.GetCollection<TestCase>("testcases");
            collection.InsertOneAsync(value);
        }

        // PUT api/test/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/test/5~
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IMongoClient client = new MongoClient();
            var database = client.GetDatabase("orderedjobstests");
            var collection = database.GetCollection<TestCase>("testcases");
            var filter = new BsonDocument();
            var result = collection.DeleteManyAsync(filter);
        }
    }
}