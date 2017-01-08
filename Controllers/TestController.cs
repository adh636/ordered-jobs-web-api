using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace ordered_jobs_web_api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        IMongoClient client;
        public TestController(IMongoClient mongoClient)
        {
            client = mongoClient;
        }
        
        // GET api/test
        [HttpGet]
        public async Task<OrderedJobsResult> Get()
        {
            var database = client.GetDatabase("orderedjobs");
            var collection = database.GetCollection<TestCase>("testcases");
            List<TestCase> testCases = new List<TestCase>();
            await collection.Find(new BsonDocument()).ForEachAsync(X => {
                testCases.Add(X);
            });
            return new OrderedJobsResult(testCases);
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
            var database = client.GetDatabase("orderedjobs");
            var collection = database.GetCollection<TestCase>("testcases");
            var filter = new BsonDocument();
            var result = collection.DeleteManyAsync(filter);
        }
    }
}