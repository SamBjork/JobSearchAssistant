using JobSearchAssistant.Server.Services;
using JobSearchAssistant.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchAssistant.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : Controller
    {
        private readonly IJobService _jobService;
        [HttpGet]
        public IEnumerable<Job> Get()
        {
            try
            {
                var results = _jobService.GetJobs();

                return results;
            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<ActionResult<Job>> GetJobById(int id)
        {
            try
            {
                var result = _jobService.GetJobById(id);
                if (result == null)
                    return NotFound();

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database failure {e.Message}");
            }
        }
    }
}
