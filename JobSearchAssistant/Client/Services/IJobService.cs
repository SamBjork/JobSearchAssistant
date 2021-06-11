using JobSearchAssistant.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchAssistant.Client.Services
{
    interface IJobService
    {
        Task<List<Job>> GetJobs();
        Task<List<Job>> GetJobsByUserId(string userId);
        Task<Job> GetJobById(int id);
        Task<Job> CreateNewJob(Job request);
        Task<Job> DeleteJobById(int id);
    }
}
