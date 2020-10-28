using EventManagerWeb.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagerWeb.Contracts
{
    public interface IRepository
    {
        #region Event
        Task<List<Event>> AddEvent(Event eventModel);
        Task<Event> GetEventById(int id);
        Task<List<Event>> GetAllEvents();
        Task<List<Event>> FilterEvents(bool? isActive, bool? isPublished);
        Task<int> UpdateEvent(Event eventModel);
        Task<int> RemoveEvent(Event eventModel);
        #endregion


        #region User
        Task<int> AddUser(User user);
        Task<User> ValidateUser(string username, string password);
        Task<List<User>> GetUsers(int pageIndex, int pageSize);
        Task<int> GetUsersCount();
        Task<User> GetUserById(int id);
        Task<User> GetUserByUsername(string username);
        Task<int> EditUser(User user);

        #endregion

        #region Enrolled Events
        Task<int> EnrollEvent(EnrolledEvent enrolledEvents);
        Task<EnrolledEvent> GetEnrolledEventById(int id);
        Task<List<EnrolledEvent>> GetAllEnrolledEvents();
        Task<List<EnrolledEvent>> GetEnrolledEventsByUserId(int uId);
        Task<int> RemoveEnrolledEvent(int userId, int eventId);
        #endregion
    }
}
