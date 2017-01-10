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
        IMongoDatabase database;
        IMongoCollection<TestCase> collection;

        public TestController(IMongoClient mongoClient)
        {
            client = mongoClient;
            database = client.GetDatabase("orderedjobs");
            collection = database.GetCollection<TestCase>("testcases");
        }

        // // GET api/test
        // [HttpGet]
        // public async Task<OrderedJobsResult> Get([FromBody]TestCase value)
        // {
        //     List<TestCase> testCases = new List<TestCase>();
        //     await collection.Find(new BsonDocument()).ForEachAsync(X => {
        //         testCases.Add(X);
        //     });
        //     return new OrderedJobsResult(testCases);
        // }

        // GET api/test
        [HttpGet]
        public async Task<OrderedJobsResult> Get()
        {
            List<TestCase> testCases = new List<TestCase>();
            await collection.Find(new BsonDocument()).ForEachAsync(X => {
                testCases.Add(X);
            });
            return new OrderedJobsResult(testCases, "http://localhost:5000/api/orderedjobs");
        }

        // POST api/test
        [HttpPost]
        public void Post([FromBody]TestCase value)
        {
            collection.InsertOneAsync(value);
        }

        // PUT api/test/5
        [HttpPut("{id}")]
        public OrderedJobsResult Put(int id, [FromBody]string url)
        {
            List<TestCase> testCases = new List<TestCase>();
            collection.Find(new BsonDocument()).ForEachAsync(X => {
                testCases.Add(X);
            });
            return new OrderedJobsResult(testCases, url);
        }

        // DELETE api/test/5~
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var filter = new BsonDocument();
            collection.DeleteManyAsync(filter);
        }
    }
}