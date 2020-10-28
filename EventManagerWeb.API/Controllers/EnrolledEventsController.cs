using EventManagerWeb.Contracts;
using EventManagerWeb.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EventManagerWeb.API.Controllers
{
    [Route("api/EventManagerWeb")]
    [ApiController]
    public class EnrolledEventController : ControllerBase
    {
        private readonly IEnrolledEventBusiness enrolledEventBusiness;

        public EnrolledEventController(IEnrolledEventBusiness enrolledEventBusiness)
        {
            this.enrolledEventBusiness = enrolledEventBusiness;
        }

        /// <summary>
        /// Retrieve all available enrolled events
        /// </summary>
        /// <returns>Return all enrolled events</returns>
        [HttpGet]
        [Route("enrolled-events")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<EnrolledEvent>>> GetEnrolledEvents()
        {
            var enrolledEvents = await this.enrolledEventBusiness.GetAllEnrolledEvents();
            return Ok(enrolledEvents);
        }


        /// <summary>
        /// Retrive a enrolled event based on id
        /// </summary>
        /// <returns>Return the enrolled event</returns>
        [HttpGet]
        [Route("enrolled-events/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<EnrolledEvent>>> GetEnrolledEventById(int id)
        {
            var enrolledEvent = await this.enrolledEventBusiness.GetEnrolledEventById(id);
            if (enrolledEvent == null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return Ok(enrolledEvent);
        }

        /// <summary>
        /// Retrive an enrolled event based on user id
        /// </summary>
        /// <returns>Return the list enrolled event with same customer id</returns>
        [HttpGet]
        [Route("enrolled-events/user/{userId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<EnrolledEvent>>> GetEnrolledEventsByUserId(int userId)
        {
            var enrolledEvents = await this.enrolledEventBusiness.GetEnrolledEventsByUserId(userId);
            if (enrolledEvents == null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return Ok(enrolledEvents);
        }

        /// <summary>
        /// Save a new enrolled event
        /// </summary>
        /// <param name="enrolledEvent">Given a enrolled event</param>
        /// <returns>Returns status of enrolled event created</returns>
        [HttpPost]
        [Route("enrolled-events")]
        public async Task<ActionResult<int>> SaveNewEnrolledEvent(EnrolledEvent enrolledEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }
            var response = await this.enrolledEventBusiness.EnrollEvent(enrolledEvent);

            return Ok(response);
        }   

        /// <summary>
        /// Delete an existing enrolled event
        /// </summary>
        /// <param name="id">Given enrolled event id</param>
        /// <returns>Returns status of enrolled event removed</returns>
        [HttpDelete]
        [Route("enrolled-events/{userId}/{eventId}")]  
        public async Task<ActionResult<int>> RemoveEnrolledEvent(int userId, int eventId)
        {
            var response = await this.enrolledEventBusiness.RemoveEnrolledEvent(userId, eventId);

            return Ok(response);
        }
    }
}

