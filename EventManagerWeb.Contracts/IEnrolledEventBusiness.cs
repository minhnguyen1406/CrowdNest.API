using EventManagerWeb.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagerWeb.Contracts
{
    public interface IEnrolledEventBusiness
    {

        /// <summary>
        /// A method to place new enrolledEvents
        /// </summary>
        /// <param name="enrolledEvents">Pass the enrolledEvents object</param>
        /// <returns>Returns id</returns>
        Task<int> EnrollEvent(EnrolledEvent enrolledEvents);

        /// <summary>
        /// A method to retrieve enrolledEvents based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns enrolledEvents</returns>
        Task<EnrolledEvent> GetEnrolledEventById(int id);

        /// <summary>
        /// A method to retrieve all enrolledEventss avaialble
        /// </summary>
        /// <returns>Return a list of all enrolledEventss</returns>
        Task<List<EnrolledEvent>> GetAllEnrolledEvents();

        /// <summary>
        /// A method to retrieve enrolledEvents based on customer id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns enrolledEvents</returns>
        Task<List<EnrolledEvent>> GetEnrolledEventsByUserId(int uId);

        /// <summary>
        /// A method to remove enrolledEvents based on id
        /// </summary>
        /// <param name="enrolledEvents"></param>
        /// <returns>Returns id</returns>
        Task<int> RemoveEnrolledEvent(int userId, int eventId);
    }
}
