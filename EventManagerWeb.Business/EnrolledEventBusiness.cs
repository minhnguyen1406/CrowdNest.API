using EventManagerWeb.Contracts;
using EventManagerWeb.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagerWeb.Business
{
    public class EnrolledEventBusiness : IEnrolledEventBusiness
    {
        private readonly IRepository repository;

        public EnrolledEventBusiness(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> EnrollEvent(EnrolledEvent enrolledEvent)
        {
            return await this.repository.EnrollEvent(enrolledEvent);
        }

        public async Task<List<EnrolledEvent>> GetAllEnrolledEvents()
        {
            return await this.repository.GetAllEnrolledEvents();
        }

        public async Task<EnrolledEvent> GetEnrolledEventById(int id)
        {
            return await this.repository.GetEnrolledEventById(id);
        }
        public async Task<List<EnrolledEvent>> GetEnrolledEventsByUserId(int uId)
        {
            return await this.repository.GetEnrolledEventsByUserId(uId);
        }

        public async Task<int> RemoveEnrolledEvent(int userId, int eventId)
        {
            return await this.repository.RemoveEnrolledEvent(userId, eventId);
        }
    }
}
