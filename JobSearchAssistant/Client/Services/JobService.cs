using JobSearchAssistant.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace JobSearchAssistant.Client.Services
{
    public class JobService : IJobService
    {
        private readonly HttpClient _http;
        public JobService(HttpClient http)
        {
            _http = http;
        }
        public async Task<Job> CreateNewJob(Job request)
        {
            var result = await _http.PostAsJsonAsync("api/Job", request);
            return await result.Content.ReadFromJsonAsync<Job>();
        }
        public async Task<Job> GetJobById(int id)
        {
            var result = await _http.GetAsync($"api/Job/{id}");
            if(result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new Job { Status = message };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<Job>();
            }
        }
        public async Task<List<Job>> GetJobs()
        {
            return await _http.GetFromJsonAsync<List<Job>>("api/Job");
        }
    }
}
