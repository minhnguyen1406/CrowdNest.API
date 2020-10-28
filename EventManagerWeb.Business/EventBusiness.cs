using EventManagerWeb.Contracts;
using EventManagerWeb.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagerWeb.Business
{
    public class EventBusiness : IEventBusiness
    {
        private readonly IRepository repository;

        public EventBusiness(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Event>> AddEvent(Event eventModel)
        {
            return await this.repository.AddEvent(eventModel);
        }

        public async Task<List<Event>> GetAllEvents()
        {
            return await this.repository.GetAllEvents();
        }

        public async Task<Event> GetEventById(int id)
        {
            return await this.repository.GetEventById(id);
        }

        public async Task<int> UpdateEvent(Event eventModel)
        {
            return await this.repository.UpdateEvent(eventModel);
        }

        public async Task<int> RemoveEvent(Event eventModel)
        {
            return await this.repository.RemoveEvent(eventModel);
        }
        public async Task<List<Event>>FilterEvents(bool? isActive, bool? isPublished){
            return await this.repository.FilterEvents(isActive, isPublished);
        }
    }
}
