using JobSearchAssistant.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace JobSearchAssistant.Client.Services
{
    public class EventService : IEventService
    {
        private readonly HttpClient _http;
        public EventService(HttpClient http)
        {
            _http = http;
        }
        public async Task<Event> CreateNewEvent(Event request)
        {
            var result = await _http.PostAsJsonAsync("api/Event", request);
            return await result.Content.ReadFromJsonAsync<Event>();
        }
        public async Task<List<Event>> GetEventsByUserId(string userId)
        {
            return await _http.GetFromJsonAsync<List<Event>>($"api/Event/byuserid/{userId}");
        }
        public async Task<Event> GetEventById(int id)
        {
            return await _http.GetFromJsonAsync<Event>($"api/Job/byeventid/{id}");
        }
        public async Task<List<Event>> GetEvents()
        {
            return await _http.GetFromJsonAsync<List<Event>>("api/Event");
        }
        public async Task DeleteEventById(int id)
        {
            var result = await _http.DeleteAsync($"api/Event/{id}");
        }
    }
}
