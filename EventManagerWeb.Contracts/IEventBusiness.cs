using EventManagerWeb.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagerWeb.Contracts
{
    public interface IEventBusiness
    {
        /// <summary>
        /// A method to place new event
        /// </summary>
        /// <param name="event">Pass the event object</param>
        /// <returns>Returns id</returns>
        Task<List<Event>> AddEvent(Event eventModel);

        /// <summary>
        /// A method to retrieve event based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns event</returns>
        Task<Event> GetEventById(int id);

        /// <summary>
        /// A method to retrieve all events avaialble
        /// </summary>
        /// <returns>Return a list of all events</returns>
        Task<List<Event>> GetAllEvents();

        /// <summary>
        /// A method to update event based on id
        /// </summary>
        /// <param name="event"></param>
        /// <returns>Returns id</returns>
        Task<int> UpdateEvent(Event eventModel);

        /// <summary>
        /// A method to remove event based on id
        /// </summary>
        /// <param name="event"></param>
        /// <returns>Returns id</returns>
        Task<int> RemoveEvent(Event eventModel);

        /// <summary>
        /// A method to filter events
        /// </summary>
        /// <returns>Return filtered events</returns>
        Task<List<Event>> FilterEvents(bool? isActive, bool? isPublished);

    }
}
