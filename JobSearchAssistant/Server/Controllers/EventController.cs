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
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Event>> GetAllEvents()
        {
            return Ok(_context.Events);
        }

        [HttpGet("byeventid/{id}")]
        public ActionResult<Event> GetEventById(int id)
        {
            try
            {

                var result = _context.Events.Where(p => p.Id.Equals(id));
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database failure {e.Message}");
            }
        }
        [HttpGet("byuserid/{userId}")]
        public ActionResult<List<Event>> GetEventsByUserId(string userId)
        {
            try
            {

                var results = _context.Events.Where(p => p.UserId.Equals(userId));
                if (results == null)
                    return NotFound();

                return Ok(results);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database failure {e.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Event>> CreateNewEvent(Event request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();

            return request;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Event>> UpdateEvent(Event request)
        {
            _context.Update(request);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> DeleteEventById(int id)
        {
            var result = _context.Events.FirstOrDefault(e => e.Id.Equals(id));
            _context.Events.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
