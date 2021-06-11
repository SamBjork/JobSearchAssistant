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

        [HttpGet("byjobid/{id}")]
        public ActionResult<Job> GetJobById(int id)
        {
            try
            {

                var job = _context.Jobs.Where(p => p.Id.Equals(id));
                if (job == null)
                    return NotFound();

                return Ok(job);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database failure {e.Message}");
            }
        }
        [HttpGet("byuserid/{userId}")]
        public ActionResult<List<Job>> GetJobsByUserId(string userId)
        {
            try
            {

                var jobs = _context.Jobs.Where(p => p.UserId.Equals(userId));
                if (jobs == null)
                    return NotFound();

                return Ok(jobs);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database failure {e.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Job>> CreateNewJob(Job request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();

            return request;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Job>> DeleteJobById(int id)
        {
            var job = _context.Jobs.FirstOrDefault(e => e.Id.Equals(id));
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
