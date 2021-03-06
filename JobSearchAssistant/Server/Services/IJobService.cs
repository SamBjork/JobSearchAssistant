
using JobSearchAssistant.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchAssistant.Server.Services
{
    public interface IJobService : IRepository
    {
        IEnumerable<Job> GetJobs();
        Job GetJobById(int id);
    }
}
