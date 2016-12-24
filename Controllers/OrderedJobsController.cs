using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ordered_jobs_web_api.Controllers
{
    [Route("api/[controller]")]
    public class OrderedJobsController : Controller
    {
        // GET api/orderedjobs
        [HttpGet]
        public string Get()
        {
            string welcomeMessage = "Welcome to the Ordered Jobs Web API! "  
             + "add /{jobs you want ordered} to the url to get your jobs in the right order";
            return welcomeMessage;
        }

        // GET api/orderedjobs/5
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
