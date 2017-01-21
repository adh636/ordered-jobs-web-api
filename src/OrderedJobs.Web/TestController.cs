using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ordered_jobs_web_api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        IMongoClient client;
        IMongoDatabase database;
        IMongoCollection<TestCase> collection;
        TestCaseHelper helper;

        public TestController(IMongoClient mongoClient, TestCaseHelper helper)
        {
            this.helper = helper;
            client = mongoClient;
            database = client.GetDatabase("orderedjobs");
            collection = database.GetCollection<TestCase>("testcases");
        }

        // GET api/test
        [HttpGet]
        public OrderedJobsResult Get([FromQuery]string url)
        {
            return helper.CollectingTestsCasesAndCheckingAgainstUrlAsync(url);
        }

        // POST api/test
        [HttpPost]
        public void Post([FromBody]TestCase value)
        {
            collection.InsertOneAsync(value);
        }

        // DELETE api/test/
        [HttpDelete]
        public void Delete()
        {
            var filter = new BsonDocument();
            collection.DeleteManyAsync(filter);
        }
    }
}