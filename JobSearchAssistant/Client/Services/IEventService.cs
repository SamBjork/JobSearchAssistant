using JobSearchAssistant.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchAssistant.Client.Services
{
    interface IEventService
    {
        Task<List<Event>> GetEvents();
        Task<List<Event>> GetEventsByUserId(string userId);
        Task<Event> GetEventById(int id);
        Task<Event> CreateNewEvent(Event request);
        Task DeleteEventById(int id);
    }
}
