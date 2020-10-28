using EventManagerWeb.Contracts;
using EventManagerWeb.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Threading.Tasks;
namespace EventManagerWeb.DataAccess
{
    public class Repository : IRepository
    {
        private readonly EventManagerDbContext eventManagerDbContext;
        public Repository(IConfiguration configuration)
        {
            eventManagerDbContext = new EventManagerDbContext(configuration);
        }

        #region Event
        public async Task<List<Event>> AddEvent(Event eventModel)
        {
            eventModel.IsActive = true;
            eventModel.IsPublished = false;
            eventModel.DateCreated = DateTime.Now;
            this.eventManagerDbContext.Events.Add(eventModel);
            await this.eventManagerDbContext.SaveChangesAsync();
            return await Task.FromResult(this.eventManagerDbContext.Events.ToList());
        }

        public async Task<List<Event>> GetAllEvents()
        {
            return await Task.FromResult(this.eventManagerDbContext.Events.ToList());
        }

        public async Task<List<Event>> FilterEvents(bool? isActive, bool? isPublished) 
        {
            var allEvents = this.eventManagerDbContext.Events.ToList();
            if (isActive != null)
            {
                allEvents = allEvents.Where(e => e.IsActive == isActive).ToList();
            }
            if (isPublished != null)
            {
                allEvents = allEvents.Where(e => e.IsPublished == isPublished).ToList();
            }
            return allEvents;
        }

        public async Task<Event> GetEventById(int id)
        {
            return await Task.FromResult(this.eventManagerDbContext.Events.FirstOrDefault(e => e.Id == id));
        }

        public async Task<int> UpdateEvent(Event eventModel)
        {
            var eventModelToUpdate = this.eventManagerDbContext.Events.FirstOrDefault(e => e.Id == eventModel.Id);
            eventModelToUpdate.Id = eventModel.Id;
            eventModelToUpdate.Title = eventModel.Title;
            eventModelToUpdate.ShortDescription = eventModel.ShortDescription;
            eventModelToUpdate.LongDescription = eventModel.LongDescription;
            eventModelToUpdate.PublishedDate = eventModel.PublishedDate;
            eventModelToUpdate.IsPublished = eventModel.IsPublished;
            eventModelToUpdate.IsActive = eventModel.IsActive;
            eventModelToUpdate.DateCreated = eventModel.DateCreated;
            await this.eventManagerDbContext.SaveChangesAsync();
            return eventModelToUpdate.Id;
        }

        public async Task<int> RemoveEvent(Event eventModel)
        {
            var eventModelToUpdate = this.eventManagerDbContext.Events.FirstOrDefault(e => e.Id == eventModel.Id);
            eventModelToUpdate.IsActive = false;
            await this.eventManagerDbContext.SaveChangesAsync();
            return eventModel.Id;
        }
        #endregion

        #region User
        public async Task<int> AddUser(User user)
        {
            this.eventManagerDbContext.Users.Add(user);
            await this.eventManagerDbContext.SaveChangesAsync();
            return user.Id;
        }
            
        public async Task<List<User>> GetUsers(int pageIndex, int pageSize)
        {

            return await Task.FromResult(this.eventManagerDbContext.Users.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
        }
         
        public async Task<int> GetUsersCount()
        {
            return await Task.FromResult(this.eventManagerDbContext.Users.ToList().Count);
        }

        public async Task<User> GetUserById(int id)
        {
            var user = this.eventManagerDbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return null;
            }

            return await Task.FromResult(user);
        }

        public async Task<User> ValidateUser(string username, string password)
        {
            var user = this.eventManagerDbContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                return null;
            }

            return await Task.FromResult(user);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var user = this.eventManagerDbContext.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return null;
            }

            return await Task.FromResult(user);
        }

        public async Task<int> EditUser(User user)
        {
            var userToUpdate = this.eventManagerDbContext.Users.FirstOrDefault(u => u.Id == user.Id);   
            userToUpdate.Id = user.Id;
            userToUpdate.Username = user.Username;
            userToUpdate.Password = user.Password;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            userToUpdate.Mobile = user.Mobile;
            await this.eventManagerDbContext.SaveChangesAsync();
            return user.Id;
        }
        #endregion

        #region Enrolled Events
        public async Task<int> EnrollEvent(EnrolledEvent enrolledEvent)
        {
            this.eventManagerDbContext.EnrolledEvents.Add(enrolledEvent);
            await this.eventManagerDbContext.SaveChangesAsync();
            return enrolledEvent.EventId;
        }

        public async Task<List<EnrolledEvent>> GetEnrolledEventsByUserId(int uId)
        {
            return await Task.FromResult(this.eventManagerDbContext.EnrolledEvents.Where(e => e.UserId == uId).ToList());
        }

        public async Task<List<EnrolledEvent>> GetAllEnrolledEvents()
        {
            return await Task.FromResult(this.eventManagerDbContext.EnrolledEvents.ToList());
        }

        public async Task<EnrolledEvent> GetEnrolledEventById(int id)
        {
            return await Task.FromResult(this.eventManagerDbContext.EnrolledEvents.FirstOrDefault(e => e.Id == id));
        }

        public async Task<int> RemoveEnrolledEvent(int userId, int eventId)
        {
            var enrolledEvent = this.eventManagerDbContext.EnrolledEvents.FirstOrDefault(e => e.UserId == userId && e.EventId == eventId);
            this.eventManagerDbContext.EnrolledEvents.Remove(enrolledEvent);
            await this.eventManagerDbContext.SaveChangesAsync();
            return enrolledEvent.EventId;
        }
        #endregion
    }
}
