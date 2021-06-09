using JobSearchAssistant.Server.Data;
using JobSearchAssistant.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchAssistant.Server.Services
{
    public class JobService : Repository
    {
        public JobService(ApplicationDbContext context) : base(context)
        {
        }
        //change to get by userid
        public IEnumerable<Job> GetJobs()
        {
            IQueryable<Job> query = _context.Jobs;
            return query.ToArray();
        }
        //change to userid and jobid
        public Job GetJobById(int id)
        {
            IQueryable<Job> query = _context.Jobs.Where(x => x.Id == id);
            return query.FirstOrDefault();
        }
    }
}
