using Microsoft.AspNetCore.Mvc;

namespace ordered_jobs_web_api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        TestCaseHelper helper;

        public TestController(TestCaseHelper helper)
        {
            this.helper = helper;
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
            helper.InsertTestCase(value);
        }

        // DELETE api/test/
        [HttpDelete]
        public void Delete()
        {
            helper.DeleteAllTestCases();
        }
    }
}