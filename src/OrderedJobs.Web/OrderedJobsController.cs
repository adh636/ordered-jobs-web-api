using Microsoft.AspNetCore.Mvc;

namespace ordered_jobs_web_api.Controllers
{
    [Route("api/[controller]")]
    public class OrderedJobsController : Controller
    {
        string welcomeMessage = "Welcome to the Ordered Jobs Web API!  add /{jobs you want ordered} to the url to get your jobs in the right order";
        
        OrderedJobs orderedjobs;

        public OrderedJobsController(OrderedJobs orderedJobs)
        {
            this.orderedjobs = orderedJobs;
        }
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
            return orderedjobs.order(unorderedJobs);
        }
    }
}
