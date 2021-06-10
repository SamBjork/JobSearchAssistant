using JobSearchAssistant.Server.Data;
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
    [Route("api/[controller]")]
    public class JobController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IJobService _jobService;
        public List<Job> Jobs = new List<Job>()
        {
            new Job {Id=1, CompanyName= "Test", Position= "Test", Status= "test", AppliedDate= DateTime.Now  }
        };
        public JobController(ApplicationDbContext context)
        {
            _context = context;
        }
        //public IEnumerable<Job> Get()
        //{
        //    try
        //    {
        //        var results = _jobService.GetJobs();

        //        return results;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        [HttpGet]
        public ActionResult<List<Job>> GetAllJobs()
        {
            return Ok(_context.Jobs);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJobById(int id)
        {
            try
            {

                //var result = _jobService.GetJobById(id);
                var post = _context.Jobs.FirstOrDefault(p => p.Id.Equals(id));
                if (post == null)
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
