using Microsoft.AspNetCore.Mvc;

namespace ordered_jobs_web_api.Controllers
{
    [Route("api/[controller]")]
    public class OrderedJobsController : Controller
    {
        string welcomeMessage = "Welcome to the Ordered Jobs Web API!  add /{jobs you want ordered} to the url to get your jobs in the right order";
        
        // GET api/orderedjobs
        [HttpGet]
        public string Get()
        {
            return welcomeMessage;
        }

        // GET api/orderedjobs/a-|b-c|c-
        [HttpGet("{unorderedJobs}")]
        public string Get(string unorderedJobs)
        {
            OrderedJobs orderedJobs = new OrderedJobs();
            return orderedJobs.order(unorderedJobs);
        }

        // POST api/orderedjobs
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/orderedjobs/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/orderedjobs/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
